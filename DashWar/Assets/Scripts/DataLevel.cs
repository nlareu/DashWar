using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLevel : MonoBehaviour {

    // Use this for initialization
    public static DataLevel InstanceDataLevel;
    private int numberPlayers;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (InstanceDataLevel == null)
        {
            InstanceDataLevel = this;
        }
        else if(InstanceDataLevel != null)
        {
            InstanceDataLevel.gameObject.SetActive(false);
        }
    }

    public void SetNumberPlayer(int num)
    {
        numberPlayers = num;
    }
    public int GetNumberPlayer()
    {
        return numberPlayers;
    }
    public void AddPlayer()
    {
        numberPlayers++;
    }
    public void SubtractPlayer()
    {
        numberPlayers--;
    }
}
