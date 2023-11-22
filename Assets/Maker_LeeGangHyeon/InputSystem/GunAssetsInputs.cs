using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class GunAssetsInputs : MonoBehaviour
	{
		public bool A;
        public bool D;
        public bool mouseLeft;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnKeyBoardA(InputValue value)
		{
            KeyBoardAInput(value.isPressed);
		}

        public void OnKeyBoardD(InputValue value)
        {
            KeyBoardDInput(value.isPressed);
        }

        public void OnMouseLeft(InputValue value)
		{
            MouseLeftInput(value.isPressed);
		}

        /*public void OnMouseRight(InputValue value)
		{
            MouseRightInput(value.isPressed);
        }*/
#endif

        public void KeyBoardDInput(bool isKeyBoardD)
        {
            D = isKeyBoardD;
        }


        public void KeyBoardAInput(bool isKeyBoardA)
		{
			A = isKeyBoardA;
		} 

        public void MouseLeftInput(bool isMouseLeft)
        {
            mouseLeft = isMouseLeft;
        }

        /*public void MouseRightInput(bool isMouseRight)
        {
            mouseRight = isMouseRight;
        }*/
    }
	
}