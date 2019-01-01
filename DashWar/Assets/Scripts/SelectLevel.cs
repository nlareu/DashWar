using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
    public void Level1()
    {
        SceneManager.LoadScene("Level-01_TL");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level-02-Snow_TL");
    }
}
