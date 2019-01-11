using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLevel : MonoBehaviour {

    // Use this for initialization
    [HideInInspector]
    public bool pause;
    public static DataLevel InstanceDataLevel;
    public List<AvatarController> avatarsControllers;
    private int numberPlayers;
    private int gameMode;
    //los players representan a cada jugador segun el valor que tengan sera el personaje que elijieron.
    private int player1;
    private int player2;
    private int player3;
    private int player4;
    private int winingScore;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (InstanceDataLevel == null)
        {
            InstanceDataLevel = this;
        }
        else if (InstanceDataLevel != null)
        {
            InstanceDataLevel.gameObject.SetActive(false);
        }
        //numberPlayers = 1;
    }

    public void SetNumberPlayer(int num)
    {
        numberPlayers = num;
    }
    public int GetNumberPlayer()
    {
        return numberPlayers;
    }
    public void AddPlayer()
    {
        numberPlayers++;
    }
    public void SubtractPlayer()
    {
        numberPlayers--;
    }
    public void SetPlayer1(int num)
    {
        player1 = num;
    }
    public int GetPlayer1()
    {
        return player1;
    }
    public void SetPlayer2(int num)
    {
        player2 = num;
    }
    public int GetPlayer2()
    {
        return player2;
    }
    public void SetPlayer3(int num)
    {
        player3 = num;
    }
    public int GetPlayer3()
    {
        return player3;
    }
    public void SetPlayer4(int num)
    {
        player4 = num;
    }
    public int GetPlayer4()
    {
        return player4;
    }
    public void SetGameMode(int _gameMode)
    {
        gameMode = _gameMode;
    }
    public int GetGameMode()
    {
        return gameMode;
    }
    public void SetWiningScore(int _winingScore)
    {
        winingScore = _winingScore;
    }
    public int GetWiningScore()
    {
        return winingScore;
    }
}
