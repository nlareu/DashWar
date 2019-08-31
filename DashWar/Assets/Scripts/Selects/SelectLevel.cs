using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private AppController appController;

    private int minNumberPlayers = 2;
    public GameObject minNumPlayersMsg;
    public float numPlayersMsgDelay = 3f;

    public void SelectLvl()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("LoadLevel");
    }

    public void SelectAvatar()
    {
        SceneManager.LoadScene("SelectAvatars");
    }

    /// <summary>
    /// Takes the game to the Game Mode Selection Screen.
    /// </summary>
    public void SelectGameMode()
    {
        // No se permite que se avance de escenea sin haber escogido jugadores, cuando se hayan definido
        // más modalidades de juego, se cambiara el valor de este chequeo
        if (appController.NumberOfPlayers < minNumberPlayers)
        {
            //Debug.Log("Escoger por lo menos dos jugadores");
            minNumPlayersMsg.SetActive(true);
            Invoke("DeativateNumPlayersMsg", numPlayersMsgDelay);
            return;
        }

        SceneManager.LoadScene("SelectGameMode");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Lvl01-Level-01");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Lvl02-Level-02-Snow");
    }

    /// <summary>
    /// Deactivates the message about the minimal quantity of players.
    /// </summary>
    private void DeativateNumPlayersMsg()
    {
        minNumPlayersMsg.SetActive(false);
    }
}
