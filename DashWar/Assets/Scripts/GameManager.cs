using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] spawnerPlayer;
	void Start () {
        StartLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartLevel()
    {
        for (int i = 0; i < spawnerPlayer.Length; i++)
        {
            spawnerPlayer[i].SetActive(false);
        }
        if (DataLevel.InstanceDataLevel != null)
        {
            for (int j = 0; j < DataLevel.InstanceDataLevel.GetNumberPlayer(); j++)
            {
                spawnerPlayer[j].SetActive(true);
            }
        }
    }
}
