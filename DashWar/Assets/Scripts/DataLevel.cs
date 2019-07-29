using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLevel : MonoBehaviour {

    // Use this for initialization
    [HideInInspector] public bool pause;
    public AppController app;
    public static DataLevel InstanceDataLevel;
    public List<AvatarController> avatarsControllers;
    private int numberPlayers;
    private int gameMode;

    //los players representan a cada jugador segun el valor que tengan sera el personaje que eligieron.
    // Actualización 20190516: Ahora serán una lista
    private int[] playerNumber = new int[GameConstants.MAX_NUMBER_OF_PLAYERS];
    private int winingScore;

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (InstanceDataLevel == null)
        {
            InstanceDataLevel = this;
        }
        else if (InstanceDataLevel != null)
        {
            Debug.Log("YA EXISTIA");
            //InstanceDataLevel.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            /**/
            Destroy(InstanceDataLevel.gameObject);
            InstanceDataLevel = this;

            // Seteando el valor de cada uno de los (por ahora 4) jugadores
            for(int i = 1; i <= GameConstants.MAX_NUMBER_OF_PLAYERS; i++)
            {
                InstanceDataLevel.SetPlayerByNumber(i, 0);
            }

            InstanceDataLevel.SetWiningScore(0);
            InstanceDataLevel.SetGameMode(0);
            InstanceDataLevel.SetNumberPlayer(0);
            InstanceDataLevel.pause = false;

            // Reseteando el tiempo para cancelar la selección del jugador
            if (app != null)
            {
                app.timeCancelPlayer[0] = 0;
                app.timeCancelPlayer[1] = 0;
                app.timeCancelPlayer[2] = 0;
                app.timeCancelPlayer[3] = 0;
            }

            for (int i = 0; i < InstanceDataLevel.avatarsControllers.Count; i++)
            {
                InstanceDataLevel.avatarsControllers[i].SetNotMove(false);
                InstanceDataLevel.avatarsControllers[i].SetRevive(true);
                InstanceDataLevel.avatarsControllers[i].Death = false;
                InstanceDataLevel.avatarsControllers[i].SetScore(0);
            }

            if (app != null)
            {
                app.CancelSelectionAvatarControler();
            }
        }
        //numberPlayers = 1;
    }

    /// <summary>
    /// Returns the value of the requested player.
    /// </summary>
    /// <param name="_playerByNumber">The player to be requested.</param>
    /// <returns>The value of the player.</returns>
    public int GetPlayerByNumber(int _playerByNumber)
    {
        // Esto pudiera causar bugs del tipo Out of Range, hasta el momento no sé que representa el player1234.
        // Hasta ahora lo único que hice fue usar listas y no variables indivuduales. 
        // -1 pq los Arrays comienzan a contarse en 0
        return playerNumber[_playerByNumber - 1];
    }

    /// <summary>
    /// Sets the value of the given player.
    /// </summary>
    /// <param name="_thePlayer">The player to be modified.</param>
    /// <param name="_playerValue">The new value of the player.</param>
    public void SetPlayerByNumber (int _thePlayer, int _playerValue)
    {
        // -1 pq los Arrays comienzan a contarse en 0
        playerNumber[_thePlayer - 1] = _playerValue;
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
