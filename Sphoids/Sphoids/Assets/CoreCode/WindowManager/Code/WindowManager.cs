namespace WindowManager
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    // Awake, OnEnable, Start
    public class WindowManager : MonoBehaviour
    {
        public List<WindowControl> WindowControl = new List<WindowControl>();

        private static Dictionary<WindowName, WindowControl> _windowControl = new Dictionary<WindowName, WindowControl>();

        private static Canvas _currentCanvas;

        public Canvas MainCanvas;

        private static WindowManager _this;

        private void Awake()
        {
            if(_this != this && _this != null)
            {
                Destroy(gameObject);
                return;
            }

            _this = this;
            DontDestroyOnLoad(gameObject);

            Debug.Log("Awake(1)");
            _windowControl.Clear();
            for (int i = 0, ilen = WindowControl.Count; i < ilen; i++)
            {
                _windowControl.Add(WindowControl[i].WindowView.WindowName, WindowControl[i]);
            }
            _currentCanvas = MainCanvas;
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable(2)");
        }

        private void Start()
        {
            Debug.Log("Start(3)");
            //WindowOpen(WindowName.SplashScreen);

            //StartCoroutine(ReShowSplashScreen());
        }

        public IEnumerator ReShowSplashScreen()
        {
            yield return new WaitForSeconds(5.0f);
            WindowOpen(WindowName.SplashScreen);
        }

        public static void WindowOpen(WindowName windowName)
        {
            if (!_windowControl.ContainsKey(windowName))
            {
                return;
            }

            WindowView windowView = null;

            if (_windowControl[windowName].Instance == null)
            {
                windowView = Instantiate(_windowControl[windowName].WindowView);
                _windowControl[windowName].Instance = windowView.gameObject;
            }
            else
            {
                windowView = _windowControl[windowName].Instance.GetComponent<WindowView>();
            }

            if (windowView == null) { return; }
            List<IOnWindowShow> windowShow = _windowControl[windowName].Instance.GetComponentsInChildren<IOnWindowShow>().ToList();
            if (windowShow != null && windowShow.Count > 0)
            {
                for (int i = 0, ilen = windowShow.Count; i < ilen; i++)
                {
                    if (windowShow[i] == null) { continue; }
                    windowShow[i].OnWindowShow();
                }
            }

            windowView.transform.SetParent(_currentCanvas.transform, false);

            windowView.Content.SetActive(true);
        }

        public static void WindowClose(WindowName windowName)
        {
            if (!_windowControl.ContainsKey(windowName))
            {
                return;
            }

            if (_windowControl[windowName].Instance == null)
            {
                return;
            }

            WindowView windowView = _windowControl[windowName].Instance.GetComponent<WindowView>();
            if (windowView == null)
            {
                return;
            }

            List<IOnWindowHide> windowHide = _windowControl[windowName].Instance.GetComponentsInChildren<IOnWindowHide>().ToList();
            if (windowHide != null && windowHide.Count > 0)
            {
                for (int i = 0, ilen = windowHide.Count; i < ilen; i++)
                {
                    if (windowHide[i] == null) { continue; }
                    windowHide[i].OnWindowHide();
                }
            }
            windowView.Content.SetActive(false);
            if (_windowControl[windowName].DestroyOnClose)
            {
                Destroy(_windowControl[windowName].Instance);
                _windowControl[windowName].Instance = null
    ;
            }
        }
    }
}