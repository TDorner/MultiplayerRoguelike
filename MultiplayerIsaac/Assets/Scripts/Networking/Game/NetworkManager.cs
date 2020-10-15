using Photon.Pun;
using System.IO;
using UnityEngine;

namespace Setup.Network
{
    public class NetworkManager : MonoBehaviour
    {
        private void Start()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            Debug.LogError("Creating Player..");
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player", "Player"), Vector3.zero, Quaternion.identity);
        }
    }
}

