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
    public void MainMenu()
    {
        if(DataLevel.InstanceDataLevel != null)
        {
            
            //DataLevel.InstanceDataLevel = null;
            Destroy(DataLevel.InstanceDataLevel.gameObject);
        }
        SceneManager.LoadScene("Menu");
    }
    public void SelectorAvatarScreen()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            
            //DataLevel.InstanceDataLevel = null;
            Destroy(DataLevel.InstanceDataLevel.gameObject);
        }
        SceneManager.LoadScene("SelectAvatars");
    }
    public void SelectorLevelScreen()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
           
            //DataLevel.InstanceDataLevel = null;
            Destroy(DataLevel.InstanceDataLevel.gameObject);
        }
        SceneManager.LoadScene("SelectLevel");
    }
}
