using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Fight
{
    public class PlayerMovement : MonoBehaviour
    {
        Keys.PlayerInput playerInput;
        Transform playerTransform;
        Gamestates.StateHandler stateHandler;

        void Start()
        {
            playerTransform = this.gameObject.GetComponent<Transform>();
            playerInput = this.gameObject.GetComponent<Keys.PlayerInput>();
        }

        void Update()
        {
            if (stateHandler.playState == Gamestates.StateHandler.PLAY_STATE.PLAY_STATE)
            {
                Move();
                Act();
            }
        }

        private void Move()
        {
            if (playerInput.wPressed)
            {
                //-X up
                playerTransform.position = new Vector3();
            }
            else if(playerInput.sPressed)
            {
                //+X down

            }
            else if (playerInput.aPressed)
            {
                //-Z left

            }
            else if (playerInput.dPressed)
            {
                //+Z right

            }
        }

        private void Act()
        {
            if (playerInput.actionPressed)
            {
                //Do something
            }
        }
    }

}