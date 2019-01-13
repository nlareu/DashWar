using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject camvasPause;
    public GameManager gameManager;
    public AppController app;
	public void Resume()
    {
        Time.timeScale = 1;
        camvasPause.SetActive(false);
        if (DataLevel.InstanceDataLevel != null)
        {
            DataLevel.InstanceDataLevel.pause = false;
        }
    }
    public void Restart()
    {
        app.RestartParty();
        gameManager.Restart();
        Resume();
    }
}
