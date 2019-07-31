using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DunGen
{
    public class Connection : MonoBehaviour
    {
        [EnumFlagsAttribute]
        public ConnectionType ConnectionType;

        public GameObject OpenVisual;
        public GameObject ClosedVisual;
        public Transform Transform { get { return gameObject.transform; } private set { } }
    }
}