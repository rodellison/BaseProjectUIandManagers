
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

namespace Base_Project._Scripts.Utilities
{
    public class MouseUtilities : MonoBehaviour
    {
        private int _screenWidth, _screenHeight;

        public bool forceSoftwareCursor;
        public Texture2D myCursorTexture;

        public enum MouseConfinementMode
        {
            ConfineToScreen,
            NotConfined
        }

        public MouseConfinementMode myMouseConfinementMode;
        
        private void Start()
        {
            InvokeRepeating("RefreshScreenSize", 0f, 2f);
            
            if (myMouseConfinementMode == MouseConfinementMode.ConfineToScreen)
                Cursor.lockState = CursorLockMode.Confined;
            else if (myMouseConfinementMode == MouseConfinementMode.NotConfined)
            {
                Cursor.lockState = CursorLockMode.None;
            }

            if (forceSoftwareCursor)
            {
                var cursorHotspot = new Vector2 (myCursorTexture.width / 2, myCursorTexture.height / 2);
                Cursor.SetCursor(myCursorTexture, cursorHotspot, CursorMode.ForceSoftware);
            }
            
        }


        private void RefreshScreenSize()
        {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
    //        Debug.Log("Screen Dimensions: " + _screenWidth + ", " + _screenHeight);

        }

     
    }
}