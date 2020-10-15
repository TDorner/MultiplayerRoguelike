using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Advancement
{
    public class PlayerAdvancement : MonoBehaviour
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
            if (stateHandler.playState == Gamestates.StateHandler.PLAY_STATE.DECISION_STATE)
            {
                ChooseWay();
                LockDecision();
            }
        }

        private void ChooseWay()
        {
            if (playerInput.wPressed)
            {
                //-X up
            }
            else if (playerInput.sPressed)
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

        private void LockDecision()
        {
            if (playerInput.actionPressed)
            {
                //Do something
            }
        }
    }

}