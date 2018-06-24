using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour {

    private static List<AvatarController> players = new List<AvatarController>();

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Reset static.
            AppController.players.Clear();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    public static int AddPlayer(AvatarController avatar)
    {
        AppController.players.Add(avatar);

        return AppController.players.Count;
    }
    public static List<AvatarController> GetPlayers()
    {
        //Return a copy to prevent reference and not desired changes on the list.
        return new List<AvatarController>(AppController.players);
    }
}
