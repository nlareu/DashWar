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

    private List<AvatarController> leaderboard = new List<AvatarController>();

    [Header("Tabla de Posiciones")]
    public GameObject[] leaderBoardPositions;

    // Use this for initialization.
    void Start ()
    {
        // Los avatares comienzan parados y solo se mueven al terminar la cuenta regresiva
        for(int i = 0; i < Avatars.Count; i++)
        {
            //Avatars[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //Avatars[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }

        pause = false;

        for(int i = 0; i<textsScore.Length; i++)
        {
            textsScore[i].text = " ";
        }

        winningScore = DataLevel.InstanceDataLevel.GetWiningScore();

        auxCamPosition.x = cam.transform.position.x;
        auxCamPosition.y = cam.transform.position.y;
        auxCamPosition.z = cam.transform.position.z;

        // Inicializando la tabla de posiciones
        for (int i = 0; i < Avatars.Count; i++)
        {
            //leaderboard.Insert(i, Avatars[i]);
            leaderboard.Add(Avatars[i]);           
        }

        //Debug.Log("Tabla recién creada en Start: " + leaderboard.Count);
	}

    // Update is called once per frame
    void Update()
    {
        //SEGUN QUE VALOR TENGA EL GetGameMode() DEL DataLevel SERA EL MODO DE JUEGO QUE ELIJA EL SWITCH 
        switch (DataLevel.InstanceDataLevel.GetGameMode())
        {
            case 1:
                //Modo de supervivencia.
                //Debug.Log("Estamos en modo de supervivencia");
                CheckPause(); // Posición Original de esta llamada
                CheckDead();
                CheckWinGameModeSurvival();
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
    /// Checks if the player has paused the game and pauses it.
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

            GenerateLeaderBoard();
        }
    }

    /// <summary>
    /// Generates the leaderboard.
    /// </summary>
    public void GenerateLeaderBoard()
    {
        // Preparando y determinando la tabla de posiciones 3er intento
        //leaderboard.Clear(); // Esta linea causaba un error más adelante

        for (int i = 0; i < Avatars.Count; i++)
        {
            // Preparando los valores para ser modificados
            AvatarController currentAvatar = Avatars[i];
            float currentScore = Avatars[i].GetScore();
            currentAvatar.PositionInLeaderboard = 0;

            // Compara el score de cada Avatar con los de los demás
            for (int k = 0; k < Avatars.Count; k++)
            {
                if (i != k)
                {
                    float scoreToCompare = Avatars[k].GetScore();

                    // Si es menor que el otro se atrasa en la tabla de posiciones
                    if (currentScore < scoreToCompare)
                    {
                        currentAvatar.PositionInLeaderboard += 1;
                    }
                }
            }
        }

        // Acomodando cada Avatar en su respectiva posición en la tabla
        for (int i = 0; i < Avatars.Count; i++)
        {
            //leaderboard.Insert(Avatars[i].PositionInLeaderboard, Avatars[i]);
            int thePosition = Avatars[i].PositionInLeaderboard;
            //Debug.Log("Jugador " + Avatars[i] + " en posición " + Avatars[i].PositionInLeaderboard);
            //leaderboard[thePosition] = Avatars[i];
            leaderboard.RemoveAt(thePosition);
            leaderboard.Insert(thePosition, Avatars[i]);
        }

        // Verificando si ningún Jugador ha anotado para evitar el bug en el que un mismo Avatar aparecía
        // en la Leaderboard 2 veces la primera vez que se pausa la partida
        int totalZeroes = 0;

        for (int i = 0; i < Avatars.Count; i++)
        {
            if (Avatars[i].GetScore() <= 0)
            {
                totalZeroes += 1;
            }
        }

        // Si nadie ha anotado, mantener posiciones fijas
        if (totalZeroes == Avatars.Count)
        {
            //Debug.Log("Nadie ha anotado");
            leaderboard.Clear();

            for (int i = 0; i < Avatars.Count; i++)
            {
                leaderboard.Add(Avatars[i]);
            }
        }

        // Mostrando la tabla de posiciones
        /*
        for (int i = 0; i < leaderboard.Count; i++)
        {
            Debug.Log("Jugador " + leaderboard[i].name + " tiene de score " + leaderboard[i].GetScore() +
                " y está en la posición " + leaderboard[i].PositionInLeaderboard);
        }
        */
        for (int i = 0; i < leaderboard.Count; i++)
        {
            leaderBoardPositions[i].gameObject.SetActive(true);
            LeaderboardPosUI positionVal = leaderBoardPositions[i].GetComponent<LeaderboardPosUI>();
            positionVal.playerPosScore.text = "Jugador " + leaderboard[i].PlayerNumber + ": " + leaderboard[i].GetScore();
        }
    }

    /// <summary>
    /// Checks which player won the round and adds the respective score.
    /// </summary>
    public void CheckWinGameModeSurvival()
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

    /// <summary>
    /// Lets the Avatars start moving.
    /// </summary>
    public void AvatarsRoundStart()
    {
        //Debug.Log("Unfreeze the avatars for the round");

        for(int i = 0; i < Avatars.Count; i++)
        {
            //Avatars[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //Avatars[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            //Avatars[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            Avatars[i].State = AvatarStates.Normal;
        }
    }

    /// <summary>
    /// Freezes all the players on their places.
    /// </summary>
    public void FreezeAvatars()
    {
        //Debug.Log("Freeze avatars at the beginning");

        for (int i = 0; i < Avatars.Count; i++)
        {
            Avatars[i].State = AvatarStates.Still;
        }
    }
}
