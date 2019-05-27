using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour {

    // Use this for initialization
    private int turn;
    public Text TextTurn;
    public int TOP_JUGADORES;
    public GameObject[] TextCharacter1;
    public GameObject[] TextCharacter2;
    public GameObject[] TextCharacter3;
    public GameObject[] TextCharacter4;
	void Start () {
        turn = 1;
        TextTurn.text = "Elije Jugador:" + turn;
	}
	
	// Update is called once per frame
	void Update () {
        CheckNumPlayers();
	}
    public void CheckNumPlayers()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() == 0)
            {
                TextCharacter1[0].SetActive(false);
                TextCharacter2[0].SetActive(false);
                TextCharacter3[0].SetActive(false);
                TextCharacter4[0].SetActive(false);

                TextCharacter1[1].SetActive(false);
                TextCharacter2[1].SetActive(false);
                TextCharacter3[1].SetActive(false);
                TextCharacter4[1].SetActive(false);

                TextCharacter1[2].SetActive(false);
                TextCharacter2[2].SetActive(false);
                TextCharacter3[2].SetActive(false);
                TextCharacter4[2].SetActive(false);

                TextCharacter1[3].SetActive(false);
                TextCharacter2[3].SetActive(false);
                TextCharacter3[3].SetActive(false);
                TextCharacter4[3].SetActive(false);

            }
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() == 1)
            {

                TextCharacter1[1].SetActive(false);
                TextCharacter2[1].SetActive(false);
                TextCharacter3[1].SetActive(false);
                TextCharacter4[1].SetActive(false);

                TextCharacter1[2].SetActive(false);
                TextCharacter2[2].SetActive(false);
                TextCharacter3[2].SetActive(false);
                TextCharacter4[2].SetActive(false);

                TextCharacter1[3].SetActive(false);
                TextCharacter2[3].SetActive(false);
                TextCharacter3[3].SetActive(false);
                TextCharacter4[3].SetActive(false);
            }
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() == 2)
            {
                TextCharacter1[2].SetActive(false);
                TextCharacter2[2].SetActive(false);
                TextCharacter3[2].SetActive(false);
                TextCharacter4[2].SetActive(false);

                TextCharacter1[3].SetActive(false);
                TextCharacter2[3].SetActive(false);
                TextCharacter3[3].SetActive(false);
                TextCharacter4[3].SetActive(false);
            }
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() == 3)
            {
                TextCharacter1[3].SetActive(false);
                TextCharacter2[3].SetActive(false);
                TextCharacter3[3].SetActive(false);
                TextCharacter4[3].SetActive(false);
            }
            if (DataLevel.InstanceDataLevel.GetNumberPlayer() == 4)
            {

            }
        }
    }

    public void SelectCharacter1()
    {
        if(DataLevel.InstanceDataLevel != null)
        {
            if(turn == 4 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 4)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(4, 0);
                turn++;
                TextCharacter1[0].SetActive(false);
                TextCharacter1[1].SetActive(false);
                TextCharacter1[2].SetActive(false);
                TextCharacter1[3].SetActive(true);
            }
            if(turn == 3 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 3)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(3, 0);
                turn++;
                TextCharacter1[0].SetActive(false);
                TextCharacter1[1].SetActive(false);
                TextCharacter1[2].SetActive(true);
                TextCharacter1[3].SetActive(false);
            }
            if(turn == 2 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 2)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(2, 0);
                turn++;
                TextCharacter1[0].SetActive(false);
                TextCharacter1[1].SetActive(true);
                TextCharacter1[2].SetActive(false);
                TextCharacter1[3].SetActive(false);
            }
            if(turn == 1 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 1)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(1, 0);
                turn++;
                TextCharacter1[0].SetActive(true);
                TextCharacter1[1].SetActive(false);
                TextCharacter1[2].SetActive(false);
                TextCharacter1[3].SetActive(false);
            }
        }
        TextTurn.text = "Elije Jugador:" + turn;
    }

    public void SelectCharacter2()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            if (turn == 4 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 4)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(4, 1);
                turn++;
                TextCharacter2[0].SetActive(false);
                TextCharacter2[1].SetActive(false);
                TextCharacter2[2].SetActive(false);
                TextCharacter2[3].SetActive(true);
            }
            if (turn == 3 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 3)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(3, 1);
                turn++;
                TextCharacter2[0].SetActive(false);
                TextCharacter2[1].SetActive(false);
                TextCharacter2[2].SetActive(true);
                TextCharacter2[3].SetActive(false);
            }
            if (turn == 2 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 2)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(2, 1);
                turn++;
                TextCharacter2[0].SetActive(false);
                TextCharacter2[1].SetActive(true);
                TextCharacter2[2].SetActive(false);
                TextCharacter2[3].SetActive(false);
            }
            if (turn == 1 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 1)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(1, 1);
                turn++;
                TextCharacter2[0].SetActive(true);
                TextCharacter2[1].SetActive(false);
                TextCharacter2[2].SetActive(false);
                TextCharacter2[3].SetActive(false);
            }
        }
        TextTurn.text = "Elije Jugador:" + turn;
    }

    public void SelectCharacter3()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            if (turn == 4 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 4)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(4, 2);
                turn++;
                TextCharacter3[0].SetActive(false);
                TextCharacter3[1].SetActive(false);
                TextCharacter3[2].SetActive(false);
                TextCharacter3[3].SetActive(true);

            }
            if (turn == 3 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 3)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(3, 2);
                turn++;
                TextCharacter3[0].SetActive(false);
                TextCharacter3[1].SetActive(false);
                TextCharacter3[2].SetActive(true);
                TextCharacter3[3].SetActive(false);
            }
            if (turn == 2 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 2)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(2, 2);
                turn++;
                TextCharacter3[0].SetActive(false);
                TextCharacter3[1].SetActive(true);
                TextCharacter3[2].SetActive(false);
                TextCharacter3[3].SetActive(false);
            }
            if (turn == 1 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 1)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(1, 2);
                turn++;
                TextCharacter3[0].SetActive(true);
                TextCharacter3[1].SetActive(false);
                TextCharacter3[2].SetActive(false);
                TextCharacter3[3].SetActive(false);
            }
        }
        TextTurn.text = "Elije Jugador:" + turn;
    }

    public void SelectCharacter4()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            if (turn == 4 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 4)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(4, 3);
                turn++;
                TextCharacter4[0].SetActive(false);
                TextCharacter4[1].SetActive(false);
                TextCharacter4[2].SetActive(false);
                TextCharacter4[3].SetActive(true);
            }
            if (turn == 3 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 3)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(3, 3);
                turn++;
                TextCharacter4[0].SetActive(false);
                TextCharacter4[1].SetActive(false);
                TextCharacter4[2].SetActive(true);
                TextCharacter4[3].SetActive(false);
            }
            if (turn == 2 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 2)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(2, 3);
                turn++;
                TextCharacter4[0].SetActive(false);
                TextCharacter4[1].SetActive(true);
                TextCharacter4[2].SetActive(false);
                TextCharacter4[3].SetActive(false);
            }
            if (turn == 1 && DataLevel.InstanceDataLevel.GetNumberPlayer() >= 1)
            {
                DataLevel.InstanceDataLevel.SetPlayerByNumber(1, 3);
                turn++;
                TextCharacter4[0].SetActive(true);
                TextCharacter4[1].SetActive(false);
                TextCharacter4[2].SetActive(false);
                TextCharacter4[3].SetActive(false);
            }
        }
        TextTurn.text = "Elije Jugador:" + turn;
    }

    public void SubtractTurn()
    {
        if (turn > 1)
        {
            turn--;
            TextTurn.text = "Elije Jugador:" + turn;
        }
    }
}
