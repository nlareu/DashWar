using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameMode : MonoBehaviour {

    private int gameMode;

    public void SetGameMode(int _gameMode)
    {
        gameMode = _gameMode;
    }

    public int GetGameMode()
    {
        return gameMode;
    }

    public void SetGameModeDataLevel(int _gameMode)
    {
        DataLevel.InstanceDataLevel.SetGameMode(_gameMode);
    }
}
