
using System.Net;
using UnityEngine;

using Unity.Networking.Transport;
using Unity.Collections;

using NetworkConnection = Unity.Networking.Transport.NetworkConnection;
using Unity.Networking.Transport.Utilities;
using System.Collections;
using Unity.Jobs;

struct ClientUpdateJob : IJob
{
    public UdpNetworkDriver driver;
    public NetworkPipeline networkPipeline; //Pipeline used for transporting packets
    public NativeArray<NetworkConnection> connection;
    public NativeArray<byte> done;

    public void Execute()
    {
        
        if (CleanUpConnections())
        {
            ProcessNetworkEvents();
        }
        else
        {
            Debug.Log("not connected");
        }
    }

    private bool CleanUpConnections()
    {

        if (!connection[0].IsCreated)
        {
            if (done[0] != 1)
            {
                Debug.Log("Something went wrong during connect");
                return false;
            }
        }
        return true;
    }

    private void ProcessNetworkEvents()
    {
        DataStreamReader stream;

        if (!connection.IsCreated)
        {
            return;
        }
        NetworkEvent.Type netEvt;
        while ((netEvt = connection[0].PopEvent(driver, out stream)) != NetworkEvent.Type.Empty)
        {
            switch (netEvt)
            {
                case NetworkEvent.Type.Connect:
                    Debug.Log("We are now connected to the server.");
                    uint value = 1;
                    using (DataStreamWriter writer = new DataStreamWriter(4, Allocator.Temp))
                    {
                        writer.Write(value);
                        connection[0].Send(driver, networkPipeline, writer);
                    }
                    break;

                case NetworkEvent.Type.Data:
                    DataStreamReader.Context readerCtx = default(DataStreamReader.Context);
                    uint number = stream.ReadUInt(ref readerCtx);
                    Debug.LogFormat("Got {0} from Server.", number);
                    done[0] = 1;

                    connection[0].Disconnect(driver);
                    connection[0] = default(NetworkConnection);
                    break;

                case NetworkEvent.Type.Disconnect:
                    Debug.Log("Client disconnected from server");
                    connection[0] = default(NetworkConnection);
                    break;

            }
        }
    }
}

public class TestClient : MonoBehaviour
{
    public UdpNetworkDriver m_Driver;
    private NativeArray<NetworkConnection> m_Connection;
    private NativeArray<byte> m_Done;

    public NetworkPipeline networkPipeline; //Pipeline used for transporting packets
    public JobHandle ClientJobHandle;

    // Start is called before the first frame update
    private void Start()
    {
        //Creates a network driver that can track up to 32 packets at a time (32 is the limit)
        //https://github.com/Unity-Technologies/multiplayer/blob/master/com.unity.transport/Documentation/pipelines-usage.md
        m_Driver = new UdpNetworkDriver(new ReliableUtility.Parameters { WindowSize = 32 });
        networkPipeline = m_Driver.CreatePipeline(typeof(ReliableSequencedPipelineStage));
        //new NetworkPipeline unreliable = m_Driver.CreatePipeline(typeof(NullPipelineStage));
        m_Connection = new NativeArray<NetworkConnection>(1, Allocator.Persistent);
        m_Done = new NativeArray<byte>(1, Allocator.Persistent);

        NetworkEndPoint networkEndpoint = NetworkEndPoint.LoopbackIpv4;
        networkEndpoint.Port = 9000;

        m_Connection[0] = m_Driver.Connect(networkEndpoint);
        Debug.Log("Connecting to server");
    }

    private void Update()
    {
        ClientJobHandle.Complete();
        var job = new ClientUpdateJob
        {
            driver = m_Driver,
            connection = m_Connection,
            done = m_Done,
            networkPipeline = networkPipeline
        };

        ClientJobHandle = m_Driver.ScheduleUpdate();
        ClientJobHandle = job.Schedule(ClientJobHandle);
    }

    private void OnDestroy()
    {
        ClientJobHandle.Complete();

        m_Connection.Dispose();
        m_Driver.Dispose();
        m_Done.Dispose();
    }
}