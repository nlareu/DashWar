using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorPlayer : MonoBehaviour {

    // Use this for initialization

    //numero del personaje elejido
    public GameObject spriteAvatar;
    public Sprite transparent;
    public SpriteRenderer background;
    public bool screenSelectLevel;
    public bool screenSelectAvatar;
    public int numChosenAvatar;
    public int numChosenLevel;
    public int numPlayer;
    public SelectAvatarDefinitive selectAvatar;
    private bool Movement;
    private bool activate;
    private bool select;
    //Aqui poner los Sprites idle de todos los avatars
    //(IMPORTANTE QUE SE AGREGUEN ORDENADAMENTE TIENEN QUE ESTAR EN EL MISMO ORDEN QUE LOS PREFABS DE AVATARS)
    public List<Sprite> avatarSprite;
    public List<Sprite> levels;
    public SpriteRenderer spriteRenderer;
    public AppController app;
    public SelectCantPlayerDefinitive selectCantPlayerDefinitive;
    protected bool activateCollision;
    private void Start()
    {
        Movement = true;
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        //numChosenAvatar = 0;
    }
    private void Update()
    {
        if (screenSelectAvatar)
        {
            CheckSelector();
        }
        if (screenSelectLevel)
        {
            CheckSelectorLevel();
        }
    }
    public void Selector(int numAvatar)
    {
        //SI HAY LA CAPACIDAD DE JUGADORES ES MAYOR AGREGAR UN IF CON OTRO NUM PLAYER
        if (Movement)
        {

            if (numPlayer == 1)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    spriteAvatar.SetActive(false);
                    //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                    DataLevel.InstanceDataLevel.SetPlayer1(numAvatar);
                    Movement = false;
                    selectAvatar.SetMovement1(false);
                    app.InstanciarJugador1(false);
                    //selectCantPlayerDefinitive.SetSubstract(false);
                    app.activateAvatarController = true;
                    app.cancelSelectionAvatarController1 = true;
                   
                }
            }
            if (numPlayer == 2)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    spriteAvatar.SetActive(false);
                    //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                    DataLevel.InstanceDataLevel.SetPlayer2(numAvatar);
                    Movement = false;
                    selectAvatar.SetMovement2(false);
                    app.InstanciarJugador2(false);                
                    //selectCantPlayerDefinitive.SetSubstract(false);
                    app.activateAvatarController = true;
                    app.cancelSelectionAvatarController2 = true;
                    
                }
            }
            if (numPlayer == 3)
            {
                float axisButtonXJostick1 = Input.GetAxis("Player3-Dash");
            
                //Cambiar la G por la condicion correspondiente del JOSTICK(El boton de dash del jostick)
                if (Input.GetButtonDown("Player3-Dash") || axisButtonXJostick1 > 0)
                {
                    spriteAvatar.SetActive(false);
                    //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                    DataLevel.InstanceDataLevel.SetPlayer3(numAvatar);
                    Movement = false;
                    selectAvatar.SetMovement3(false);
                    app.InstanciarJugador3(false);
                    //selectCantPlayerDefinitive.SetSubstract(false);
                    app.activateAvatarController = true;
                    app.cancelSelectionAvatarController3 = true;
                    
                }
            }
            if (numPlayer == 4)
            {
                float axisButtonXJostick2 = Input.GetAxis("Player4-Dash");
                //Cambiar la G por la condicion correspondiente del JOSTICK
                if (Input.GetButtonDown("Player4-Dash") || axisButtonXJostick2 > 0)
                {
                    spriteAvatar.SetActive(false);
                    //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                    DataLevel.InstanceDataLevel.SetPlayer4(numAvatar);
                    Movement = false;
                    selectAvatar.SetMovement4(false);
                    app.InstanciarJugador4(false);
                    //selectCantPlayerDefinitive.SetSubstract(false);
                    app.activateAvatarController = true;
                    app.cancelSelectionAvatarController4 = true;
                    
                    
                }
            }
        }
    }
    public void CheckAvatarDrow()
    {
        if(numChosenAvatar <= avatarSprite.Count - 1 && numChosenAvatar >= 0)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = avatarSprite[numChosenAvatar];
            }
        }
    }
    
    public void CheckSelector()
    {
        if(numChosenAvatar <= avatarSprite.Count - 1 && numChosenAvatar >= 0)
        {
            Selector(numChosenAvatar);
        }
    }
    public void CheckSelectorLevel()
    {
        if (numChosenLevel <= levels.Count - 1 && numChosenLevel >= 0)
        {
            SelectorLevel();
            if (background != null)
            {
                background.sprite = levels[numChosenLevel];
            }
        }
        else
        {
            background.sprite = transparent;
        }
    }
    public void SelectorLevel()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // LISTADO DE NIVELES (por cada nuevo nivel que se agregue al juego agregarle un CASE al switch).
            switch(numChosenLevel)
            {
                case 0:
                    SceneManager.LoadScene("Lvl01-Level-01");
                   break;
                case 1:
                    SceneManager.LoadScene("Lvl02-Level-02-Snow");
                    break;
            }
        }
    }
    /*private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            //Se fije que player selecciono el Avatar 1
            case "SelectAvatar_1":
                Selector(0);
                spriteRenderer.sprite = avatarSprite[0];
                spriteRenderer.enabled = true;
                break;
            case "SelectAvatar_2":
                Selector(1);
                spriteRenderer.sprite = avatarSprite[1];
                spriteRenderer.enabled = true;
                break;
            case "SelectAvatar_3":
                Selector(2);
                spriteRenderer.sprite = avatarSprite[2];
                spriteRenderer.enabled = true;
                break;
            case "SelectAvatar_4":
                Selector(3);
                spriteRenderer.sprite = avatarSprite[3];
                spriteRenderer.enabled = true;
                break;
        }
    }*/
    public void SetMovement(bool _movement)
    {
        Movement = _movement;
    }
    public bool GetMovement()
    {
        return Movement;
    }
}
