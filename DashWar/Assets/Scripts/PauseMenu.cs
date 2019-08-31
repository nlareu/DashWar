using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // References
    public GameObject camvasPause;
    public GameManager gameManager;
    public AppController app;

    [Header("Escenas a cargar")]
    public string mainMenu = "Menu";
    public string avatarSelection = "SelectAvatars";
    public string levelSelection = "SelectLevel";

    /// <summary>
    /// Resumes the game from the pause menu.
    /// </summary>
	public void Resume()
    {
        Time.timeScale = 1;
        camvasPause.SetActive(false);

        if (DataLevel.InstanceDataLevel != null)
        {
            DataLevel.InstanceDataLevel.Pause = false;
        }
    }

    /// <summary>
    /// Resets the current match.
    /// </summary>
    public void Restart()
    {
        app.RestartParty();
        gameManager.Restart();
        Resume();
    }

    /// <summary>
    /// Takes the game from the pause menu to the Main Menu.
    /// </summary>
    public void MainMenu()
    {
        if(DataLevel.InstanceDataLevel != null)
        {            
            //DataLevel.InstanceDataLevel = null;
            Destroy(DataLevel.InstanceDataLevel.gameObject);
        }

        SceneManager.LoadScene(mainMenu);
    }

    /// <summary>
    /// Takes the game from the pause menu to the Avatar Selection Menu.
    /// </summary>
    public void SelectorAvatarScreen()
    {
        if (DataLevel.InstanceDataLevel != null)
        {            
            //DataLevel.InstanceDataLevel = null;
            Destroy(DataLevel.InstanceDataLevel.gameObject);
        }

        SceneManager.LoadScene(avatarSelection);
    }

    /// <summary>
    /// Takes the game from the pause menu to the Level Selection Menu.
    /// </summary>
    public void SelectorLevelScreen()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            DataLevel.InstanceDataLevel.Pause = false;
        }

        app.RestartParty();
        gameManager.Restart();

        SceneManager.LoadScene(levelSelection);
    }
}
