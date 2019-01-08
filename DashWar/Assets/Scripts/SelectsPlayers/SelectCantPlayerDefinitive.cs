using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCantPlayerDefinitive : MonoBehaviour {

    // Use this for initialization
    public Text TextNumPlayers;
    public GameObject buttonSubtract;
    public GameObject buttonAdd;
    public int numberTotalPlayers;
    public GameObject[] selectorPlayers;
    public GameObject[] spritePlayers;
    private bool substract;
    private void Start()
    {
        substract = true;
        TextNumPlayers.text = "" + DataLevel.InstanceDataLevel.GetNumberPlayer();
        for(int i = 0; i<selectorPlayers.Length; i++)
        {
            selectorPlayers[i].SetActive(false);
        }
    }
    public void SetSubstract(bool _substract)
    {
        substract = _substract;
    }
    public bool GetSubstract()
    {
        return substract;
    }
    private void Update()
    {
        ControllerButton();
        CantPlayersController();
    }
    public void ButtonSubtractPlayer()
    {
        if (substract)
        {
            if (DataLevel.InstanceDataLevel != null)
            {
                DataLevel.InstanceDataLevel.SubtractPlayer();
                TextNumPlayers.text = "" + DataLevel.InstanceDataLevel.GetNumberPlayer();
            }
        }
    }
    public void ButtonAddPlayer()
    {
        
        if (DataLevel.InstanceDataLevel != null)
        {
            DataLevel.InstanceDataLevel.AddPlayer();
            TextNumPlayers.text = "" + DataLevel.InstanceDataLevel.GetNumberPlayer();
        }
    }
    public void ControllerButton()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() <= 0)
            {
                buttonSubtract.SetActive(false);
            }
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() > 0)
            {
                buttonSubtract.SetActive(true);
            }
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() >= numberTotalPlayers)
            {
                buttonAdd.SetActive(false);
            }
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() < numberTotalPlayers)
            {
                buttonAdd.SetActive(true);
            }
        }
    }
    public void CantPlayersController()
    {
        if (DataLevel.InstanceDataLevel.GetNumberPlayer() <= selectorPlayers.Length)
        {
            for (int i = 0; i < selectorPlayers.Length; i++)
            {
                selectorPlayers[i].SetActive(false);
                spritePlayers[i].SetActive(false);
            }
            for (int i = 0; i < DataLevel.InstanceDataLevel.GetNumberPlayer(); i++)
            {
                selectorPlayers[i].SetActive(true);
                spritePlayers[i].SetActive(true);
            }
        }
    }
}
