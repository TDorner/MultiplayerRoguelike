using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

namespace Setup.Network
{

    public class DelayedStartWaitingRoom : MonoBehaviourPunCallbacks
    {
        private PhotonView myPhotonView;

        [SerializeField]
        private int multiplayerSceneIndex;

        [SerializeField]
        private int menuSceneIndex;

        private int playerCount;
        private int roomSize;

        [SerializeField]
        private int minPlayersToStart;

        [SerializeField]
        private Text playerCountText;

        [SerializeField]
        private Text timerText;

        private bool readyToCountDown;
        private bool readyToStart;
        private bool startingGame;

        private float timerToStartGame;
        private float notFullGameTimer;
        private float fullGameTimer;

        [SerializeField]
        private float maxWaitTime;

        [SerializeField]
        private float maxFullGameWaitTime;

        private void Start()
        {
            //Initialize Variables
            myPhotonView = GetComponent<PhotonView>();
            fullGameTimer = maxFullGameWaitTime;
            notFullGameTimer = maxWaitTime;
            timerToStartGame = maxWaitTime;

            PlayerCountUpdate();
        }

        private void PlayerCountUpdate()
        {
            playerCount = PhotonNetwork.PlayerList.Length;
            roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
            playerCountText.text = playerCount + " / " + roomSize;

            if (playerCount == roomSize)
            {
                readyToStart = true;
            }
            else if (playerCount >= minPlayersToStart)
            {
                readyToCountDown = true;
            }
            else
            {
                readyToCountDown = false;
                readyToStart = false;
            }
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player _newPlayer)
        {
            PlayerCountUpdate();

            if (PhotonNetwork.IsMasterClient)
            {
                myPhotonView.RPC("RPC_SendTimer", RpcTarget.Others, timerToStartGame);
            }
            Debug.Log("Player joined room..");
        }


        public override void OnPlayerLeftRoom(Photon.Realtime.Player _otherPlayer)
        {
            PlayerCountUpdate();
        }

        [PunRPC]
        private void RPC_SendTimer(float _time)
        {
            //Syncing timer for players that jopined after timer started countdown
            timerToStartGame = _time;
            notFullGameTimer = _time;

            if(_time < fullGameTimer)
            {
                fullGameTimer = _time;
            }
        }
        private void Update()
        {
            WaitingForMorePlayers();
        }

        private void WaitingForMorePlayers()
        {
            if (playerCount <= 1)
            {
                ResetTimer();
            }

            if (readyToStart)
            {
                fullGameTimer -= Time.deltaTime;
                timerToStartGame = fullGameTimer;
            }
            else if (readyToCountDown)
            {
                notFullGameTimer -= Time.deltaTime;
                timerToStartGame = notFullGameTimer;
            }

            string tempTimer = string.Format("{0:00}", timerToStartGame);
            timerText.text = tempTimer;

            if (timerToStartGame <= 0f)
            {
                if (startingGame)
                {
                    return;
                }
                StartGame();
            }
        }

        public void StartGame()
        {
            startingGame = true;

            if (!PhotonNetwork.IsMasterClient)
            {
                return;
            }
            Debug.Log("Starting game..");
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }

        public void ResetTimer()
        {
            Debug.Log("Resetting timer..");
            timerToStartGame = maxWaitTime;
            notFullGameTimer = maxWaitTime;
            fullGameTimer = maxFullGameWaitTime;
        }

        public void DelayCancel()
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene(menuSceneIndex);
        }
    }
}
