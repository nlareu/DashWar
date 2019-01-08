using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameMode : MonoBehaviour {

    // Use this for initialization
    private int gameMode;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
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
