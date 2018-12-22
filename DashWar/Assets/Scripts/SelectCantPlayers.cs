using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCantPlayers : MonoBehaviour {

    // Use this for initialization
    public Text TextNumPlayers;
    public GameObject buttonSubtract;
    public GameObject buttonAdd;
    public int numberTotalPlayers;
    private void Start()
    {
        TextNumPlayers.text = "" + DataLevel.InstanceDataLevel.GetNumberPlayer();
    }
    private void Update()
    {
        ControllerButton();
    }
    public void ButtonSubtractPlayer()
    {
        if(DataLevel.InstanceDataLevel != null)
        {
            DataLevel.InstanceDataLevel.SubtractPlayer();
            TextNumPlayers.text = ""+DataLevel.InstanceDataLevel.GetNumberPlayer();
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
        if(DataLevel.InstanceDataLevel != null)
        {
            if(DataLevel.InstanceDataLevel.GetNumberPlayer() <= 0)
            {
                buttonSubtract.SetActive(false);
            }
            if(DataLevel.InstanceDataLevel.GetNumberPlayer() > 0)
            {
                buttonSubtract.SetActive(true);
            }
            if(DataLevel.InstanceDataLevel.GetNumberPlayer() >= numberTotalPlayers)
            {
                buttonAdd.SetActive(false);
            }
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() < numberTotalPlayers)
            {
                buttonAdd.SetActive(true);
            }
        }
    }
}
