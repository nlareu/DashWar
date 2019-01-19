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
    
    public SelectorPlayer spriteSelectAvatar1;
    public SelectorPlayer spriteSelectAvatar2;
    public SelectorPlayer spriteSelectAvatar3;
    public SelectorPlayer spriteSelectAvatar4;
    public Transform upLimit;
    public Transform downLimit;
    public Transform leftLimit;
    public Transform rightLimit;
    public float Distance;
    private bool Movement1;
    private bool Movement2;
    private bool Movement3;
    private bool Movement4;

    // Update is called once per frame
    private void Start()
    {
        //spriteSelectAvatar1.CheckAvatarDrow();
        spriteSelectAvatar1.spriteRenderer.enabled = true;
        spriteSelectAvatar1.numChosenAvatar = 0;
        spriteSelectAvatar2.numChosenAvatar = 1;
        spriteSelectAvatar3.numChosenAvatar = 2;
        spriteSelectAvatar4.numChosenAvatar = 3;
        Movement1 = true;
        Movement2 = true;
        Movement3 = true;
        Movement4 = true;
        //DESCOMENTAR EN CASO QUE SE PIDA QUE TAMBIEN TENGAS QUE MOVER EL CONTROLADOR DEL CURSOR 1 PARA ACTIVARLO.
        //spriteSelectAvatar1.SetActive(false);
        spriteSelectAvatar2.gameObject.SetActive(false);
        spriteSelectAvatar3.gameObject.SetActive(false);
        spriteSelectAvatar4.gameObject.SetActive(false);
    }
    void Update () {
        CheckControlsPlayer();
    }

    public void ControlPlayer1()
    {
        

        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteSelectAvatar1.gameObject.SetActive(true);
            spriteSelectAvatar1.spriteRenderer.enabled = true;
            if (spriteSelectAvatar1.transform.position.x < rightLimit.position.x - Distance)
            {
                spriteSelectAvatar1.numChosenAvatar++;
                spriteSelectAvatar1.CheckAvatarDrow();
                
            }
            //Debug.Log(spriteSelectAvatar1.numChosenAvatar);
            while (spriteSelectAvatar1.transform.position.x >= rightLimit.position.x - Distance)
            {
                spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x - Distance, spriteSelectAvatar1.transform.position.y, spriteSelectAvatar1.transform.position.z);
            }
            spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x + Distance, spriteSelectAvatar1.transform.position.y, spriteSelectAvatar1.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteSelectAvatar1.gameObject.SetActive(true);
            spriteSelectAvatar1.spriteRenderer.enabled = true;
            if (spriteSelectAvatar1.transform.position.x > leftLimit.position.x + Distance)
            {
                spriteSelectAvatar1.numChosenAvatar--;
                spriteSelectAvatar1.CheckAvatarDrow();
            }
            //Debug.Log(spriteSelectAvatar1.numChosenAvatar);
            while (spriteSelectAvatar1.transform.position.x < leftLimit.position.x + Distance)
            {
                spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x + Distance, spriteSelectAvatar1.transform.position.y, spriteSelectAvatar1.transform.position.z);
            }
            spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x - Distance, spriteSelectAvatar1.transform.position.y, spriteSelectAvatar1.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            spriteSelectAvatar1.gameObject.SetActive(true);
            spriteSelectAvatar1.spriteRenderer.enabled = true;
            if (spriteSelectAvatar1.transform.position.y < upLimit.position.y - Distance)
            {
                spriteSelectAvatar1.numChosenAvatar = spriteSelectAvatar1.numChosenAvatar + rows;
                spriteSelectAvatar1.CheckAvatarDrow();
            }
            //Debug.Log(spriteSelectAvatar1.numChosenAvatar);
            while (spriteSelectAvatar1.transform.position.y >= upLimit.position.y - Distance)
            {
                spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x, spriteSelectAvatar1.transform.position.y - Distance, spriteSelectAvatar1.transform.position.z);
            }
            spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x, spriteSelectAvatar1.transform.position.y + Distance, spriteSelectAvatar1.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            spriteSelectAvatar1.gameObject.SetActive(true);
            spriteSelectAvatar1.spriteRenderer.enabled = true;
            if (spriteSelectAvatar1.transform.position.y > downLimit.position.y +Distance)
            {
                spriteSelectAvatar1.numChosenAvatar = spriteSelectAvatar1.numChosenAvatar - rows;
                spriteSelectAvatar1.CheckAvatarDrow();
            }
            //Debug.Log(spriteSelectAvatar1.numChosenAvatar);
            while (spriteSelectAvatar1.transform.position.y < downLimit.position.y + Distance)
            {
                spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x, spriteSelectAvatar1.transform.position.y + Distance, spriteSelectAvatar1.transform.position.z);
            }
            spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x, spriteSelectAvatar1.transform.position.y - Distance, spriteSelectAvatar1.transform.position.z);
        }
        else if (Input.GetButtonDown("Player1-Jump"))
        {
            spriteSelectAvatar1.gameObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Player1-Dash"))
        {
            spriteSelectAvatar1.gameObject.SetActive(true);
        }
    }

    public void ControlPlayer2()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteSelectAvatar2.gameObject.SetActive(true);
            spriteSelectAvatar2.spriteRenderer.enabled = true;
            if (spriteSelectAvatar2.transform.position.x < rightLimit.position.x - Distance)
            {
                spriteSelectAvatar2.numChosenAvatar++;
                spriteSelectAvatar2.CheckAvatarDrow();

            }

            while (spriteSelectAvatar2.transform.position.x >= rightLimit.position.x - Distance)
            {
                spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x - Distance, spriteSelectAvatar2.transform.position.y, spriteSelectAvatar2.transform.position.z);
            }

            spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x + Distance, spriteSelectAvatar2.transform.position.y, spriteSelectAvatar2.transform.position.z);
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteSelectAvatar2.gameObject.SetActive(true);
            spriteSelectAvatar2.spriteRenderer.enabled = true;
            if (spriteSelectAvatar2.transform.position.x > leftLimit.position.x + Distance)
            {
                spriteSelectAvatar2.numChosenAvatar--;
                spriteSelectAvatar2.CheckAvatarDrow();
            }

            while (spriteSelectAvatar2.transform.position.x < leftLimit.position.x + Distance)
            {
                spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x + Distance, spriteSelectAvatar2.transform.position.y, spriteSelectAvatar2.transform.position.z);
            }

            spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x - Distance, spriteSelectAvatar2.transform.position.y, spriteSelectAvatar2.transform.position.z);
            
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            spriteSelectAvatar2.gameObject.SetActive(true);
            spriteSelectAvatar2.spriteRenderer.enabled = true;
            if (spriteSelectAvatar2.transform.position.y < upLimit.position.y - Distance)
            {
                spriteSelectAvatar2.numChosenAvatar = spriteSelectAvatar2.numChosenAvatar + rows;
                spriteSelectAvatar2.CheckAvatarDrow();
            }

            while (spriteSelectAvatar2.transform.position.y >= upLimit.position.y - Distance)
            {
                spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x, spriteSelectAvatar2.transform.position.y - Distance, spriteSelectAvatar2.transform.position.z);
            }
            spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x, spriteSelectAvatar2.transform.position.y + Distance, spriteSelectAvatar2.transform.position.z);
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            spriteSelectAvatar2.gameObject.SetActive(true);
            spriteSelectAvatar2.spriteRenderer.enabled = true;
            if (spriteSelectAvatar2.transform.position.y > downLimit.position.y + Distance)
            {
                spriteSelectAvatar2.numChosenAvatar = spriteSelectAvatar2.numChosenAvatar - rows;
                spriteSelectAvatar2.CheckAvatarDrow();
            }

            while (spriteSelectAvatar2.transform.position.y < downLimit.position.y + Distance)
            {
                spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x, spriteSelectAvatar2.transform.position.y + Distance, spriteSelectAvatar2.transform.position.z);
            }

            spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x, spriteSelectAvatar2.transform.position.y - Distance, spriteSelectAvatar2.transform.position.z);
            
        }
        else if (Input.GetButtonDown("Player2-Jump"))
        {
            spriteSelectAvatar2.gameObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Player2-Dash"))
        {
            spriteSelectAvatar2.gameObject.SetActive(true);
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
            spriteSelectAvatar3.gameObject.SetActive(true);

            while (spriteSelectAvatar3.transform.position.x >= rightLimit.position.x - Distance)
            {
                spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x - Distance, spriteSelectAvatar3.transform.position.y, spriteSelectAvatar3.transform.position.z);
            }
            spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x + Distance, spriteSelectAvatar3.transform.position.y, spriteSelectAvatar3.transform.position.z);
        }
        else if (Input.GetButtonDown("Player3-LeftStick-Horizontal") && axisHorizontalJostick1 < 0 || Input.GetButtonDown("Player3-Left") && axisLeftJostick1 > 0)
        {
            spriteSelectAvatar3.gameObject.SetActive(true);

            while (spriteSelectAvatar3.transform.position.x < leftLimit.position.x + Distance)
            {
                spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x + Distance, spriteSelectAvatar3.transform.position.y, spriteSelectAvatar3.transform.position.z);
            }
            spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x - Distance, spriteSelectAvatar3.transform.position.y, spriteSelectAvatar3.transform.position.z);
        }
        else if (Input.GetButtonDown("Player3-LeftStick-Vertical") && axisVerticalJostick1 > 0 || Input.GetButtonDown("Player3-Up") && axisUpJostick1 > 0)
        {
            spriteSelectAvatar3.gameObject.SetActive(true);

            while (spriteSelectAvatar3.transform.position.y >= upLimit.position.y - Distance)
            {
                spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x, spriteSelectAvatar3.transform.position.y - Distance, spriteSelectAvatar3.transform.position.z);
            }
            spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x, spriteSelectAvatar3.transform.position.y + Distance, spriteSelectAvatar3.transform.position.z);
        }
        else if (Input.GetButtonDown("Player3-LeftStick-Vertical") && axisVerticalJostick1 < 0 || Input.GetButtonDown("Player3-Down") && axisDownJostick1 > 0)
        {
            spriteSelectAvatar3.gameObject.SetActive(true);

            while (spriteSelectAvatar3.transform.position.y < downLimit.position.y + Distance)
            {
                spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x, spriteSelectAvatar3.transform.position.y + Distance, spriteSelectAvatar3.transform.position.z);
            }
            spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x, spriteSelectAvatar3.transform.position.y - Distance, spriteSelectAvatar3.transform.position.z);
        }
        else if (Input.GetButtonDown("Player3-Jump"))
        {
            spriteSelectAvatar3.gameObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Player3-Dash"))
        {
            spriteSelectAvatar3.gameObject.SetActive(true);
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
            spriteSelectAvatar4.gameObject.SetActive(true);

            while (spriteSelectAvatar4.transform.position.x >= rightLimit.position.x - Distance)
            {
                spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x - Distance, spriteSelectAvatar4.transform.position.y, spriteSelectAvatar4.transform.position.z);
            }
            spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x + Distance, spriteSelectAvatar4.transform.position.y, spriteSelectAvatar4.transform.position.z);
        }
        else if (Input.GetButtonDown("Player4-LeftStick-Horizontal") && axisHorizontalJostick2 < 0 || Input.GetButtonDown("Player4-Left") && axisRightJostick2 > 0)
        {
            spriteSelectAvatar4.gameObject.SetActive(true);

            while (spriteSelectAvatar4.transform.position.x < leftLimit.position.x + Distance)
            {
                spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x + Distance, spriteSelectAvatar4.transform.position.y, spriteSelectAvatar4.transform.position.z);
            }
            spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x - Distance, spriteSelectAvatar4.transform.position.y, spriteSelectAvatar4.transform.position.z);
        }
        else if (Input.GetButtonDown("Player4-LeftStick-Vertical") && axisVerticalJostick2 > 0 || Input.GetButtonDown("Player4-Up") && axisUpJostick2 > 0)
        {
            spriteSelectAvatar4.gameObject.SetActive(true);

            while (spriteSelectAvatar4.transform.position.y >= upLimit.position.y - Distance)
            {
                spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x, spriteSelectAvatar4.transform.position.y - Distance, spriteSelectAvatar4.transform.position.z);
            }
            spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x, spriteSelectAvatar4.transform.position.y + Distance, spriteSelectAvatar4.transform.position.z);
        }
        else if (Input.GetButtonDown("Player4-LeftStick-Vertical") && axisVerticalJostick2 < 0 || Input.GetButtonDown("Player4-Down") && axisDownJostick2 > 0)
        {
            spriteSelectAvatar4.gameObject.SetActive(true);

            while (spriteSelectAvatar4.transform.position.y < downLimit.position.y + Distance)
            {
                spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x, spriteSelectAvatar4.transform.position.y + Distance, spriteSelectAvatar4.transform.position.z);
            }
            spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x, spriteSelectAvatar4.transform.position.y - Distance, spriteSelectAvatar4.transform.position.z);
        }
        else if (Input.GetButtonDown("Player4-Jump"))
        {
            spriteSelectAvatar4.gameObject.SetActive(true);
        }
        else if (Input.GetButtonDown("Player4-Dash"))
        {
            spriteSelectAvatar4.gameObject.SetActive(true);
        }
    }

    public void CheckControlsPlayer()
    {
        if (Movement1)
        {
            ControlPlayer1();
        }
        if (Movement2)
        {
            ControlPlayer2();
        }
        if (Movement3)
        {
            ControlPlayer3();
        }
        if (Movement4)
        {
            ControlPlayer4();
        }
        //Agregar mas ifs y mas boleanos de movements a medida que se vayan agregando jugadores
        //el boleano que corresponda a cada jugador es seteado en la clase SelectorPlayer.cs

        //por cada boleano movement nuevo hacer un set y un get ademas de fijarse como setearlo en la clase SelectorPlayer.cs tomando en cuenta el patron
        //ya escrito.
    }

    public void SetMovement1(bool _movement)
    {
        Movement1 = _movement;
    }
    public bool GetMovement1()
    {
        return Movement1;
    }
    public void SetMovement2(bool _movement)
    {
        Movement2 = _movement;
    }
    public bool GetMovement2()
    {
        return Movement2;
    }
    public void SetMovement3(bool _movement)
    {
        Movement3 = _movement;
    }
    public bool GetMovement3()
    {
        return Movement3;
    }
    public void SetMovement4(bool _movement)
    {
        Movement4 = _movement;
    }
    public bool GetMovement4()
    {
        return Movement4;
    }
}
