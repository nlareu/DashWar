using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour {

    private static int playersCount = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Reset static.
            AppController.playersCount = 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    public static int GetPlayerNumber()
    {
        playersCount++;
        return playersCount;
    }
}
