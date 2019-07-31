namespace WindowManager
{
    using System.Collections;
    using UnityEngine;
    public class WindowCloseAfterTime : MonoBehaviour
    {
        public WindowView WindowView;

        public float OpenDuration;

        private void OnEnable()
        {
            if (WindowView == null)
            {
                WindowView = GetComponentInChildren<WindowView>();
            }
            if (WindowView == null) { return; }
            StartCoroutine(CloseAfterTime());
        }

        private IEnumerator CloseAfterTime()
        {
            float endTime = Time.time + OpenDuration;

            while (Time.time < endTime)
            {
                yield return null;
            }

            WindowManager.WindowClose(WindowView.WindowName);
        }
    }
}