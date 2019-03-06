using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
    private Vector3 auxCamPosition;

    private List<AvatarController> leaderboard;

    // Use this for initialization.
    void Start ()
    {
        pause = false;

        for(int i = 0; i<textsScore.Length; i++)
        {
            textsScore[i].text = " ";
        }

        winningScore = DataLevel.InstanceDataLevel.GetWiningScore();
        auxCamPosition.x = cam.transform.position.x;
        auxCamPosition.y = cam.transform.position.y;
        auxCamPosition.z = cam.transform.position.z;
        
	}

    // Update is called once per frame
    void Update()
    {
        //SEGUN QUE VALOR TENGA EL GetGameMode() DEL DataLevel SERA EL MODO DE JUEGO QUE ELIJA EL SWITCH 
        switch (DataLevel.InstanceDataLevel.GetGameMode())
        {
            case 1:
                //Modo de supervivencia.
                Debug.Log("Estamos en modo de supervivencia");
                CheckPause(); // Posición Original de esta llamada
                CheckDead();
                CheckWinGameModeSorvival();
                CheckScore();
                CheckLevelFinish();
                break;
            case 2:
                break;        
        }

        //CheckPause(); // Recuerda poner esto en su logar original, lo coloco aquí para probar
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

    /// <summary>
    /// Checks if the player has paused the game.
    /// </summary>
    public void CheckPause()
    {
        //Hago que el juego se ponga en pausa.
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (DataLevel.InstanceDataLevel != null)
            {
                DataLevel.InstanceDataLevel.pause = true;
            }

            Time.timeScale = 0;
            camvasPause.SetActive(true);

            /*
            // Preparando la tabla de posiciones
            float higherScore = 0f;
            float lowerScore = 0f;

            // Calculando la tabla de posiciones 1er intento
            for (int i = 0; i < Avatars.Count; i++)
            {
                float currentScore = Avatars[i].GetScore();
                Debug.Log("Player " + i + " score is: " + currentScore);

                if (currentScore > higherScore)
                {
                    // Determinando el primer lugar
                    higherScore = currentScore;
                    leaderboard.Insert(0, Avatars[i]);
                }
                else
                {
                    // Determinando los demás lugares
                    for (int k = 0; k < leaderboard.Count; k++)
                    {
                        if (currentScore > leaderboard[i].GetScore())
                        {
                            
                        }
                    }
                }
            }
            */

            // Preparando la tabla de posiciones
            /*
            float highScore = Avatars[0].GetScore();
            leaderboard.RemoveAll();
            leaderboard.Clear();
            leaderboard.Insert(0, Avatars[0]);

            // Determinando la tabla de posiciones 2do intento
            for (int i = 0; i < Avatars.Count; i++)
            {
                AvatarController currentAvatar = Avatars[i];
                float currentScore = Avatars[i].GetScore();

                // Comparando el score de cada jugador con el de los demás
                for (int k = 0; k < Avatars.Count; k++)
                {
                    if (i != k)
                    {
                        float scoreToCompare = Avatars[k].GetScore();

                        // Si sobrepasa el score, adelanta en la tabla, de lo contrario se queda atrás
                        if (scoreToCompare > currentScore)
                        {
                            leaderboard.Insert(i, Avatars[k]);
                        }
                        else
                        {
                            leaderboard.Insert(i + 1, Avatars[k]);
                        }
                    }
                }
            }

            // Mostrando la tabla de posiciones (Falta por hacer)
            for (int i = 0; i < leaderboard.Count; i++)
            {
                Debug.Log("Jugador " + leaderboard[i].name + " tiene de score " + leaderboard[i].GetScore());
            }
            */
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

    /// <summary>
    /// Gets and refreshes the score of each avatar.
    /// </summary>
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
        for(int i = 0; i < Avatars.Count; i++)
        {
            cam.gameObject.transform.position = auxCamPosition;
            Avatars[i].SetDeath(false);
            Avatars[i].SetVerifiedDeath(false);
            textWiner.gameObject.SetActive(false);
            countAvatars = auxCountAvatars;
        }
    }
}
