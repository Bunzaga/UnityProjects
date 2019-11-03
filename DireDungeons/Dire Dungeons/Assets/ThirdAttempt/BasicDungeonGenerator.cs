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

        public string PlacedNodeMask = "PlacedNode";
        public LayerMask CollisionMask;

        public GameObject boxPrefab;

        private void Awake()
        {
            StartCoroutine(CreateDungeon());
           // CollisionMask = LayerMask.NameToLayer(PlacedNodeMask);
        }

        private IEnumerator CreateDungeon()
        {
            GameObject enterGameObject = Instantiate(StartRoom.gameObject);
            DungeonNode currentNode = enterGameObject.GetComponent<DungeonNode>();

            RoomsCreated = 1;

            enterGameObject.name = "Room 1";

            SetNodeCollisionMask(currentNode, PlacedNodeMask);

            yield return StartCoroutine(CreateNewSegment(currentNode, true));

            currentNode = enterGameObject.GetComponent<DungeonNode>();
            AddNodesToRoot(currentNode);
            yield return null;
        }

        private void AddNodesToRoot(DungeonNode node)
        {
            node.transform.SetParent(Root);
            for (int i = 0, ilen = node.ToConnections.Count; i < ilen; i++)
            {
                if (node.ToConnections[i].OtherDungeonNode != null)
                {
                    AddNodesToRoot(node.ToConnections[i].OtherDungeonNode);
                }
            }
        }

        private void SetNodeCollisionMask(DungeonNode dungeonNode, string mask)
        {
            for (int i = 0, ilen = dungeonNode.Colliders.Count; i < ilen; i++)
            {
                Collider col = dungeonNode.Colliders[i];
                col.gameObject.layer = LayerMask.NameToLayer(mask);
            }
        }

        private IEnumerator CreateNewSegment(DungeonNode fromNode, bool isRoom)
        {
            List<Connection> fromConnections = fromNode.Connections.Where(c => ((int)c.ConnectionType & (int)ConnectionType.Outward) != 0).ToList();

            for (int i = 0, ilen = fromConnections.Count; i < ilen; i++)
            {
                if (fromConnections[i].ClosedVisual != null)
                {
                    if (!fromConnections[i].ClosedVisual.activeInHierarchy)
                    {
                        fromConnections[i].ClosedVisual.SetActive(true);
                    }
                }
                if (fromConnections[i].OpenVisual != null)
                {
                    if (fromConnections[i].OpenVisual.activeInHierarchy)
                    {
                        fromConnections[i].OpenVisual.SetActive(false);
                    }
                }
            }

            int rnd = Random.Range(0, fromConnections.Count);

            Connection fromConnection = fromConnections[rnd];

            fromNode.Connections.Remove(fromConnection);

            Transform outwardTransform = fromConnection.Transform;

            GameObject toGo;
            if (isRoom)
            {
                int rndDir = Random.Range(0, 3);
                toGo = Instantiate((rndDir == 0) ? CorridorStraight.gameObject : rndDir == 1 ? CorridorTurnEast.gameObject : CorridorTurnWest.gameObject);
                toGo.name = "Corridor " + RoomsCreated;
            }
            else
            {
                toGo = Instantiate(RoomsCreated < RoomsMax-1 ? Room1.gameObject : EndRoom.gameObject);
                toGo.name = "Room " + (RoomsCreated + 1);
            }

            toGo.transform.position = fromNode.transform.position;

            DungeonNode toNode = toGo.GetComponent<DungeonNode>();

            List<Connection> toConnections = toNode.Connections.Where(c => ((int)c.ConnectionType & (int)ConnectionType.Inward) != 0).ToList();

            for (int i = 0, ilen = toConnections.Count; i < ilen; i++)
            {
                if (toConnections[i].ClosedVisual != null)
                {
                    if (!toConnections[i].ClosedVisual.activeInHierarchy)
                    {
                        toConnections[i].ClosedVisual.SetActive(true);
                    }
                }
                if (toConnections[i].OpenVisual != null)
                {
                    if (!toConnections[i].OpenVisual.activeInHierarchy)
                    {
                        toConnections[i].OpenVisual.SetActive(false);
                    }
                }
            }

            rnd = Random.Range(0, toConnections.Count);

            Connection toConnection = toConnections[rnd];

            Transform inwardTransform = toConnection.Transform;

            // rotate it...
            //RotateToEulerY(toGo.transform, (outwardTransform.eulerAngles.y - inwardTransform.eulerAngles.y) + 180);
            yield return StartCoroutine(RotateToEulerYOverTime(toGo.transform, (outwardTransform.eulerAngles.y - inwardTransform.eulerAngles.y) + 180));
            // move it into place...
            //MoveToPosition(toGo.transform, outwardTransform.position - (inwardTransform.position - toGo.transform.position));
            yield return StartCoroutine(MoveToPositionOverTime(toGo.transform, outwardTransform.position - (inwardTransform.position - toGo.transform.position)));

            // check for collisions
            if (NewNodeCollidesWithDungeon(toNode))
            {
                Debug.Log("collision found, do something...");
                DungeonNode goBackNode = fromNode.FromConnections[0].OtherDungeonNode;
                goBackNode.Connections.Add(fromNode.FromConnections[0].OtherConnection);
                goBackNode.ToConnections.Remove(fromNode.FromConnections[0]);
                Destroy(toNode.gameObject);
                Destroy(fromNode.gameObject);

                if (isRoom)
                {
                    RoomsCreated--;
                    yield return StartCoroutine(CreateNewSegment(goBackNode, false));
                }
                else
                {
                    yield return StartCoroutine(CreateNewSegment(goBackNode, true));
                }
                yield break;
            }
            else
            {
                SetNodeCollisionMask(toNode, PlacedNodeMask);
            }
            // if collision check passed...

            toNode.Connections.Remove(toConnection);

            if (fromConnection.ClosedVisual != null)
            {
                fromConnection.ClosedVisual.SetActive(false);
            }
            if (fromConnection.OpenVisual != null)
            {
                fromConnection.OpenVisual.SetActive(true);
            }

            if (toConnection.ClosedVisual != null)
            {
                toConnection.ClosedVisual.SetActive(false);
            }
            if (toConnection.OpenVisual != null)
            {
                toConnection.OpenVisual.SetActive(true);
            }

            fromNode.ToConnections.Add(new ConnectionPoint {
                OtherDungeonNode= toNode,
                OtherConnection = toConnection,
                SelfConnection = fromConnection
            });

            toNode.FromConnections.Add(new ConnectionPoint
            {
                OtherDungeonNode = fromNode,
                OtherConnection = fromConnection,
                SelfConnection = fromConnection
            });

            if (!isRoom)
            {
                RoomsCreated++;
            }

            if (RoomsCreated == RoomsMax)
            {
                
                yield break;
            }

            yield return StartCoroutine(CreateNewSegment(toNode, !isRoom));
        }

        private bool NewNodeCollidesWithDungeon(DungeonNode dungeonNode)
        {
            Vector3 center;
            Vector3 halfExtents;
            Collider[] results = new Collider[10];
            Quaternion orientation = Quaternion.identity;
                
            for (int i = 0, ilen = dungeonNode.Colliders.Count; i < ilen; i++)
            {
                Collider col = dungeonNode.Colliders[i];

                switch (col.GetType().Name)
                {
                    case nameof(BoxCollider):

                        center = col.bounds.center;
                        Debug.LogFormat("Center:{0}, {1}, {2}", center.x, center.y, center.z);
                        halfExtents = dungeonNode.transform.TransformDirection(col.bounds.extents);
                        orientation = dungeonNode.transform.rotation;

                        var box = Instantiate(boxPrefab, center, orientation);
                        box.transform.localScale = halfExtents * 2;
                        box.transform.SetParent(col.transform.parent, true);

                        for(int j = 0, jlen = results.Length; j < jlen; j++)
                        {
                            results[j] = null;
                        }

                        int collisions = Physics.OverlapBoxNonAlloc(center, col.bounds.extents, results, orientation, CollisionMask, QueryTriggerInteraction.Collide);
                        if (collisions > 0)
                        {
                            for (int hitIndex = 0, resultLen = results.Length; hitIndex < resultLen; hitIndex++)
                            {
                                if (results[hitIndex] != null)
                                {
                                    Debug.LogFormat("Checking Result[{0}]", hitIndex);
                                    Debug.Log(dungeonNode.gameObject.name + ": There was a hit! " + hitIndex);
                                    Debug.Log(results[hitIndex].transform.root.name);
                                    return true;
                                }
                                else
                                {
                                }
                            }
                        }
                        break;

                    case nameof(SphereCollider):
                        break;
                }
                
            }
            return false;
        }

        private void RotateToEulerY(Transform trans, float eulerY)
        {
            if (eulerY > 180)
            {
                eulerY = 360 - eulerY;
            }
            if (eulerY < -180)
            {
                eulerY = 360 + eulerY;
            }

            trans.rotation = Quaternion.Euler(0, eulerY, 0);
        }

        private IEnumerator RotateToEulerYOverTime(Transform trans, float eulerY)
        {
            float start = Mathf.RoundToInt(trans.rotation.eulerAngles.y);
            float goal = Mathf.RoundToInt(eulerY);

            if (eulerY > 180)
            {
                eulerY = 360 - eulerY;
            }
            if (eulerY < -180)
            {
                eulerY = 360 + eulerY;
            }

            if (Mathf.Abs(start - goal) < .1f)
            {
                trans.rotation = Quaternion.Euler(0, goal, 0);
                yield break;
            }

            float current = start;
            float timePassed = 0.0f;
            float desiredTime = 1.0f;

            while (timePassed < desiredTime)
            {
                current = Mathf.LerpAngle(start, goal, timePassed / desiredTime);
                trans.rotation = Quaternion.Euler(0, current, 0);
                timePassed += Time.deltaTime;
                yield return null;
            }
            trans.rotation = Quaternion.Euler(0, goal, 0);
        }

        private void MoveToPosition(Transform trans, Vector3 pos)
        {
            trans.position = pos;
        }

        private IEnumerator MoveToPositionOverTime(Transform trans, Vector3 pos)
        {
            Vector3 start = trans.position;
            Vector3 goal = pos;

            if (Vector3.Distance(start, goal) < .1f)
            {
                trans.position = goal;
                yield break;
            }

            Vector3 current = start;
            float timePassed = 0.0f;
            float desiredTime = 1.0f;

            while (timePassed < desiredTime)
            {
                current = Vector3.Lerp(start, goal, timePassed / desiredTime);
                trans.position = current;
                timePassed += Time.deltaTime;
                yield return null;
            }
            trans.position = goal;
        }
    }
}