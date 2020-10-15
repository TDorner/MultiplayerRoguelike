using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setup.Dungeon
{
    public class Room : MonoBehaviour
    {
        public enum ROOM_CONTENT
        {
            PLAYERSPAWN,
            TREASURE,
            ENEMY,
            SHOP,
            EMPTY
        }

        public ROOM_CONTENT roomContent;

        public int x;
        public int z;

        public int roomSize = 100;

        public void InitiateSetUp(int _z, int _x, ROOM_CONTENT _content)
        {
            z = _z;
            x = _x;

            roomContent = _content;

            InitiateRoom(roomContent);
            InitiateRoomPosition();

        }

        private void InitiateRoom(ROOM_CONTENT _content)
        {

            InitiateRoomContent(_content);
            InitiateRoomPosition();
        }

        private void InitiateRoomPosition()
        {
            this.gameObject.GetComponent<Transform>().localPosition = new Vector3(roomSize * x, transform.localPosition.y, roomSize*z);
        }

        public void InitiateRoomContent(ROOM_CONTENT _content)
        {
            DecideRoomContent();

        }

        private void DecideRoomContent()
        {
            int rng = Random.Range(1, 4);

            switch (rng)
            {
                case 1:
                    roomContent = ROOM_CONTENT.TREASURE;
                    return;
                case 2:
                    roomContent = ROOM_CONTENT.ENEMY;
                    return;
                case 3:
                    roomContent = ROOM_CONTENT.SHOP;
                    return;
                default:
                    roomContent = ROOM_CONTENT.EMPTY;
                    return;
            }
        }

        public void SpawnRoomContent()
        {
            switch (roomContent)
            {
                case ROOM_CONTENT.TREASURE:
                    //Do something
                    Debug.Log("This Room contains a Chest");
                    return;
                case ROOM_CONTENT.ENEMY:
                    //Do something
                    Debug.Log("This Room contains Enemies");
                    return;
                case ROOM_CONTENT.SHOP:
                    //Do something
                    Debug.Log("This Room contains a Shop");
                    return;
                default:
                    Debug.Log("This Room stays empty");
                    return;
            }
        }


        public void ChangeRoomContentToPlayerSpawn()
        {
            roomContent = ROOM_CONTENT.PLAYERSPAWN;
        }
    }

}