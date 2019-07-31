using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunGen
{
    [System.Serializable]
    public class ConnectionPoint
    {
        public DungeonNode NodeFrom;
        public DungeonNode NodeTo;

        public Connection ConnectionFrom;
        public Connection ConnectionTo;
    }
}