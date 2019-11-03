using System.Net;
using UnityEngine;

using Unity.Networking.Transport;
using Unity.Collections;

using Unity.Jobs;
using UnityEngine.Assertions;
using Unity.Networking.Transport.Utilities;

struct ServerUpdateConnectionsJob : IJob
{
    public UdpNetworkDriver driver;
    public NativeList<NetworkConnection> connections;

    public void Execute()
    {
        // Clean up connections
        CleanUpConnections();
        AcceptNewConnections();
    }

    private void CleanUpConnections()
    {
        for (int i = 0, ilen = connections.Length; i < ilen; i++)
        {
            if (!connections[i].IsCreated)
            {
                connections.RemoveAtSwapBack(i);
                i--;
            }
        }
    }

    private void AcceptNewConnections()
    {
        NetworkConnection c;
        while ((c = driver.Accept()) != default(NetworkConnection))
        {
            connections.Add(c);
            Debug.Log("Accepted a connection");
        }
    }
}

struct ServerUpdateJob : IJobParallelFor
{
    public UdpNetworkDriver.Concurrent driver;
    public NativeArray<NetworkConnection> connections;
    public NetworkPipeline networkPipeline;

    public void Execute(int index)
    {
        ProcessNetworkEvents(index);
    }

    private void ProcessNetworkEvents(int index)
    {
        DataStreamReader stream;
        NetworkConnection conn = connections[index];

        if (!conn.IsCreated)
        {
            Assert.IsTrue(true);
        }
        NetworkEvent.Type netEvt;
        while ((netEvt = driver.PopEventForConnection(conn, out stream)) != NetworkEvent.Type.Empty)
        {
            switch (netEvt)
            {
                case NetworkEvent.Type.Data:
                    DataStreamReader.Context readerCtx = default(DataStreamReader.Context);
                    uint number = stream.ReadUInt(ref readerCtx);
                    Debug.LogFormat("Got {0} from Client, adding +2 to it.", number);
                    number += 2;
                    // 4 is the size of uint
                    using (DataStreamWriter writer = new DataStreamWriter(4, Allocator.Temp))
                    {
                        writer.Write(number);
                        driver.Send(networkPipeline, conn, writer);
                    }
                    break;

                case NetworkEvent.Type.Disconnect:
                    Debug.Log("Client disconnected from server");
                    conn = default(NetworkConnection);
                    break;

            }
        }
    }
}

public class ServerBehaviour : MonoBehaviour
{
    public UdpNetworkDriver m_Driver;
    public NativeList<NetworkConnection> m_Connections;

    private NetworkPipeline m_NetworkPipeline; //Pipeline used for transporting packets

    private JobHandle ServerJobHandle;

    // Start is called before the first frame update
    private void Start()
    {
        //Creates a network driver that can track up to 32 packets at a time (32 is the limit)
        //https://github.com/Unity-Technologies/multiplayer/blob/master/com.unity.transport/Documentation/pipelines-usage.md
        m_Driver = new UdpNetworkDriver(new ReliableUtility.Parameters { WindowSize = 32 });
        m_NetworkPipeline = m_Driver.CreatePipeline(typeof(ReliableSequencedPipelineStage));
        //new NetworkPipeline unreliable = m_Driver.CreatePipeline(typeof(NullPipelineStage));
        NetworkEndPoint networkEndpoint = NetworkEndPoint.AnyIpv4;
        networkEndpoint.Port = 9000;

        if (m_Driver.Bind(networkEndpoint) != 0)
        {
            Debug.Log("Failed to bind to port 9000");
        }
        else
        {
            m_Driver.Listen();
            m_Connections = new NativeList<NetworkConnection>(16, Allocator.Persistent);
        }
    }

    private void Update()
    {
        ServerJobHandle.Complete();

        var connectionJob = new ServerUpdateConnectionsJob
        {
            driver = m_Driver,
            connections = m_Connections
        };

        var serverUpdateJob = new ServerUpdateJob
        {
            driver = m_Driver.ToConcurrent(),
            connections = m_Connections.AsDeferredJobArray(),
            networkPipeline = m_NetworkPipeline
        };

        ServerJobHandle = m_Driver.ScheduleUpdate();
        ServerJobHandle = connectionJob.Schedule(ServerJobHandle);
        ServerJobHandle.Complete();
        ServerJobHandle = serverUpdateJob.Schedule(m_Connections.Length, 1, ServerJobHandle);
    }

    private void OnDestroy()
    {
        ServerJobHandle.Complete();
        m_Connections.Dispose();
        m_Driver.Dispose();
    }
}
