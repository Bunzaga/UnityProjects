using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DunGen
{
    public class DungeonNode : MonoBehaviour
    {
        public List<ConnectionPoint> ConnectionPoints = new List<ConnectionPoint>();

        public List<Connection> Connections;
        public List<Connection> OptionalConnections;
    }
}