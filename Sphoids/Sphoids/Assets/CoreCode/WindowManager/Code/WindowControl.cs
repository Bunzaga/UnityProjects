namespace WindowManager
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "WindowControl", menuName = "WindowControl")]
    public class WindowControl : ScriptableObject
    {
        public WindowView WindowView;
        public GameObject Instance;
        public int DrawOrder;
        public bool DestroyOnClose;
    }
}