using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace DunGen
{

    public class BasicDungeonGenerator : MonoBehaviour
    {
        public int CellSize;

        public DungeonLayout DungeonLayout;

        public Transform Root;
        public int Seed = 0;

        public DungeonNode StartRoom;
        public DungeonNode EndRoom;
        public DungeonNode Room1;
        public DungeonNode CorridorStraight;
        public DungeonNode CorridorTurnEast;
        public DungeonNode CorridorTurnWest;

        public int RoomsCreated = 0;
        public int RoomsMax = 5;


        private void Awake()
        {
            StartCoroutine(CreateDungeon());
        }

        private IEnumerator CreateDungeon()
        {
            GameObject enterGameObject = Instantiate(StartRoom.gameObject);
            DungeonNode currentNode = enterGameObject.GetComponent<DungeonNode>();

            RoomsCreated = 1;

            yield return StartCoroutine(CreateNewCorridor(currentNode));

            currentNode = enterGameObject.GetComponent<DungeonNode>();
            AddNodesToRoot(currentNode);
            yield return null;
        }

        private void AddNodesToRoot(DungeonNode node)
        {
            node.transform.SetParent(Root);
            for (int i = 0, ilen = node.ConnectionPoints.Count; i < ilen; i++)
            {
                if (node.ConnectionPoints[i].NodeTo != null)
                {
                    AddNodesToRoot(node.ConnectionPoints[i].NodeTo);
                }
            }
        }

        private IEnumerator CreateNewRoom(DungeonNode corridorNode)
        {
            List<Connection> optionalConnections = corridorNode.Connections.Where(c => ((int)c.ConnectionType & (int)ConnectionType.Outward) != 0).ToList();

            for (int i = 0, ilen = optionalConnections.Count; i < ilen; i++)
            {
                if (optionalConnections[i].ClosedVisual != null)
                {
                    optionalConnections[i].ClosedVisual.SetActive(true);
                }
                if (optionalConnections[i].OpenVisual != null)
                {
                    optionalConnections[i].OpenVisual.SetActive(false);
                }
            }

            int rnd = Random.Range(0, optionalConnections.Count);

            Connection currentConnection = optionalConnections[rnd];

            if (currentConnection.ClosedVisual != null)
            {
                currentConnection.ClosedVisual.SetActive(false);
            }
            if (currentConnection.OpenVisual != null)
            {
                currentConnection.OpenVisual.SetActive(true);
            }

            Transform outwardTransform = currentConnection.Transform;

            RoomsCreated++;

            GameObject room = Instantiate(RoomsCreated < RoomsMax ? Room1.gameObject : EndRoom.gameObject);

            RoomNode roomNode = room.GetComponent<RoomNode>();

            List<Connection> roomConnections = roomNode.Connections.Where(c => ((int)c.ConnectionType & (int)ConnectionType.Inward) != 0).ToList();

            for (int i = 0, ilen = roomConnections.Count; i < ilen; i++)
            {
                if (roomConnections[i].ClosedVisual != null)
                {
                    roomConnections[i].ClosedVisual.SetActive(true);
                }
                if (roomConnections[i].OpenVisual != null)
                {
                    roomConnections[i].OpenVisual.SetActive(false);
                }
            }

            rnd = Random.Range(0, roomConnections.Count);

            Connection roomConnection = roomConnections[rnd];

            Transform inwardTransform = roomConnection.Transform;

            // check for collisions

            //optionalConnections.Remove(currentConnection);
            corridorNode.Connections.Remove(currentConnection);

            //roomConnections.Remove(roomConnection);
            roomNode.Connections.Remove(roomConnection);

            if (roomConnection.ClosedVisual != null)
            {
                roomConnection.ClosedVisual.SetActive(false);
            }
            if (roomConnection.OpenVisual != null)
            {
                roomConnection.OpenVisual.SetActive(true);
            }

            // rotate it...
            room.transform.rotation = Quaternion.Euler(0, (outwardTransform.eulerAngles.y - inwardTransform.eulerAngles.y) + 180, 0);
            // move it into place...
            room.transform.position = outwardTransform.position - (inwardTransform.position - room.transform.position);

            corridorNode.ConnectionPoints.Add(new ConnectionPoint
            {
                NodeFrom = corridorNode,
                NodeTo = roomNode,
                ConnectionFrom = currentConnection,
                ConnectionTo = roomConnection
            });

            //currentNode = roomNode;
            if (RoomsCreated == RoomsMax)
            {
                yield return null;
            }
            else
            {
                yield return StartCoroutine(CreateNewCorridor(roomNode));
            }
        }

        private IEnumerator CreateNewCorridor(DungeonNode roomNode)
        {
            List<Connection> optionalConnections = roomNode.Connections.Where(c => ((int)c.ConnectionType & (int)ConnectionType.Outward) != 0).ToList();

            for (int i = 0, ilen = optionalConnections.Count; i < ilen; i++)
            {
                if (optionalConnections[i].ClosedVisual != null)
                {
                    optionalConnections[i].ClosedVisual.SetActive(true);
                }
                if (optionalConnections[i].OpenVisual != null)
                {
                    optionalConnections[i].OpenVisual.SetActive(false);
                }
            }

            int rnd = Random.Range(0, optionalConnections.Count);

            Connection currentConnection = optionalConnections[rnd];

            if (currentConnection.ClosedVisual != null)
            {
                currentConnection.ClosedVisual.SetActive(false);
            }
            if (currentConnection.OpenVisual != null)
            {
                currentConnection.OpenVisual.SetActive(true);
            }

            Transform outwardTransform = currentConnection.Transform;

            int rndDir = Random.Range(0, 3);

            GameObject corridor = Instantiate((rndDir == 0) ? CorridorStraight.gameObject : rndDir == 1 ? CorridorTurnEast.gameObject : CorridorTurnWest.gameObject);

            CorridorNode corridorNode = corridor.GetComponent<CorridorNode>();

            List<Connection> corridorConnections = corridorNode.Connections.Where(c => ((int)c.ConnectionType & (int)ConnectionType.Inward) != 0).ToList();

            for (int i = 0, ilen = corridorConnections.Count; i < ilen; i++)
            {
                if (corridorConnections[i].ClosedVisual != null)
                {
                    corridorConnections[i].ClosedVisual.SetActive(true);
                }
                if (corridorConnections[i].OpenVisual != null)
                {
                    corridorConnections[i].OpenVisual.SetActive(false);
                }
            }

            rnd = Random.Range(0, corridorConnections.Count);

            Connection corridorConnection = corridorConnections[rnd];

            Transform inwardTransform = corridorConnection.Transform;



            // check for collisions
            //optionalConnections.Remove(currentConnection);
            roomNode.Connections.Remove(currentConnection);

            //corridorConnections.Remove(corridorConnection);
            corridorNode.Connections.Remove(corridorConnection);

            if (corridorConnection.ClosedVisual != null)
            {
                corridorConnection.ClosedVisual.SetActive(false);
            }
            if (corridorConnection.OpenVisual != null)
            {
                corridorConnection.OpenVisual.SetActive(true);
            }

            // rotate it...
            corridor.transform.rotation = Quaternion.Euler(0, (outwardTransform.eulerAngles.y - inwardTransform.eulerAngles.y) + 180, 0);

            // move it into place...
            corridor.transform.position = outwardTransform.position - (inwardTransform.position - corridor.transform.position);

            roomNode.ConnectionPoints.Add(new ConnectionPoint {
                NodeFrom = roomNode,
                NodeTo = corridorNode,
                ConnectionFrom = currentConnection,
                ConnectionTo = corridorConnection
            });

            yield return StartCoroutine(CreateNewRoom(corridorNode));
        }
    }
}