using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DunGen
{
    public class DungeonNode : MonoBehaviour
    {
        public List<ConnectionPoint> FromConnections = new List<ConnectionPoint>();
        public List<ConnectionPoint> ToConnections = new List<ConnectionPoint>();

        public List<Connection> Connections;
        public List<Connection> OptionalConnections;

        public List<Collider> Colliders = new List<Collider>();
    }
}