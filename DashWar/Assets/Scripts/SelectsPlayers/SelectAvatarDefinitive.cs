using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvatarDefinitive : MonoBehaviour {

    // Use this for initialization
    public GameObject spriteSelectAvatar1;
    public GameObject spriteSelectAvatar2;
    public GameObject spriteSelectAvatar3;
    public GameObject spriteSelectAvatar4;
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
        Movement1 = true;
        Movement2 = true;
        Movement3 = true;
        Movement4 = true;
    }
    void Update () {
        CheckControlsPlayer();
    }

    public void ControlPlayer1()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            while (spriteSelectAvatar1.transform.position.x >= rightLimit.position.x - Distance)
            {
                spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x - Distance, spriteSelectAvatar1.transform.position.y, spriteSelectAvatar1.transform.position.z);
            }
            spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x + Distance, spriteSelectAvatar1.transform.position.y, spriteSelectAvatar1.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            while (spriteSelectAvatar1.transform.position.x < leftLimit.position.x + Distance)
            {
                spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x + Distance, spriteSelectAvatar1.transform.position.y, spriteSelectAvatar1.transform.position.z);
            }
            spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x - Distance, spriteSelectAvatar1.transform.position.y, spriteSelectAvatar1.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            while (spriteSelectAvatar1.transform.position.y >= upLimit.position.y - Distance)
            {
                spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x, spriteSelectAvatar1.transform.position.y - Distance, spriteSelectAvatar1.transform.position.z);
            }
            spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x, spriteSelectAvatar1.transform.position.y + Distance, spriteSelectAvatar1.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            while (spriteSelectAvatar1.transform.position.y < downLimit.position.y + Distance)
            {
                spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x, spriteSelectAvatar1.transform.position.y + Distance, spriteSelectAvatar1.transform.position.z);
            }
            spriteSelectAvatar1.transform.position = new Vector3(spriteSelectAvatar1.transform.position.x, spriteSelectAvatar1.transform.position.y - Distance, spriteSelectAvatar1.transform.position.z);
        }
    }

    public void ControlPlayer2()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            while (spriteSelectAvatar2.transform.position.x >= rightLimit.position.x-Distance)
            {
                spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x - Distance, spriteSelectAvatar2.transform.position.y, spriteSelectAvatar2.transform.position.z);
            }
            spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x + Distance, spriteSelectAvatar2.transform.position.y, spriteSelectAvatar2.transform.position.z);     
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            while(spriteSelectAvatar2.transform.position.x < leftLimit.position.x + Distance)
            {
                spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x + Distance, spriteSelectAvatar2.transform.position.y, spriteSelectAvatar2.transform.position.z);
            }
            spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x - Distance, spriteSelectAvatar2.transform.position.y, spriteSelectAvatar2.transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            while(spriteSelectAvatar2.transform.position.y >= upLimit.position.y - Distance)
            {
                spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x, spriteSelectAvatar2.transform.position.y - Distance, spriteSelectAvatar2.transform.position.z);
            }
            spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x, spriteSelectAvatar2.transform.position.y + Distance, spriteSelectAvatar2.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            while(spriteSelectAvatar2.transform.position.y < downLimit.position.y + Distance)
            {
                spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x, spriteSelectAvatar2.transform.position.y + Distance, spriteSelectAvatar2.transform.position.z);
            }
            spriteSelectAvatar2.transform.position = new Vector3(spriteSelectAvatar2.transform.position.x, spriteSelectAvatar2.transform.position.y - Distance, spriteSelectAvatar2.transform.position.z);
        }
    }

    public void ControlPlayer3()
    {
        //JOSTICK
        float axisHorizontalJostick1 = Input.GetAxis("Jostick1-LeftStick_Horizontal");
        float axisVerticalJostick1 = Input.GetAxis("Jostick1-LeftStick_Vertical");
        if (Input.GetButtonDown("Jostick1-LeftStick_Horizontal") && axisHorizontalJostick1 > 0)
        {
            while (spriteSelectAvatar3.transform.position.x >= rightLimit.position.x - Distance)
            {
                spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x - Distance, spriteSelectAvatar3.transform.position.y, spriteSelectAvatar3.transform.position.z);
            }
            spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x + Distance, spriteSelectAvatar3.transform.position.y, spriteSelectAvatar3.transform.position.z);
        }
        else if (Input.GetButtonDown("Jostick1-LeftStick_Horizontal") && axisHorizontalJostick1 < 0)
        {
            while (spriteSelectAvatar3.transform.position.x < leftLimit.position.x + Distance)
            {
                spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x + Distance, spriteSelectAvatar3.transform.position.y, spriteSelectAvatar3.transform.position.z);
            }
            spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x - Distance, spriteSelectAvatar3.transform.position.y, spriteSelectAvatar3.transform.position.z);
        }
        else if (Input.GetButtonDown("Jostick1-LeftStick_Vertical") && axisVerticalJostick1 > 0)
        {
            while (spriteSelectAvatar3.transform.position.y >= upLimit.position.y - Distance)
            {
                spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x, spriteSelectAvatar3.transform.position.y - Distance, spriteSelectAvatar3.transform.position.z);
            }
            spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x, spriteSelectAvatar3.transform.position.y + Distance, spriteSelectAvatar3.transform.position.z);
        }
        else if (Input.GetButtonDown("Jostick1-LeftStick_Vertical") && axisVerticalJostick1 < 0)
        {
            while (spriteSelectAvatar3.transform.position.y < downLimit.position.y + Distance)
            {
                spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x, spriteSelectAvatar3.transform.position.y + Distance, spriteSelectAvatar3.transform.position.z);
            }
            spriteSelectAvatar3.transform.position = new Vector3(spriteSelectAvatar3.transform.position.x, spriteSelectAvatar3.transform.position.y - Distance, spriteSelectAvatar3.transform.position.z);
        }
    }

    public void ControlPlayer4()
    {
        //Cuando definamos los imput y sepa programarlos se hara
        //JOSTICK
        float axisHorizontalJostick2 = Input.GetAxis("Jostick2-LeftStick_Horizontal");
        float axisVerticalJostick2 = Input.GetAxis("Jostick2-LeftStick_Vertical");
        if (Input.GetButtonDown("Jostick2-LeftStick_Horizontal") && axisHorizontalJostick2 > 0)
        {
            while (spriteSelectAvatar4.transform.position.x >= rightLimit.position.x - Distance)
            {
                spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x - Distance, spriteSelectAvatar4.transform.position.y, spriteSelectAvatar4.transform.position.z);
            }
            spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x + Distance, spriteSelectAvatar4.transform.position.y, spriteSelectAvatar4.transform.position.z);
        }
        else if (Input.GetButtonDown("Jostick2-LeftStick_Horizontal") && axisHorizontalJostick2 < 0)
        {
            while (spriteSelectAvatar4.transform.position.x < leftLimit.position.x + Distance)
            {
                spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x + Distance, spriteSelectAvatar4.transform.position.y, spriteSelectAvatar4.transform.position.z);
            }
            spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x - Distance, spriteSelectAvatar4.transform.position.y, spriteSelectAvatar4.transform.position.z);
        }
        else if (Input.GetButtonDown("Jostick2-LeftStick_Vertical") && axisVerticalJostick2 > 0)
        {
            while (spriteSelectAvatar4.transform.position.y >= upLimit.position.y - Distance)
            {
                spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x, spriteSelectAvatar4.transform.position.y - Distance, spriteSelectAvatar4.transform.position.z);
            }
            spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x, spriteSelectAvatar4.transform.position.y + Distance, spriteSelectAvatar4.transform.position.z);
        }
        else if (Input.GetButtonDown("Jostick2-LeftStick_Vertical") && axisVerticalJostick2 < 0)
        {
            while (spriteSelectAvatar4.transform.position.y < downLimit.position.y + Distance)
            {
                spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x, spriteSelectAvatar4.transform.position.y + Distance, spriteSelectAvatar4.transform.position.z);
            }
            spriteSelectAvatar4.transform.position = new Vector3(spriteSelectAvatar4.transform.position.x, spriteSelectAvatar4.transform.position.y - Distance, spriteSelectAvatar4.transform.position.z);
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
