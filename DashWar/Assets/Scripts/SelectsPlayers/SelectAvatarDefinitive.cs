using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvatarDefinitive : MonoBehaviour {

    // Use this for initialization
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

    // Update is called once per frame
    private void Start()
    {
        //playerSelectorsDefinitive[0].CheckAvatarDrow();
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
    void Update () {
        CheckControlsPlayer();
    }

    public void ControlPlayer1()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(playerSelectorsDefinitive[0].spriteAvatar != null)
                playerSelectorsDefinitive[0].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[0].gameObject.SetActive(true);
            if(playerSelectorsDefinitive[0].spriteRenderer != null)
            playerSelectorsDefinitive[0].spriteRenderer.enabled = true;
            if (playerSelectorsDefinitive[0].transform.position.x < rightLimit.position.x - Distance)
            {
                playerSelectorsDefinitive[0].numChosenAvatar++;
                playerSelectorsDefinitive[0].numChosenLevel++;
                playerSelectorsDefinitive[0].CheckAvatarDrow();
                
            }
            //Debug.Log(playerSelectorsDefinitive[0].numChosenAvatar);
            while (playerSelectorsDefinitive[0].transform.position.x >= rightLimit.position.x - Distance)
            {
                playerSelectorsDefinitive[0].transform.position = new Vector3(playerSelectorsDefinitive[0].transform.position.x - Distance, playerSelectorsDefinitive[0].transform.position.y, playerSelectorsDefinitive[0].transform.position.z);
            }
            playerSelectorsDefinitive[0].transform.position = new Vector3(playerSelectorsDefinitive[0].transform.position.x + Distance, playerSelectorsDefinitive[0].transform.position.y, playerSelectorsDefinitive[0].transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerSelectorsDefinitive[0].spriteAvatar != null)
                playerSelectorsDefinitive[0].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[0].gameObject.SetActive(true);
            if(playerSelectorsDefinitive[0].spriteRenderer != null)
            playerSelectorsDefinitive[0].spriteRenderer.enabled = true;
            if (playerSelectorsDefinitive[0].transform.position.x > leftLimit.position.x + Distance)
            {
                playerSelectorsDefinitive[0].numChosenAvatar--;
                playerSelectorsDefinitive[0].numChosenLevel--;
                playerSelectorsDefinitive[0].CheckAvatarDrow();
            }
            //Debug.Log(playerSelectorsDefinitive[0].numChosenAvatar);
            while (playerSelectorsDefinitive[0].transform.position.x < leftLimit.position.x + Distance)
            {
                playerSelectorsDefinitive[0].transform.position = new Vector3(playerSelectorsDefinitive[0].transform.position.x + Distance, playerSelectorsDefinitive[0].transform.position.y, playerSelectorsDefinitive[0].transform.position.z);
            }
            playerSelectorsDefinitive[0].transform.position = new Vector3(playerSelectorsDefinitive[0].transform.position.x - Distance, playerSelectorsDefinitive[0].transform.position.y, playerSelectorsDefinitive[0].transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (playerSelectorsDefinitive[0].spriteAvatar != null)
                playerSelectorsDefinitive[0].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[0].gameObject.SetActive(true);
            if (playerSelectorsDefinitive[0].spriteRenderer != null)
            playerSelectorsDefinitive[0].spriteRenderer.enabled = true;
            if (playerSelectorsDefinitive[0].transform.position.y < upLimit.position.y - Distance)
            {
                playerSelectorsDefinitive[0].numChosenAvatar = playerSelectorsDefinitive[0].numChosenAvatar + rows;
                playerSelectorsDefinitive[0].numChosenLevel = playerSelectorsDefinitive[0].numChosenLevel + rows;
                playerSelectorsDefinitive[0].CheckAvatarDrow();
            }
            //Debug.Log(playerSelectorsDefinitive[0].numChosenAvatar);
            while (playerSelectorsDefinitive[0].transform.position.y >= upLimit.position.y - Distance)
            {
                playerSelectorsDefinitive[0].transform.position = new Vector3(playerSelectorsDefinitive[0].transform.position.x, playerSelectorsDefinitive[0].transform.position.y - Distance, playerSelectorsDefinitive[0].transform.position.z);
            }
            playerSelectorsDefinitive[0].transform.position = new Vector3(playerSelectorsDefinitive[0].transform.position.x, playerSelectorsDefinitive[0].transform.position.y + Distance, playerSelectorsDefinitive[0].transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerSelectorsDefinitive[0].spriteAvatar != null)
                playerSelectorsDefinitive[0].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[0].gameObject.SetActive(true);
            if (playerSelectorsDefinitive[0].spriteRenderer != null)
            playerSelectorsDefinitive[0].spriteRenderer.enabled = true;
            if (playerSelectorsDefinitive[0].transform.position.y > downLimit.position.y +Distance)
            {
                playerSelectorsDefinitive[0].numChosenAvatar = playerSelectorsDefinitive[0].numChosenAvatar - rows;
                playerSelectorsDefinitive[0].numChosenLevel = playerSelectorsDefinitive[0].numChosenLevel - rows;
                playerSelectorsDefinitive[0].CheckAvatarDrow();
            }
            //Debug.Log(playerSelectorsDefinitive[0].numChosenAvatar);
            while (playerSelectorsDefinitive[0].transform.position.y < downLimit.position.y + Distance)
            {
                playerSelectorsDefinitive[0].transform.position = new Vector3(playerSelectorsDefinitive[0].transform.position.x, playerSelectorsDefinitive[0].transform.position.y + Distance, playerSelectorsDefinitive[0].transform.position.z);
            }
            playerSelectorsDefinitive[0].transform.position = new Vector3(playerSelectorsDefinitive[0].transform.position.x, playerSelectorsDefinitive[0].transform.position.y - Distance, playerSelectorsDefinitive[0].transform.position.z);
        }
        else if (Input.GetButtonDown("Player1-Jump"))
        {
            if (playerSelectorsDefinitive[0].spriteAvatar != null)
                playerSelectorsDefinitive[0].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[0].gameObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Player1-Dash"))
        {
            if (playerSelectorsDefinitive[0].spriteAvatar != null)
                playerSelectorsDefinitive[0].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[0].gameObject.SetActive(true);
        }
    }

    public void ControlPlayer2()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (playerSelectorsDefinitive[1].spriteAvatar != null)
                playerSelectorsDefinitive[1].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[1].gameObject.SetActive(true);
            playerSelectorsDefinitive[1].spriteRenderer.enabled = true;
            if (playerSelectorsDefinitive[1].transform.position.x < rightLimit.position.x - Distance)
            {
                playerSelectorsDefinitive[1].numChosenAvatar++;
                playerSelectorsDefinitive[1].CheckAvatarDrow();

            }

            while (playerSelectorsDefinitive[1].transform.position.x >= rightLimit.position.x - Distance)
            {
                playerSelectorsDefinitive[1].transform.position = new Vector3(playerSelectorsDefinitive[1].transform.position.x - Distance, playerSelectorsDefinitive[1].transform.position.y, playerSelectorsDefinitive[1].transform.position.z);
            }

            playerSelectorsDefinitive[1].transform.position = new Vector3(playerSelectorsDefinitive[1].transform.position.x + Distance, playerSelectorsDefinitive[1].transform.position.y, playerSelectorsDefinitive[1].transform.position.z);
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (playerSelectorsDefinitive[1].spriteAvatar != null)
                playerSelectorsDefinitive[1].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[1].gameObject.SetActive(true);
            playerSelectorsDefinitive[1].spriteRenderer.enabled = true;
            if (playerSelectorsDefinitive[1].transform.position.x > leftLimit.position.x + Distance)
            {
                playerSelectorsDefinitive[1].numChosenAvatar--;
                playerSelectorsDefinitive[1].CheckAvatarDrow();
            }

            while (playerSelectorsDefinitive[1].transform.position.x < leftLimit.position.x + Distance)
            {
                playerSelectorsDefinitive[1].transform.position = new Vector3(playerSelectorsDefinitive[1].transform.position.x + Distance, playerSelectorsDefinitive[1].transform.position.y, playerSelectorsDefinitive[1].transform.position.z);
            }

            playerSelectorsDefinitive[1].transform.position = new Vector3(playerSelectorsDefinitive[1].transform.position.x - Distance, playerSelectorsDefinitive[1].transform.position.y, playerSelectorsDefinitive[1].transform.position.z);
            
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (playerSelectorsDefinitive[1].spriteAvatar != null)
                playerSelectorsDefinitive[1].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[1].gameObject.SetActive(true);
            playerSelectorsDefinitive[1].spriteRenderer.enabled = true;
            if (playerSelectorsDefinitive[1].transform.position.y < upLimit.position.y - Distance)
            {
                playerSelectorsDefinitive[1].numChosenAvatar = playerSelectorsDefinitive[1].numChosenAvatar + rows;
                playerSelectorsDefinitive[1].CheckAvatarDrow();
            }

            while (playerSelectorsDefinitive[1].transform.position.y >= upLimit.position.y - Distance)
            {
                playerSelectorsDefinitive[1].transform.position = new Vector3(playerSelectorsDefinitive[1].transform.position.x, playerSelectorsDefinitive[1].transform.position.y - Distance, playerSelectorsDefinitive[1].transform.position.z);
            }
            playerSelectorsDefinitive[1].transform.position = new Vector3(playerSelectorsDefinitive[1].transform.position.x, playerSelectorsDefinitive[1].transform.position.y + Distance, playerSelectorsDefinitive[1].transform.position.z);
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (playerSelectorsDefinitive[1].spriteAvatar != null)
                playerSelectorsDefinitive[1].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[1].gameObject.SetActive(true);
            playerSelectorsDefinitive[1].spriteRenderer.enabled = true;
            if (playerSelectorsDefinitive[1].transform.position.y > downLimit.position.y + Distance)
            {
                playerSelectorsDefinitive[1].numChosenAvatar = playerSelectorsDefinitive[1].numChosenAvatar - rows;
                playerSelectorsDefinitive[1].CheckAvatarDrow();
            }

            while (playerSelectorsDefinitive[1].transform.position.y < downLimit.position.y + Distance)
            {
                playerSelectorsDefinitive[1].transform.position = new Vector3(playerSelectorsDefinitive[1].transform.position.x, playerSelectorsDefinitive[1].transform.position.y + Distance, playerSelectorsDefinitive[1].transform.position.z);
            }

            playerSelectorsDefinitive[1].transform.position = new Vector3(playerSelectorsDefinitive[1].transform.position.x, playerSelectorsDefinitive[1].transform.position.y - Distance, playerSelectorsDefinitive[1].transform.position.z);
            
        }
        else if (Input.GetButtonDown("Player2-Jump"))
        {
            if (playerSelectorsDefinitive[1].spriteAvatar != null)
                playerSelectorsDefinitive[1].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[1].gameObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Player2-Dash"))
        {
            if (playerSelectorsDefinitive[1].spriteAvatar != null)
                playerSelectorsDefinitive[1].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[1].gameObject.SetActive(true);
        }

    }

    public void ControlPlayer3()
    {
        //JOSTICK
        float axisHorizontalJostick1 = Input.GetAxis("Player3-LeftStick-Horizontal");
        float axisVerticalJostick1 = Input.GetAxis("Player3-LeftStick-Vertical");
        float axisLeftJostick1 = Input.GetAxis("Player3-Left");
        float axisRightJostick1 = Input.GetAxis("Player3-Right");
        float axisUpJostick1 = Input.GetAxis("Player3-Up");
        float axisDownJostick1 = Input.GetAxis("Player3-Down");
        if (Input.GetButtonDown("Player3-LeftStick-Horizontal") && axisHorizontalJostick1 > 0 || Input.GetButtonDown("Player3-Right") && axisRightJostick1 > 0)
        {
            if (playerSelectorsDefinitive[2].spriteAvatar != null)
                playerSelectorsDefinitive[2].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[2].gameObject.SetActive(true);

            while (playerSelectorsDefinitive[2].transform.position.x >= rightLimit.position.x - Distance)
            {
                playerSelectorsDefinitive[2].transform.position = new Vector3(playerSelectorsDefinitive[2].transform.position.x - Distance, playerSelectorsDefinitive[2].transform.position.y, playerSelectorsDefinitive[2].transform.position.z);
            }
            playerSelectorsDefinitive[2].transform.position = new Vector3(playerSelectorsDefinitive[2].transform.position.x + Distance, playerSelectorsDefinitive[2].transform.position.y, playerSelectorsDefinitive[2].transform.position.z);
        }
        else if (Input.GetButtonDown("Player3-LeftStick-Horizontal") && axisHorizontalJostick1 < 0 || Input.GetButtonDown("Player3-Left") && axisLeftJostick1 > 0)
        {
            if (playerSelectorsDefinitive[2].spriteAvatar != null)
                playerSelectorsDefinitive[2].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[2].gameObject.SetActive(true);

            while (playerSelectorsDefinitive[2].transform.position.x < leftLimit.position.x + Distance)
            {
                playerSelectorsDefinitive[2].transform.position = new Vector3(playerSelectorsDefinitive[2].transform.position.x + Distance, playerSelectorsDefinitive[2].transform.position.y, playerSelectorsDefinitive[2].transform.position.z);
            }
            playerSelectorsDefinitive[2].transform.position = new Vector3(playerSelectorsDefinitive[2].transform.position.x - Distance, playerSelectorsDefinitive[2].transform.position.y, playerSelectorsDefinitive[2].transform.position.z);
        }
        else if (Input.GetButtonDown("Player3-LeftStick-Vertical") && axisVerticalJostick1 > 0 || Input.GetButtonDown("Player3-Up") && axisUpJostick1 > 0)
        {
            if (playerSelectorsDefinitive[2].spriteAvatar != null)
                playerSelectorsDefinitive[2].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[2].gameObject.SetActive(true);

            while (playerSelectorsDefinitive[2].transform.position.y >= upLimit.position.y - Distance)
            {
                playerSelectorsDefinitive[2].transform.position = new Vector3(playerSelectorsDefinitive[2].transform.position.x, playerSelectorsDefinitive[2].transform.position.y - Distance, playerSelectorsDefinitive[2].transform.position.z);
            }
            playerSelectorsDefinitive[2].transform.position = new Vector3(playerSelectorsDefinitive[2].transform.position.x, playerSelectorsDefinitive[2].transform.position.y + Distance, playerSelectorsDefinitive[2].transform.position.z);
        }
        else if (Input.GetButtonDown("Player3-LeftStick-Vertical") && axisVerticalJostick1 < 0 || Input.GetButtonDown("Player3-Down") && axisDownJostick1 > 0)
        {
            if (playerSelectorsDefinitive[2].spriteAvatar != null)
                playerSelectorsDefinitive[2].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[2].gameObject.SetActive(true);

            while (playerSelectorsDefinitive[2].transform.position.y < downLimit.position.y + Distance)
            {
                playerSelectorsDefinitive[2].transform.position = new Vector3(playerSelectorsDefinitive[2].transform.position.x, playerSelectorsDefinitive[2].transform.position.y + Distance, playerSelectorsDefinitive[2].transform.position.z);
            }
            playerSelectorsDefinitive[2].transform.position = new Vector3(playerSelectorsDefinitive[2].transform.position.x, playerSelectorsDefinitive[2].transform.position.y - Distance, playerSelectorsDefinitive[2].transform.position.z);
        }
        else if (Input.GetButtonDown("Player3-Jump"))
        {
            if (playerSelectorsDefinitive[2].spriteAvatar != null)
                playerSelectorsDefinitive[2].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[2].gameObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Player3-Dash"))
        {
            if (playerSelectorsDefinitive[2].spriteAvatar != null)
                playerSelectorsDefinitive[2].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[2].gameObject.SetActive(true);
        }
    }

    public void ControlPlayer4()
    {
        //Cuando definamos los imput y sepa programarlos se hara
        //JOSTICK
        float axisHorizontalJostick2 = Input.GetAxis("Player4-LeftStick-Horizontal");
        float axisVerticalJostick2 = Input.GetAxis("Player4-LeftStick-Vertical");
        float axisLeftJostick2 = Input.GetAxis("Player4-Left");
        float axisRightJostick2 = Input.GetAxis("Player4-Right");
        float axisUpJostick2 = Input.GetAxis("Player4-Up");
        float axisDownJostick2 = Input.GetAxis("Player4-Down");

        if (Input.GetButtonDown("Player4-LeftStick-Horizontal") && axisHorizontalJostick2 > 0 || Input.GetButtonDown("Player4-Right") && axisRightJostick2 > 0)
        {
            if (playerSelectorsDefinitive[3].spriteAvatar != null)
                playerSelectorsDefinitive[3].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[3].gameObject.SetActive(true);

            while (playerSelectorsDefinitive[3].transform.position.x >= rightLimit.position.x - Distance)
            {
                playerSelectorsDefinitive[3].transform.position = new Vector3(playerSelectorsDefinitive[3].transform.position.x - Distance, playerSelectorsDefinitive[3].transform.position.y, playerSelectorsDefinitive[3].transform.position.z);
            }
            playerSelectorsDefinitive[3].transform.position = new Vector3(playerSelectorsDefinitive[3].transform.position.x + Distance, playerSelectorsDefinitive[3].transform.position.y, playerSelectorsDefinitive[3].transform.position.z);
        }
        else if (Input.GetButtonDown("Player4-LeftStick-Horizontal") && axisHorizontalJostick2 < 0 || Input.GetButtonDown("Player4-Left") && axisRightJostick2 > 0)
        {
            if (playerSelectorsDefinitive[3].spriteAvatar != null)
                playerSelectorsDefinitive[3].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[3].gameObject.SetActive(true);

            while (playerSelectorsDefinitive[3].transform.position.x < leftLimit.position.x + Distance)
            {
                playerSelectorsDefinitive[3].transform.position = new Vector3(playerSelectorsDefinitive[3].transform.position.x + Distance, playerSelectorsDefinitive[3].transform.position.y, playerSelectorsDefinitive[3].transform.position.z);
            }
            playerSelectorsDefinitive[3].transform.position = new Vector3(playerSelectorsDefinitive[3].transform.position.x - Distance, playerSelectorsDefinitive[3].transform.position.y, playerSelectorsDefinitive[3].transform.position.z);
        }
        else if (Input.GetButtonDown("Player4-LeftStick-Vertical") && axisVerticalJostick2 > 0 || Input.GetButtonDown("Player4-Up") && axisUpJostick2 > 0)
        {
            if (playerSelectorsDefinitive[3].spriteAvatar != null)
                playerSelectorsDefinitive[3].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[3].gameObject.SetActive(true);

            while (playerSelectorsDefinitive[3].transform.position.y >= upLimit.position.y - Distance)
            {
                playerSelectorsDefinitive[3].transform.position = new Vector3(playerSelectorsDefinitive[3].transform.position.x, playerSelectorsDefinitive[3].transform.position.y - Distance, playerSelectorsDefinitive[3].transform.position.z);
            }
            playerSelectorsDefinitive[3].transform.position = new Vector3(playerSelectorsDefinitive[3].transform.position.x, playerSelectorsDefinitive[3].transform.position.y + Distance, playerSelectorsDefinitive[3].transform.position.z);
        }
        else if (Input.GetButtonDown("Player4-LeftStick-Vertical") && axisVerticalJostick2 < 0 || Input.GetButtonDown("Player4-Down") && axisDownJostick2 > 0)
        {
            if (playerSelectorsDefinitive[3].spriteAvatar != null)
                playerSelectorsDefinitive[3].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[3].gameObject.SetActive(true);

            while (playerSelectorsDefinitive[3].transform.position.y < downLimit.position.y + Distance)
            {
                playerSelectorsDefinitive[3].transform.position = new Vector3(playerSelectorsDefinitive[3].transform.position.x, playerSelectorsDefinitive[3].transform.position.y + Distance, playerSelectorsDefinitive[3].transform.position.z);
            }
            playerSelectorsDefinitive[3].transform.position = new Vector3(playerSelectorsDefinitive[3].transform.position.x, playerSelectorsDefinitive[3].transform.position.y - Distance, playerSelectorsDefinitive[3].transform.position.z);
        }
        else if (Input.GetButtonDown("Player4-Jump"))
        {
            if (playerSelectorsDefinitive[3].spriteAvatar != null)
                playerSelectorsDefinitive[3].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[3].gameObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Player4-Dash"))
        {
            if (playerSelectorsDefinitive[3].spriteAvatar != null)
                playerSelectorsDefinitive[3].spriteAvatar.SetActive(true);
            playerSelectorsDefinitive[3].gameObject.SetActive(true);
        }
    }

    public void CheckControlsPlayer()
    {
        if (playersMovement[0] && playerSelectorsDefinitive[0] != null)
        {
            ControlPlayer1();
        }
        if (playersMovement[1] && playerSelectorsDefinitive[1] != null)
        {
            ControlPlayer2();
        }
        if (playersMovement[2] && playerSelectorsDefinitive[2] != null)
        {
            ControlPlayer3();
        }
        if (playersMovement[3] && playerSelectorsDefinitive[3] != null)
        {
            ControlPlayer4();
        }
        //Agregar mas ifs y mas boleanos de movements a medida que se vayan agregando jugadores
        //el boleano que corresponda a cada jugador es seteado en la clase SelectorPlayer.cs
        //por cada boleano movement nuevo hacer un set y un get ademas de fijarse como setearlo en la clase SelectorPlayer.cs tomando en cuenta el patron
        //ya escrito.
        // NOTA DC: El comentario anterior está por quedar obsoleto ya que estoy pasando todo a listas y no variables individuales
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
