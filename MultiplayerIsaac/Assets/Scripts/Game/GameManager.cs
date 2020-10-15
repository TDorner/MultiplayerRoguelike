using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Stats;
using Gamestates;

public class GameManager : MonoBehaviour
{
    public int numberPlayers;
    public Player.Stats.Player[] players;
    public StateHandler stateHandler;

    void Start()
    {
        stateHandler = new StateHandler();

    }

    void Update()
    {
        
    }

    public void SetPlayerNumber(int _number)
    {
        numberPlayers = _number;
    }

    public void CreatePlayerCharacters()
    {
        for (int i = 0; i >= players.Length; i++)
        {
            Player.Stats.Player player = new Player.Stats.Player(); 
        }
    }
}
