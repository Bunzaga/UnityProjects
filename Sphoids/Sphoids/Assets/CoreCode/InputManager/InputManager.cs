namespace InputManager
{
    using UnityEngine;

    public class InputManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject _leftSymbol;
        [SerializeField]
        private GameObject _rightSymbol;

        private int _inputMask = 0;

        private enum _buttonIndex
        {
            Left = 1,
            Right = 2
        }

        private void Update()
        {

            if (Input.GetMouseButton(0))
            {
                // on down has not been called yet
                if ((_inputMask & (int)_buttonIndex.Left) == 0)
                {
                    _inputMask |= (int)_buttonIndex.Left;
                    Debug.Log("Left Pressed");
                    _leftSymbol.SetActive(true);
                }
                // on down has already been called (button held)
                else
                {

                }
            }
            else
            {
                // on release has not been called yet
                if ((_inputMask & (int)_buttonIndex.Left) == (int)_buttonIndex.Left)
                {
                    _inputMask &= ~(int)_buttonIndex.Left;
                    Debug.Log("Left Released");
                    _leftSymbol.SetActive(false);
                }
                // on release has already been called
                else
                {

                }
            }


            if (Input.GetMouseButton(1))
            {
                // on down has not been called yet
                if ((_inputMask & (int)_buttonIndex.Right) == 0)
                {
                    _inputMask |= (int)_buttonIndex.Right;
                    Debug.Log("Right Pressed");
                    _rightSymbol.SetActive(true);
                }
                // on down has already been called (button held)
                else
                {

                }
            }
            else
            {
                // on release has not been called yet
                if ((_inputMask & (int)_buttonIndex.Right) == (int)_buttonIndex.Right)
                {
                    _inputMask &= ~(int)_buttonIndex.Right;
                    Debug.Log("Right Released");
                    _rightSymbol.SetActive(false);
                }
                // on release has already been called
                else
                {

                }
            }
        }

        public static void OnTap(TapEvent tapEvent)
        {

        }
    }
}