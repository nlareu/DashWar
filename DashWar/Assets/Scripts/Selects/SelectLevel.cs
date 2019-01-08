using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

    // Use this for initialization

    // Update is called once per frame
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
    public void SelectGameMode()
    {
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
}
