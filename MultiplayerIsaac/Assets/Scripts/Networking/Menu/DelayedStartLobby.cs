using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Setup.Network
{
    public class DelayedStartLobby : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private GameObject delayStartButton;
        [SerializeField]
        private GameObject delayCancelButton;
        [SerializeField]
        private int roomSize;

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            delayStartButton.SetActive(true);
        }

        public void DelayedStart()
        {
            delayStartButton.SetActive(false);
            delayCancelButton.SetActive(true);
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("Joining random room..");
        }

        public override void OnJoinRandomFailed(short _returnCode, string _message)
        {
            Debug.Log("Joining Random Room failed..");
            CreateRoom();
        }

        private void CreateRoom()
        {
            Debug.Log("Creating room..");
            int randomRoomNumber = Random.Range(0, 10);
            RoomOptions roomOptions = new RoomOptions()
            {
                IsVisible = true,
                IsOpen = true,
                MaxPlayers = (byte)roomSize
            };
            PhotonNetwork.CreateRoom("Room " + randomRoomNumber, roomOptions);
            Debug.Log("Created room Nr. " + randomRoomNumber);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log("Creating room failed.. trying again!");
            CreateRoom();
        }

        public void DelayCancel()
        {
            delayStartButton.SetActive(true);
            delayCancelButton.SetActive(false);
            PhotonNetwork.LeaveRoom();
            Debug.Log("Leaving room..");
        }
    }
}
