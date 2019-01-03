using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public GameObject camvasPause;
    private bool pause;
    private int winningScore;
    public Text[] textsScore;
    public Text textWiner;
    //public GameObject[] spawnerPlayer;
    [HideInInspector]
    public List<AvatarController> Avatars;
    public int countAvatars;
    public int auxCountAvatars;
    public Camera cam;
	void Start () {
        pause = false;
        for(int i = 0; i<textsScore.Length; i++)
        {
            textsScore[i].text = " ";
        }
        winningScore = DataLevel.InstanceDataLevel.GetWiningScore();
	}

    // Update is called once per frame
    void Update() {
        //SEGUN QUE VALOR TENGA EL GetGameMode() DEL DataLevel SERA EL MODO DE JUEGO QUE ELIJA EL SWITCH 
        switch (DataLevel.InstanceDataLevel.GetGameMode())
        {
            case 1:
                //Modo de supervivencia.
                CheckPause();
                CheckDead();
                CheckWinGameModeSorvival();
                CheckScore();
                CheckLevelFinish();
                break;
            case 2:
                break;
        
        }

    }
    public void CheckDead()
    {
        for(int i = 0; i< Avatars.Count; i++)
        {
            if(Avatars[i].GetDeath() == true && Avatars[i].GetVerifiedDeath() == false)
            {
                countAvatars--;
                Avatars[i].SetVerifiedDeath(true);
            }
        }
    }
    public void CheckPause()
    {
        //Hago que el juego se ponga en pausa.
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("ENTRE");
            if (pause)
            {
                pause = false;
                if(DataLevel.InstanceDataLevel != null)
                {
                    DataLevel.InstanceDataLevel.pause = false;
                }
                Time.timeScale = 1;
                camvasPause.SetActive(false);
            }
            else if (!pause)
            {
                pause = true;
                if (DataLevel.InstanceDataLevel != null)
                {
                    DataLevel.InstanceDataLevel.pause = true;
                }
                Time.timeScale = 0;
                camvasPause.SetActive(true);
            }
            
        }
    }
    public void CheckWinGameModeSorvival()
    {
        if(countAvatars == 1)
        { 
            for(int i = 0; i<Avatars.Count; i++)
            {
                if(Avatars[i].GetDeath() == false)
                {
                    Avatars[i].AddScore(1);
                }
            }
            Restart();
        }
       
    }
    public void CheckScore()
    {
        for(int i = 0; i< Avatars.Count; i++)
        {
            Avatars[i].textScore = "Jugador "+(i+1)+": " + Avatars[i].GetScore();
            textsScore[i].text = Avatars[i].textScore;
        }
    }
    public void CheckLevelFinish()
    {
        for(int j = 0; j< Avatars.Count; j++)
        {
            if(Avatars[j].GetScore() >= winningScore)
            {
                cam.transform.position = new Vector3(Avatars[j].transform.position.x, Avatars[j].transform.position.y, Avatars[j].transform.position.z-0.3f);
                if (DataLevel.InstanceDataLevel != null)
                {
                    textWiner.text = "¡Ganador!";
                    textWiner.gameObject.SetActive(true);
                }
            }
        }
    }
    public void Restart()
    {
        for(int i = 0; i<Avatars.Count; i++)
        {
            Avatars[i].SetDeath(false);
            Avatars[i].SetVerifiedDeath(false);
            countAvatars = auxCountAvatars;
        }
    }
}
