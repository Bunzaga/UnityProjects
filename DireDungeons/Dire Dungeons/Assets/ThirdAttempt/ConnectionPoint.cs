using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunGen
{
    [System.Serializable]
    public class ConnectionPoint
    {
        public DungeonNode OtherDungeonNode;
        public Connection OtherConnection;
        public Connection SelfConnection;
    }
}