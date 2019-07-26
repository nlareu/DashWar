using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppController : MonoBehaviour {

    public AvatarController PlayerSource;
    public bool SpecialRestart;
    [HideInInspector] public bool activateAvatarController;
    [HideInInspector] public bool[] cancelSelectionAvatarControllers = new bool[GameConstants.MAX_NUMBER_OF_PLAYERS]; // Si los jugadores cancelan o no la selección

    //limite de jugadores que va a tener el juego.
    public int PlayersCount = 4;
    public List<GameObject> RespawnPositions = new List<GameObject>();
    public GameManager gameManager;
    public bool notInstanciateImmediately;
    [HideInInspector] public List<AvatarController> players = new List<AvatarController>();
    private List<AvatarController> playersDead = new List<AvatarController>();
    public SelectAvatarDefinitive selectAvatarDefinitive;

    [Header("Round Ending")]
    [SerializeField] private Text roundWinnerText;
    [SerializeField] private float roundStartDelay = 1f;
    [SerializeField] private float nextRoundDelay = 1f;
    int winnerNumber;
    public GameObject startDashMessage;

    [Header("Player References")]
    public SelectorPlayer[] playerSelectors;
    public GameObject[] playerSprites;

    public bool InSelectAvatars;

    private AvatarController[] auxPlayers = new AvatarController[GameConstants.MAX_NUMBER_OF_PLAYERS]; // Ref a los jugadores
    [HideInInspector] public float[] auxTimeCancelPlayer = new float[GameConstants.MAX_NUMBER_OF_PLAYERS];
    [HideInInspector] public float[] timeCancelPlayer = new float[GameConstants.MAX_NUMBER_OF_PLAYERS];

    // Use this for initialization
    void Start()
    {
        // Tiempo por el que cada jugador (1-4) debe mantener apretado su botón para cancelar
        // la selección ¿de su personaje?
        for (int i = 0; i < GameConstants.MAX_NUMBER_OF_PLAYERS; i++)
        {
            auxTimeCancelPlayer[i] = 1.5f;
            timeCancelPlayer[i] = auxTimeCancelPlayer[i];
        }

        if (!notInstanciateImmediately)
        {
            StartAppController();
        }

        activateAvatarController = false;
        cancelSelectionAvatarControllers[0] = false;
    }

    // Update runs once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reset static.
            this.players.Clear();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (InSelectAvatars == true)
        {
            //ActivateAvatarController();
            CancelSelectionAvatarControler();
            // Deberíamos ir pensando en eliminar esta línea o cambiarla, no tiene sentido revisar esto
            // en cada Update
            RestartRound();
        }
    }

    /// <summary>
    /// Lets each player cancel their character selction.
    /// </summary>
    public void CancelSelectionAvatarControler()
    {    
        // Aún necesito analizar este método a profundidad a ver cómo funciona
        // Cancelando el jugador 1
        if (Input.GetKey(KeyCode.Space) && cancelSelectionAvatarControllers[0])
        {
            if(timeCancelPlayer[0] > 0)
            {
                timeCancelPlayer[0] -= Time.deltaTime;
            }
            if (timeCancelPlayer[0] <= 0)
            {
                timeCancelPlayer[0] = auxTimeCancelPlayer[0];

                selectAvatarDefinitive.SetMovement(1, true);
                playerSelectors[0].Movement = true;
                cancelSelectionAvatarControllers[0] = false;
                activateAvatarController = false;
                playerSprites[0].SetActive(true);

                DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(1)].gameObject.SetActive(false);
                DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(1)].SetRevive(false);

                auxPlayers[0].gameObject.SetActive(false);
                auxPlayers[0].SetRevive(false);

                DataLevel.InstanceDataLevel.SubtractPlayer();
            }
        }
        if(!Input.GetKey(KeyCode.Space) && cancelSelectionAvatarControllers[0])
        {
            timeCancelPlayer[0] = auxTimeCancelPlayer[0];
        }

        // Cancelando el jugador 2
        if(Input.GetKey(KeyCode.RightShift) && cancelSelectionAvatarControllers[1])
        {
            if(timeCancelPlayer[1] > 0)
            {
                timeCancelPlayer[1] -= Time.deltaTime;
            }
            if (timeCancelPlayer[1] <= 0)
            {
                timeCancelPlayer[1] = auxTimeCancelPlayer[1];

                selectAvatarDefinitive.SetMovement(2, true);
                playerSelectors[1].Movement = true;
                cancelSelectionAvatarControllers[1] = false;
                activateAvatarController = false;
                playerSprites[1].SetActive(true);

                DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(2)].gameObject.SetActive(false);
                DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(2)].SetRevive(false);

                auxPlayers[1].gameObject.SetActive(false);
                auxPlayers[1].SetRevive(false);

                DataLevel.InstanceDataLevel.SubtractPlayer();
            }
        }
        if (!Input.GetKey(KeyCode.RightShift) && cancelSelectionAvatarControllers[1])
        {
            timeCancelPlayer[1] = auxTimeCancelPlayer[1];
        }

        // Cancelando el jugador 3
        if (Input.GetButton("Player3-Jump") && cancelSelectionAvatarControllers[2])
        {
            if(timeCancelPlayer[2] > 0)
            {
                timeCancelPlayer[2] -= Time.deltaTime;
            }
            if (timeCancelPlayer[2] <= 0)
            {
                timeCancelPlayer[2] = auxTimeCancelPlayer[2];

                selectAvatarDefinitive.SetMovement(3, true);
                playerSelectors[2].Movement = true;
                cancelSelectionAvatarControllers[2] = false;
                activateAvatarController = false;
                playerSprites[2].SetActive(true);

                DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(3)].gameObject.SetActive(false);
                DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(3)].SetRevive(false);

                auxPlayers[2].gameObject.SetActive(false);
                auxPlayers[2].SetRevive(false);

                DataLevel.InstanceDataLevel.SubtractPlayer();
            }
        }
        if (!Input.GetButton("Player3-Jump") && cancelSelectionAvatarControllers[2])
        {
            timeCancelPlayer[2] = auxTimeCancelPlayer[2];
        }

        // Cancelando el jugador 4
        if (Input.GetButton("Player4-Jump") && cancelSelectionAvatarControllers[3])
        {
            if (timeCancelPlayer[3] > 0)
            {
                timeCancelPlayer[3] -= Time.deltaTime;
            }
            if (timeCancelPlayer[3] <= 0)
            {
                timeCancelPlayer[3] = auxTimeCancelPlayer[3];

                selectAvatarDefinitive.SetMovement(4, true);
                playerSelectors[3].Movement = true;
                cancelSelectionAvatarControllers[3] = false;
                activateAvatarController = false;
                playerSprites[3].SetActive(true);

                DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(4)].gameObject.SetActive(false);
                DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(4)].SetRevive(false);

                auxPlayers[3].gameObject.SetActive(false);
                auxPlayers[3].SetRevive(false);

                DataLevel.InstanceDataLevel.SubtractPlayer();
            }
        }
        if(!Input.GetButton("Player4-Jump") && cancelSelectionAvatarControllers[3])
        {
            timeCancelPlayer[3] = auxTimeCancelPlayer[3];
        }
    }

    // Nota DC 04072019: Se debería considerar eliminar este método ya que no se usa en ningún lado, solamente
    // aparece comentado en Update en este mismo script
    public void ActivateAvatarController()
    {
        float axisHorPlayer3 = Input.GetAxis("Player3-LeftStick-Horizontal");
        float axisLeftPlayer3 = Input.GetAxis("Player3-Left");
        float axisRightPlayer3 = Input.GetAxis("Player3-Right");

        float axisHorPlayer4 = Input.GetAxis("Player4-LeftStick-Horizontal");
        float axisLeftPlayer4 = Input.GetAxis("Player4-Left");
        float axisRightPlayer4 = Input.GetAxis("Player4-Right");

        if (Input.GetKeyDown(KeyCode.A) && activateAvatarController || Input.GetKeyDown(KeyCode.D) && activateAvatarController)
        {
            auxPlayers[0].SetNotMove(false);
            auxPlayers[0].GetComponent<Rigidbody2D>().simulated = true;
            auxPlayers[0].gameObject.SetActive(true);
            playerSprites[0].SetActive(false);
            activateAvatarController = false;
        }
        //Debug.Log(activateAvatarController);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && activateAvatarController || Input.GetKeyDown(KeyCode.RightArrow) && activateAvatarController)
        {
            auxPlayers[1].SetNotMove(false);
            auxPlayers[1].GetComponent<Rigidbody2D>().simulated = true;
            auxPlayers[1].gameObject.SetActive(true);
            playerSprites[1].SetActive(false);
            activateAvatarController = false;
        }

        //JOSTICK 1
        if(Input.GetButtonDown("Player3-LeftStick-Horizontal") && activateAvatarController && axisHorPlayer3 >0 || 
            Input.GetButtonDown("Player3-LeftStick-Horizontal") && axisHorPlayer3 < 0 && activateAvatarController ||
            Input.GetButtonDown("Player3-Left") && axisLeftPlayer3 > 0 && activateAvatarController ||
            Input.GetButtonDown("Player3-Right") && axisRightPlayer3 > 0 && activateAvatarController)
        {
            auxPlayers[2].SetNotMove(false);
            auxPlayers[2].GetComponent<Rigidbody2D>().simulated = true;
            auxPlayers[2].gameObject.SetActive(true);
            playerSprites[2].SetActive(false);
            activateAvatarController = false;
        }

        //JOSTICK 2
        if(Input.GetButtonDown("Player4-LeftStick-Horizontal") && activateAvatarController && axisHorPlayer4 > 0 ||
            Input.GetButtonDown("Player4-LeftStick-Horizontal") && axisHorPlayer4 < 0 && activateAvatarController ||
            Input.GetButtonDown("Player4-Left") && axisLeftPlayer4 > 0 && activateAvatarController ||
            Input.GetButtonDown("Player4-Right") && axisRightPlayer4 > 0 && activateAvatarController)
        {
            auxPlayers[3].SetNotMove(false);
            auxPlayers[3].GetComponent<Rigidbody2D>().simulated = true;
            auxPlayers[3].gameObject.SetActive(true);
            playerSprites[3].SetActive(false);
            activateAvatarController = false;
        }
    }

    /// <summary>
    /// Instantiates a player.
    /// </summary>
    /// <param name="_playerNumber">The number of the player to be instantiated (1 - 4).</param>
    /// <param name="_activate">Whether the player is going to be active or not.</param>
    public void InstanciarJugador(int _playerNumber, bool _activate)
    {
        // POR HACER: Falta colocar el respawn aleatorio, aún no he analizado con profundidad como funciona este método

        // Esto lo coloco pq en InstanciarJugador1 estaba algo parecido
        if (DataLevel.InstanceDataLevel == null)
        {
            Debug.Log("No hay InstanceDataLevel");
            return;
        }
        
        // Creando al jugador y almacenando la referencia
        AvatarController player;
        player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(_playerNumber)],
            this.RespawnPositions[_playerNumber - 1].transform.position, Quaternion.identity);        
        auxPlayers[_playerNumber - 1] = player;

        // Registrando al jugador
        player.AppController = this;
        player.PlayerNumber = _playerNumber;
        DataLevel.InstanceDataLevel.AddPlayer();
        players.Add(player);
        player.Died += this.Player_Died;

        if (gameManager != null)
        {
            gameManager.Avatars.Add(player);
            gameManager.countAvatars++;
            gameManager.auxCountAvatars = gameManager.countAvatars;
        }

        // Restringiendo el movimiento
        if (!_activate)
        {
            player.SetNotMove(false);
            player.GetComponent<Rigidbody2D>().simulated = true;
            player.gameObject.SetActive(true);
            playerSprites[_playerNumber - 1].SetActive(false);
        }
    }

    public void StartAppController()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            PlayersCount = DataLevel.InstanceDataLevel.GetNumberPlayer();
        }
        //RestartRound();
        // el i aqui representa el numero del jugador y el contenido del avatarsControllers el avatar que el jugador elijio.
        //-Agregar un if de (i== x numero) por cada vez que se extienda en 1 el limite de jugadores.
        //Tambien se debe agregar un player y get player en la clase DataLevel cada vez que se extiende la cantidad de jugadores que pueden jugar

        //-En caso de crearse un avatar nuevo agregar a la lista de avatarControllers ubicada en el scrip DataLevel
        //el avatarController de el nuevo avatar que se creo
        for (int i = 0; i < PlayersCount; i++)
        {
            if (DataLevel.InstanceDataLevel != null)
            {
                //Debug.Log("Instanciando AppController y jugador #" + i);
                // Nota DC: Este método parece que se llama al comenzar la partida

                AvatarController player;
                
                player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayerByNumber(i + 1)], 
                    this.RespawnPositions[i].transform.position, Quaternion.identity);
                player.AppController = this;
                player.PlayerNumber = this.AddPlayer(player);
                player.Died += this.Player_Died;
                player.gameObject.SetActive(true);
                if (gameManager != null)
                {
                    gameManager.Avatars.Add(player);
                    gameManager.countAvatars++;
                }
            }
        }

        if (gameManager != null)
        {
            gameManager.auxCountAvatars = gameManager.countAvatars;
        }
    }

    public int AddPlayer(AvatarController avatar)
    {
        this.players.Add(avatar);

        return this.players.Count;
    }

    /// <summary>
    /// Checks if the round has ended.
    /// </summary>
    /// <returns>True if the round has ended, false otherwise.</returns>
    private bool CheckRoundEnded()
    {
        // The round has ended if only one player remains
        return (this.players.Count - this.playersDead.Count <= 1);
    }

    public List<AvatarController> GetPlayers()
    {
        //Return a copy to prevent reference and not desired changes on the list.
        return new List<AvatarController>(this.players);
    }

    public void RestartParty()
    {
        if (!SpecialRestart)
        {
            this.playersDead.Clear();

            for (int i = 0; i < this.players.Count; i++)
            {
                var player = this.players[i];
                var respawnPos = this.RespawnPositions[i].transform.position;

                player.transform.position = new Vector2(respawnPos.x, respawnPos.y);
                player.SetScore(0);
                player.gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < players.Count; i++)
            {
                //Debug.Log(players[i]);
                if (players[i] != null)
                {
                    if (players[i].gameObject.activeSelf == false && players[i].GetRevive() == true)
                    {
                        var player = players[i];
                        var respawnPos = RespawnPositions[players[i].PlayerNumber - 1].transform.position;

                        player.transform.position = new Vector2(respawnPos.x, respawnPos.y);
                        player.SetScore(0);
                        player.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Restarts the players and the round.
    /// </summary>
    public void RestartRound()
    {
        //Debug.Log("The round will restart now.");
        startDashMessage.SetActive(true);
        
        //gameManager.FreezeAvatars();
        Invoke("StartNextRound", nextRoundDelay);

        if (!SpecialRestart)
        {
            // Reseteo entre rondas
            this.playersDead.Clear();

            for (int i = 0; i < this.players.Count; i++)
            {
                var player = this.players[i];
                var respawnPos = this.RespawnPositions[i].transform.position;

                player.transform.position = new Vector2(respawnPos.x, respawnPos.y);
                //player.SetScore(0);
                player.gameObject.SetActive(true);
                player.rigidBody.velocity = Vector2.zero; // Para que no conserven la inercia de la ronda anterior
            }
        }
        else
        {
            // No sé qué reseteo será pero parece también entre rondas
            for(int i = 0; i< players.Count; i++)
            {
                //Debug.Log(players[i]);
                if (players[i] != null)
                {
                    if (players[i].gameObject.activeSelf == false && players[i].GetRevive() == true)
                    {
                        var player = players[i];
                        var respawnPos = RespawnPositions[players[i].PlayerNumber - 1].transform.position;

                        player.transform.position = new Vector2(respawnPos.x, respawnPos.y);
                        //player.SetScore(0);
                        player.gameObject.SetActive(true);
                    }
                }
            }
        }

        Time.timeScale = 1f;
        roundWinnerText.gameObject.SetActive(false);
    }
    
    private void Player_Died(object sender, EventArgs e)
    {
        AvatarController avatar = (AvatarController)sender;

        playersDead.Add(avatar);

        // Resetea la ronda si esta ha terminado, mostrando quien ganó
        if (this.CheckRoundEnded() == true)
        {
            gameManager.FreezeAvatars();

            for (int i = 0; i < gameManager.Avatars.Count; i++)
            {
                if (gameManager.Avatars[i].GetDeath() == false)
                {
                    winnerNumber = gameManager.Avatars[i].PlayerNumber;
                    roundWinnerText.text = "¡Jugador/a " + winnerNumber + " ha ganado la ronda!";
                }
            }

            Time.timeScale = 0f;
            roundWinnerText.gameObject.SetActive(true);
            Invoker.InvokeDelayed(RestartRound, roundStartDelay);
        }            
    }

    /// <summary>
    /// Lets the players begin the next round.
    /// </summary>
    private void StartNextRound()
    {
        startDashMessage.SetActive(false);
        gameManager.AvatarsRoundStart();
    }
}
