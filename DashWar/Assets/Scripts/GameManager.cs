using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public int winningScore;
    public Text[] textsScore;
    public Text textWiner;
    //public GameObject[] spawnerPlayer;
    [HideInInspector]
    public List<AvatarController> Avatars;
    public int countAvatars;
    public int auxCountAvatars;
    public Camera camera;
	void Start () {
        for(int i = 0; i<textsScore.Length; i++)
        {
            textsScore[i].text = " ";
        }
	}
	
	// Update is called once per frame
	void Update () {
        CheckDead();
        CheckWin();
        CheckScore();
        CheckLevelFinish();

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
    public void CheckWin()
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
                camera.transform.position = new Vector3(Avatars[j].transform.position.x, Avatars[j].transform.position.y, Avatars[j].transform.position.z-0.3f);
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
