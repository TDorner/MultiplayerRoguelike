using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Keys
{
    public class PlayerInput : MonoBehaviour
    {
        public bool wPressed = false;
        public bool aPressed = false;
        public bool sPressed = false;
        public bool dPressed = false;

        public bool actionPressed = false;
        
        void Update()
        {
            checkPlayerInput();
        }

        public void checkPlayerInput()
        {
            if (Input.GetKey(KeyCode.W))
            {
                wPressed = true;
            }
            else wPressed = false;
            if (Input.GetKey(KeyCode.A))
            {
                aPressed = true;
            }
            else aPressed = false;
            if (Input.GetKey(KeyCode.S))
            {
                sPressed = true;
            }
            else sPressed = false;
            if (Input.GetKey(KeyCode.D))
            {
                dPressed = true;
            }
            else dPressed = false;
            if (Input.GetMouseButton(0))
            {
                actionPressed = true;
            }
            else actionPressed = false;
        }
    }
}
