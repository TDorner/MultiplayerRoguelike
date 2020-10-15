using UnityEngine;

namespace Setup.Dungeon
{
    public class DungeonGenerator : MonoBehaviour
    {
        public int rows;
        public int columns;

        public GameObject room;

        public GameObject[,] rooms;

        void Start()
        {
            rooms = new GameObject[rows, columns];
            Debug.Log("The dungeon will be sized " + rows + " | " + columns + " totalling " + columns * rows + " rooms");
            GenerateDungeon();
        }

        private void GenerateDungeon()
        {
            SpawnEmptyRooms(rows, columns, this.gameObject.GetComponent<Transform>());
        }

        private void SpawnEmptyRooms(int _rows, int _columns, Transform _parent)
        {
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _columns; c++)
                {
                    SetUpRoom(r, c, _parent);
                }
            }
            rooms[0, 0].GetComponent<Room>().ChangeRoomContentToPlayerSpawn();
            rooms[0,0].name = "dungeon_room_" + 0 + "|" + 0 + "_playerSpawn";
        }

        private void SetUpRoom(int _r, int _c, Transform _parent)
        {
            Debug.Log("Creating Room " + _r + " | " + _c);
            GameObject newRoom = GameObject.Instantiate(room);
            newRoom.GetComponent<Transform>().parent = _parent;
            newRoom.name = "dungeon_room_" + _r + "|" + _c + "_empty";

            //Add Script and Initiate Setup
            newRoom.AddComponent<Room>();
            Room roomScript = newRoom.GetComponent<Room>();
            roomScript.InitiateSetUp(_r, _c, Room.ROOM_CONTENT.EMPTY);

            rooms[_r, _c] = newRoom;
        }
    }
}
