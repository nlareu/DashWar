using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour {

    public AvatarController PlayerSource;
    public bool SpecialRestart;
    [HideInInspector]
    public bool activateAvatarController;
    [HideInInspector]
    public bool cancelSelectionAvatarController;
    //limite de jugadores que va a tener el juego.
    public int PlayersCount = 4;
    public List<GameObject> RespawnPositions = new List<GameObject>();
    public GameManager gameManager;
    public bool notInstanciateImmediately;
    [HideInInspector]
    public List<AvatarController> players = new List<AvatarController>();
    private List<AvatarController> playersDead = new List<AvatarController>();
    public SelectAvatarDefinitive selectAvatarDefinitive;
    public SelectorPlayer selectorPlayer1;
    public SelectorPlayer selectorPlayer2;
    public SelectorPlayer selectorPlayer3;
    public SelectorPlayer selectorPlayer4;
    public GameObject SpritePlayer1;
    public GameObject SpritePlayer2;
    public GameObject SpritePlayer3;
    public GameObject SpritePlayer4;
    private AvatarController auxPlayer1;
    private AvatarController auxPlayer2;
    private AvatarController auxPlayer3;
    private AvatarController auxPlayer4;

    // Use this for initialization
    void Start() {
        if (!notInstanciateImmediately)
        {
            StartAppController();
        }
        activateAvatarController = false;
        cancelSelectionAvatarController = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Reset static.
            this.players.Clear();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        ActivateAvatarController();
        CancelSelectionAvatarControler();
    }
    public void CancelSelectionAvatarControler()
    {
        //float axisHorJostick1 = Input.GetAxis("Jostick1-LeftStick_Horizontal");
        //float axisHorJostick2 = Input.GetAxis("Jostick2-LeftStick_Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && cancelSelectionAvatarController)
        {
            selectAvatarDefinitive.SetMovement1(true);
            selectorPlayer1.SetMovement(true);
            Destroy(auxPlayer1);
            cancelSelectionAvatarController = false;
            activateAvatarController = false;
            //DataLevel.InstanceDataLevel.avatarsControllers.Remove(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer1()]);
            //Destroy(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer1()].gameObject);
        }
        if(Input.GetKeyDown(KeyCode.Alpha0) && cancelSelectionAvatarController)
        {
            selectAvatarDefinitive.SetMovement2(true);
            selectorPlayer2.SetMovement(true);
            Destroy(auxPlayer2);
            cancelSelectionAvatarController = false;
            activateAvatarController = false;
            //DataLevel.InstanceDataLevel.avatarsControllers.Remove(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer2()]);
            //Destroy(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer2()].gameObject);
        }
    }
    public void ActivateAvatarController()
    {
        float axisHorJostick1 = Input.GetAxis("Jostick1-LeftStick_Horizontal");
        float axisHorJostick2 = Input.GetAxis("Jostick2-LeftStick_Horizontal");
        if (Input.GetKeyDown(KeyCode.A) && activateAvatarController || Input.GetKeyDown(KeyCode.D) && activateAvatarController)
        {
            auxPlayer1.SetNotMove(false);
            auxPlayer1.GetComponent<Rigidbody2D>().simulated = true;
            auxPlayer1.gameObject.SetActive(true);
            SpritePlayer1.SetActive(false);
            activateAvatarController = false;
        }
        //Debug.Log(activateAvatarController);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && activateAvatarController || Input.GetKeyDown(KeyCode.RightArrow) && activateAvatarController)
        {
            auxPlayer2.SetNotMove(false);
            auxPlayer2.GetComponent<Rigidbody2D>().simulated = true;
            auxPlayer2.gameObject.SetActive(true);
            SpritePlayer2.SetActive(false);
            activateAvatarController = false;
        }
        //JOSTICK 1
        if(Input.GetButtonDown("Jostick1-LeftStick_Horizontal") && activateAvatarController ||axisHorJostick1 >0 && activateAvatarController || axisHorJostick1 < 0 && activateAvatarController)
        {
            auxPlayer3.SetNotMove(false);
            auxPlayer3.GetComponent<Rigidbody2D>().simulated = true;
            auxPlayer3.gameObject.SetActive(true);
            SpritePlayer3.SetActive(false);
            activateAvatarController = false;
        }
        //JOSTICK 2
        if(Input.GetButtonDown("Jostick2-LeftStick_Horizontal") && activateAvatarController || axisHorJostick2 > 0 && activateAvatarController || axisHorJostick2 < 0 && activateAvatarController)
        {
            auxPlayer4.SetNotMove(false);
            auxPlayer4.GetComponent<Rigidbody2D>().simulated = true;
            auxPlayer4.gameObject.SetActive(true);
            SpritePlayer4.SetActive(false);
            activateAvatarController = false;
        }
    }
    public void InstanciarJugador1(bool activate)
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            AvatarController player;
            player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer1()], this.RespawnPositions[0].transform.position, Quaternion.identity);
            auxPlayer1 = player;
            player.AppController = this;
            player.PlayerNumber = 1;
            players.Add(player);
            player.Died += this.Player_Died;
            if (gameManager != null)
            {
                gameManager.Avatars.Add(player);
                gameManager.countAvatars++;
                gameManager.auxCountAvatars = gameManager.countAvatars;
            }
            if(!activate)
            {
                player.SetNotMove(true);
                player.GetComponent<Rigidbody2D>().simulated = false;
                player.gameObject.SetActive(false);
            }
        }
    }
    
    public void InstanciarJugador2(bool activate)
    {
        AvatarController player;
        player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer2()], this.RespawnPositions[1].transform.position, Quaternion.identity);
        auxPlayer2 = player;
        player.AppController = this;
        player.PlayerNumber = 2;
        players.Add(player);
        player.Died += this.Player_Died;
        if (gameManager != null)
        {
            gameManager.Avatars.Add(player);
            gameManager.countAvatars++;
            gameManager.auxCountAvatars = gameManager.countAvatars;
        }
        if (!activate)
        {
            player.SetNotMove(true);
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.gameObject.SetActive(false);
        }
    }

    public void InstanciarJugador3(bool activate)
    {
        AvatarController player;
        player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer3()], this.RespawnPositions[2].transform.position, Quaternion.identity);
        auxPlayer3 = player;
        player.AppController = this;
        player.PlayerNumber = 3;
        player.Died += this.Player_Died;
        if (gameManager != null)
        {
            gameManager.Avatars.Add(player);
            gameManager.countAvatars++;
            gameManager.auxCountAvatars = gameManager.countAvatars;
        }
        if (!activate)
        {
            player.SetNotMove(true);
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.gameObject.SetActive(false);
        }
    }

    public void InstanciarJugador4(bool activate)
    {
        AvatarController player;
        player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer4()], this.RespawnPositions[3].transform.position, Quaternion.identity);
        auxPlayer4 = player;
        player.AppController = this;
        player.PlayerNumber = 4;
        player.Died += this.Player_Died;
        if (gameManager != null)
        {
            gameManager.Avatars.Add(player);
            gameManager.countAvatars++;
            gameManager.auxCountAvatars = gameManager.countAvatars;
        }
        if (!activate)
        {
            player.SetNotMove(true);
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.gameObject.SetActive(false);
        }
    }

    public void StartAppController()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            PlayersCount = DataLevel.InstanceDataLevel.GetNumberPlayer();
        }
        // el i aqui representa el numero del jugador y el contenido del avatarsControllers el avatar que el jugador elijio.
        //-Agregar un if de (i== x numero) por cada vez que se extienda en 1 el limite de jugadores.
        //Tambien se debe agregar un player y get player en la clase DataLevel cada vez que se extiende la cantidad de jugadores que pueden jugar

        //-En caso de crearse un avatar nuevo agregar a la lista de avatarControllers ubicada en el scrip DataLevel
        //el avatarController de el nuevo avatar que se creo

        // PARA INCORPORAR AL JUGADOR NUEVO SEGUIR EL PATRON QUE ESTA DENTRO DEL if(DataLevel.InstanceDataLevel != null).
        for (int i = 0; i < PlayersCount; i++)
        {
            if (DataLevel.InstanceDataLevel != null)
            {
                AvatarController player;
                if (i == 0)
                {
                    player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer1()], this.RespawnPositions[i].transform.position, Quaternion.identity);
                    player.AppController = this;
                    player.PlayerNumber = this.AddPlayer(player);
                    player.Died += this.Player_Died;
                    if (gameManager != null)
                    {
                        gameManager.Avatars.Add(player);
                        gameManager.countAvatars++;
                    }
                }
                if (i == 1)
                {
                    player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer2()], this.RespawnPositions[i].transform.position, Quaternion.identity);
                    player.AppController = this;
                    player.PlayerNumber = this.AddPlayer(player);
                    player.Died += this.Player_Died;
                    if (gameManager != null)
                    {
                        gameManager.Avatars.Add(player);
                        gameManager.countAvatars++;
                    }
                }
                if (i == 2)
                {
                    player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer3()], this.RespawnPositions[i].transform.position, Quaternion.identity);
                    player.AppController = this;
                    player.PlayerNumber = this.AddPlayer(player);
                    player.Died += this.Player_Died;
                    if (gameManager != null)
                    {
                        gameManager.Avatars.Add(player);
                        gameManager.countAvatars++;
                    }
                }
                if (i == 3)
                {
                    player = Instantiate(DataLevel.InstanceDataLevel.avatarsControllers[DataLevel.InstanceDataLevel.GetPlayer4()], this.RespawnPositions[i].transform.position, Quaternion.identity);
                    player.AppController = this;
                    player.PlayerNumber = this.AddPlayer(player);
                    player.Died += this.Player_Died;
                    if (gameManager != null)
                    {
                        gameManager.Avatars.Add(player);
                        gameManager.countAvatars++;
                    }
                }
            }
        }
        if (gameManager != null)
        {
            gameManager.auxCountAvatars = gameManager.countAvatars;
        }
    }
    // Update is called once per frame
    public int AddPlayer(AvatarController avatar)
    {
        this.players.Add(avatar);

        return this.players.Count;
    }
    private bool CheckRoundEnded()
    {
        return (this.players.Count - this.playersDead.Count <= 1);
    }
    public List<AvatarController> GetPlayers()
    {
        //Return a copy to prevent reference and not desired changes on the list.
        return new List<AvatarController>(this.players);
    }
    private void RestartRound()
    {
        if (!SpecialRestart)
        {
            this.playersDead.Clear();

            for (int i = 0; i < this.players.Count; i++)
            {
                var player = this.players[i];
                var respawnPos = this.RespawnPositions[i].transform.position;

                player.transform.position = new Vector2(respawnPos.x, respawnPos.y);

                player.gameObject.SetActive(true);
            }
        }
        else
        {
            for(int i = 0; i< players.Count; i++)
            {
                Debug.Log(players[i]);
                if (players[i] != null)
                {
                    if (players[i].gameObject.activeSelf == false)
                    {
                        var player = players[i];
                        var respawnPos = RespawnPositions[players[i].PlayerNumber - 1].transform.position;

                        player.transform.position = new Vector2(respawnPos.x, respawnPos.y);

                        player.gameObject.SetActive(true);
                    }
                }
            }
        }
    }


    private void Player_Died(object sender, EventArgs e)
    {
        AvatarController avatar = (AvatarController)sender;

        playersDead.Add(avatar);



        if (this.CheckRoundEnded() == true)
            this.RestartRound();
    }
}
