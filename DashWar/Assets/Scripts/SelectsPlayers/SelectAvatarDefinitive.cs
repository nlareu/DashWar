using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvatarDefinitive : MonoBehaviour {
        
    //Filas
    public int rows;
    //Columnas
    //public int columns;
    public int[] numberBox;

    public SelectorPlayer[] playerSelectorsDefinitive;
    public Transform upLimit;
    public Transform downLimit;
    public Transform leftLimit;
    public Transform rightLimit;
    public float Distance;
    private bool[] playersMovement = new bool[GameConstants.MAX_NUMBER_OF_PLAYERS];

    // Use this for initialization
    private void Start()
    {
        // Chequeando referencias
        if (playerSelectorsDefinitive[0] != null)
        {
            if(playerSelectorsDefinitive[0].spriteRenderer != null)
                playerSelectorsDefinitive[0].spriteRenderer.enabled = true;
            playerSelectorsDefinitive[0].numChosenAvatar = 0;
        }        

        if(playerSelectorsDefinitive[1] != null)
            playerSelectorsDefinitive[1].numChosenAvatar = 1;
        if (playerSelectorsDefinitive[2] != null)
            playerSelectorsDefinitive[2].numChosenAvatar = 2;
        if(playerSelectorsDefinitive[3] != null)
            playerSelectorsDefinitive[3].numChosenAvatar = 3;

        for (int i = 0; i < playersMovement.Length; i++)
        {
            playersMovement[i] = true;
        }

        //DESCOMENTAR EN CASO QUE SE PIDA QUE TAMBIEN TENGAS QUE MOVER EL CONTROLADOR DEL CURSOR 1 PARA ACTIVARLO.
        //playerSelectorsDefinitive[0].SetActive(false);
        if(playerSelectorsDefinitive[1] != null)
            playerSelectorsDefinitive[1].gameObject.SetActive(false);
        if(playerSelectorsDefinitive[2] != null)
            playerSelectorsDefinitive[2].gameObject.SetActive(false);
        if(playerSelectorsDefinitive[3] != null)
            playerSelectorsDefinitive[3].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        CheckControlsPlayer();
    }

    /// <summary>
    /// Controls the Selector of the given player.
    /// </summary>
    /// <param name="_playerNumber">The number of the player to be controlled.</param>
    public void ControlPlayer(int _playerNumber)
    {
        // El nombre de la variable es tan corto para facilitar su uso en las listas de abajo
        int _pn = _playerNumber - 1;

        // Keyboard/Joystick Input
        float horizontalAxis = Input.GetAxisRaw("Player" + _playerNumber + "-Horizontal");
        float verticalAxis = Input.GetAxisRaw("Player" + _playerNumber + "-Vertical");

        // Moviendo el selector del jugador hacia la derecha
        if ((Input.GetButtonDown("Player" + _playerNumber + "-Horizontal") && horizontalAxis > 0))
        {
            if (playerSelectorsDefinitive[_pn].spriteAvatar != null)
                playerSelectorsDefinitive[_pn].spriteAvatar.SetActive(true);

            playerSelectorsDefinitive[_pn].gameObject.SetActive(true);
            if (playerSelectorsDefinitive[_pn].spriteRenderer != null)
                playerSelectorsDefinitive[_pn].spriteRenderer.enabled = true;

            if (playerSelectorsDefinitive[_pn].transform.position.x < rightLimit.position.x - Distance)
            {
                playerSelectorsDefinitive[_pn].numChosenAvatar++;
                playerSelectorsDefinitive[_pn].CheckAvatarDrow();

                if (_pn == 0)                
                    playerSelectorsDefinitive[0].numChosenLevel++;              
            }

            while (playerSelectorsDefinitive[_pn].transform.position.x >= rightLimit.position.x - Distance)
            {
                playerSelectorsDefinitive[_pn].transform.position = new Vector3(playerSelectorsDefinitive[_pn].transform.position.x - Distance, playerSelectorsDefinitive[_pn].transform.position.y, playerSelectorsDefinitive[_pn].transform.position.z);
            }

            playerSelectorsDefinitive[_pn].transform.position = new Vector3(playerSelectorsDefinitive[_pn].transform.position.x + Distance, playerSelectorsDefinitive[_pn].transform.position.y, playerSelectorsDefinitive[_pn].transform.position.z);
        }

        // Moviendo el selector del jugador hacia la izquierda
        else if ((Input.GetButtonDown("Player" + _playerNumber + "-Horizontal") && horizontalAxis < 0))
        {
            if (playerSelectorsDefinitive[_pn].spriteAvatar != null)
                playerSelectorsDefinitive[_pn].spriteAvatar.SetActive(true);

            playerSelectorsDefinitive[_pn].gameObject.SetActive(true);
            if (playerSelectorsDefinitive[_pn].spriteRenderer != null)
                playerSelectorsDefinitive[_pn].spriteRenderer.enabled = true;

            if (playerSelectorsDefinitive[_pn].transform.position.x > leftLimit.position.x + Distance)
            {
                playerSelectorsDefinitive[_pn].numChosenAvatar--;
                playerSelectorsDefinitive[_pn].CheckAvatarDrow();

                if(_pn == 0)
                    playerSelectorsDefinitive[0].numChosenLevel--;
            }

            while (playerSelectorsDefinitive[_pn].transform.position.x < leftLimit.position.x + Distance)
            {
                playerSelectorsDefinitive[_pn].transform.position = new Vector3(playerSelectorsDefinitive[_pn].transform.position.x + Distance, playerSelectorsDefinitive[_pn].transform.position.y, playerSelectorsDefinitive[_pn].transform.position.z);
            }

            playerSelectorsDefinitive[_pn].transform.position = new Vector3(playerSelectorsDefinitive[_pn].transform.position.x - Distance, playerSelectorsDefinitive[_pn].transform.position.y, playerSelectorsDefinitive[_pn].transform.position.z);
        }

        // Moviendo el selector del jugador hacia arriba
        else if ((Input.GetButtonDown("Player" + _playerNumber + "-Vertical") && verticalAxis > 0))
        {
            if (playerSelectorsDefinitive[_pn].spriteAvatar != null)
                playerSelectorsDefinitive[_pn].spriteAvatar.SetActive(true);

            playerSelectorsDefinitive[_pn].gameObject.SetActive(true);
            if (playerSelectorsDefinitive[_pn].spriteRenderer != null)
                playerSelectorsDefinitive[_pn].spriteRenderer.enabled = true;

            if (playerSelectorsDefinitive[_pn].transform.position.y < upLimit.position.y - Distance)
            {
                playerSelectorsDefinitive[_pn].numChosenAvatar = playerSelectorsDefinitive[_pn].numChosenAvatar + rows;
                playerSelectorsDefinitive[_pn].CheckAvatarDrow();

                if(_pn == 0)
                    playerSelectorsDefinitive[0].numChosenLevel = playerSelectorsDefinitive[0].numChosenLevel + rows;
            }

            while (playerSelectorsDefinitive[_pn].transform.position.y >= upLimit.position.y - Distance)
            {
                playerSelectorsDefinitive[_pn].transform.position = new Vector3(playerSelectorsDefinitive[_pn].transform.position.x, playerSelectorsDefinitive[_pn].transform.position.y - Distance, playerSelectorsDefinitive[_pn].transform.position.z);
            }

            playerSelectorsDefinitive[_pn].transform.position = new Vector3(playerSelectorsDefinitive[_pn].transform.position.x, playerSelectorsDefinitive[_pn].transform.position.y + Distance, playerSelectorsDefinitive[_pn].transform.position.z);
        }
        
        // Moviendo el selector del jugador hacia abajo
        else if ((Input.GetButtonDown("Player" + _playerNumber + "-Vertical") && verticalAxis < 0))
        {
            if (playerSelectorsDefinitive[_pn].spriteAvatar != null)
                playerSelectorsDefinitive[_pn].spriteAvatar.SetActive(true);

            playerSelectorsDefinitive[_pn].gameObject.SetActive(true);
            if (playerSelectorsDefinitive[_pn].spriteRenderer != null)
                playerSelectorsDefinitive[_pn].spriteRenderer.enabled = true;

            if (playerSelectorsDefinitive[_pn].transform.position.y > downLimit.position.y + Distance)
            {
                playerSelectorsDefinitive[_pn].numChosenAvatar = playerSelectorsDefinitive[_pn].numChosenAvatar - rows;
                playerSelectorsDefinitive[_pn].CheckAvatarDrow();

                if(_pn == 0)
                    playerSelectorsDefinitive[0].numChosenLevel = playerSelectorsDefinitive[0].numChosenLevel - rows;
            }

            while (playerSelectorsDefinitive[_pn].transform.position.y < downLimit.position.y + Distance)
            {
                playerSelectorsDefinitive[_pn].transform.position = new Vector3(playerSelectorsDefinitive[_pn].transform.position.x, playerSelectorsDefinitive[_pn].transform.position.y + Distance, playerSelectorsDefinitive[_pn].transform.position.z);
            }

            playerSelectorsDefinitive[_pn].transform.position = new Vector3(playerSelectorsDefinitive[_pn].transform.position.x, playerSelectorsDefinitive[_pn].transform.position.y - Distance, playerSelectorsDefinitive[_pn].transform.position.z);
        }

        // Seleccionando al Avatar
        if (Input.GetButtonDown("Player" + _playerNumber + "-Jump") || Input.GetButtonDown("Player" + _playerNumber + "-Dash"))
        {
            if (playerSelectorsDefinitive[_pn].spriteAvatar != null)
                playerSelectorsDefinitive[_pn].spriteAvatar.SetActive(true);

            playerSelectorsDefinitive[_pn].gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Lets the selectors of the players to be controlled.
    /// </summary>
    public void CheckControlsPlayer()
    {
        for (int i = 0; i < GameConstants.MAX_NUMBER_OF_PLAYERS; i++)
        {
            if (playersMovement[i] && playerSelectorsDefinitive[i] != null)
            {
                ControlPlayer(i + 1);
            }
        }
    }

    /// <summary>
    /// Gets the movement variable of the player.
    /// </summary>
    /// <param name="_playerNumber">The player to be requested.</param>
    /// <returns>If the requested player will move or not.</returns>
    public bool GetMovement(int _playerNumber)
    {
        return playersMovement[_playerNumber - 1];
    }

    /// <summary>
    /// Sets the movement variable of the player.
    /// </summary>
    /// <param name="_playerNumber">The player to be modified.</param>
    /// <param name="_movement">If the player will move or not.</param>
    public void SetMovement(int _playerNumber, bool _movement)
    {
        // Incluyo este metodo pq en la version original de 4 metodos separados lo habia
        // pero no se llamaba desde ningún lado
        playersMovement[_playerNumber - 1] = _movement;
    }
}
