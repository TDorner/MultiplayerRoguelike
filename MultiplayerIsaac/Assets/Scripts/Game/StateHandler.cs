using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamestates
{
    public class StateHandler
    {
        public enum PLAY_STATE
        {
            PLAY_STATE,
            DECISION_STATE,
            WAIT_STATE
        }

        public enum GAME_STATE
        {
            GAME_STATE,
            LOAD_STATE,
            WAIT_STATE
        }

        public PLAY_STATE playState;
        public GAME_STATE gameState;

        public void SetPlayState(PLAY_STATE _state)
        {
            playState = _state;
        }

        public PLAY_STATE GetPlayState()
        {
            return playState;
        }
    }
}


