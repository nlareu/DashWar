using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorPlayer : MonoBehaviour {

    #region Fields

    [Header("General")]
    public bool screenSelectLevel;
    public bool screenSelectAvatar;
    public AppController app;

    [Header("Selección de Avatar")]
    //numero del personaje elegido
    public GameObject spriteAvatar;    
    public int numChosenAvatar;    
    public int numPlayer;
    public SelectAvatarDefinitive selectAvatar;

    //Aqui poner los Sprites idle de todos los avatars
    //(IMPORTANTE QUE SE AGREGUEN ORDENADAMENTE TIENEN QUE ESTAR EN EL MISMO ORDEN QUE LOS PREFABS DE AVATARS)
    public List<Sprite> avatarSprite;    
    public SpriteRenderer spriteRenderer;    
    public SelectCantPlayerDefinitive selectCantPlayerDefinitive;
    protected bool activateCollision;

    private bool movement;
    private bool activate;
    private bool select;

    [Header("Niveles")]
    public int numChosenLevel;
    public Sprite transparent;
    public SpriteRenderer background;
    public List<Sprite> levels;
    public string level01Name = "Lvl01-Level-01";
    public string level02Name = "Lvl02-Level-02-Snow";

    [Header("Sonidos")]
    public AudioClip selectionSound;

    #endregion

    #region Properties

    /// <summary>
    /// Activates/Deactivates the movement of the Selector.
    /// </summary>
    public bool Movement
    {
        get
        {
            return movement;
        }
        set
        {
            movement = value;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    private void Start()
    {
        movement = true;

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        //numChosenAvatar = 0;
    }

    /// <summary>
    /// Update runs once per frame, the main logic goes here.
    /// </summary>
    private void Update()
    {
        if (screenSelectAvatar)
        {
            CheckSelector();
        }
        else if (screenSelectLevel)
        {
            CheckSelectorLevel();
        }
    }

    public void Selector(int numAvatar)
    {
        //SI HAY LA CAPACIDAD DE JUGADORES ES MAYOR AGREGAR UN IF CON OTRO NUM PLAYER
        // Observación (Por hacer): Para lo señalado en el comentario anterior, sería
        // más eficiente el uso de un for loop que itere según el número de jugadores
        if (movement)
        {

            if (numPlayer == 1)
            {
                if (Input.GetButtonDown("Player1-Dash"))
                {
                    spriteAvatar.SetActive(false);
                    //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                    DataLevel.InstanceDataLevel.SetPlayerByNumber(1, numAvatar);
                    movement = false;
                    selectAvatar.SetMovement(1, false);
                    app.InstanciarJugador(1, false);
                    //selectCantPlayerDefinitive.SetSubstract(false);
                    app.activateAvatarController = true;
                    app.cancelSelectionAvatarControllers[0] = true;

                    //Debug.Log("El jugador 1 se ha decidido, reproducir sonido");
                    AudioManager.instance.PlaySpecialEffect(selectionSound);
                }
            }

            if (numPlayer == 2)
            {
                if (Input.GetButtonDown("Player2-Dash"))
                {
                    spriteAvatar.SetActive(false);
                    //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                    DataLevel.InstanceDataLevel.SetPlayerByNumber(2, numAvatar);
                    movement = false;
                    selectAvatar.SetMovement(2, false);
                    app.InstanciarJugador(2, false);
                    //selectCantPlayerDefinitive.SetSubstract(false);
                    app.activateAvatarController = true;
                    app.cancelSelectionAvatarControllers[1] = true;

                    //Debug.Log("Jugador 2 ya decdido");
                    AudioManager.instance.PlaySpecialEffect(selectionSound);
                }
            }

            if (numPlayer == 3)
            {
                float axisButtonXJostick1 = Input.GetAxis("Player3-Dash");
            
                //Cambiar la G por la condicion correspondiente del JOSTICK(El boton de dash del jostick)
                if (Input.GetButtonDown("Player3-Dash") || axisButtonXJostick1 > 0 /*|| Input.GetKeyDown(KeyCode.T)*/)
                {
                    spriteAvatar.SetActive(false);
                    //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                    DataLevel.InstanceDataLevel.SetPlayerByNumber(3, numAvatar);
                    movement = false;
                    selectAvatar.SetMovement(3, false);
                    app.InstanciarJugador(3, false);
                    //selectCantPlayerDefinitive.SetSubstract(false);
                    app.activateAvatarController = true;
                    app.cancelSelectionAvatarControllers[2] = true;

                    AudioManager.instance.PlaySpecialEffect(selectionSound);
                }
            }

            if (numPlayer == 4)
            {
                float axisButtonXJostick2 = Input.GetAxis("Player4-Dash");
                //Cambiar la G por la condicion correspondiente del JOSTICK
                if (Input.GetButtonDown("Player4-Dash") || axisButtonXJostick2 > 0 /*|| Input.GetKeyDown(KeyCode.Y)*/)
                {
                    spriteAvatar.SetActive(false);
                    //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                    DataLevel.InstanceDataLevel.SetPlayerByNumber(4, numAvatar);
                    movement = false;
                    selectAvatar.SetMovement(4, false);
                    app.InstanciarJugador(4, false);
                    //selectCantPlayerDefinitive.SetSubstract(false);
                    app.activateAvatarController = true;
                    app.cancelSelectionAvatarControllers[3] = true;

                    AudioManager.instance.PlaySpecialEffect(selectionSound);
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

    /// <summary>
    /// Loads the selected level.
    /// </summary>
    public void SelectorLevel()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // LISTADO DE NIVELES (por cada nuevo nivel que se agregue al juego agregarle un CASE al switch).
            // Observación (Por hacer): No hardcodear los nombres de los niveles, usar variables en su lugar
            switch(numChosenLevel)
            {
                case 0:
                    AudioManager.instance.PlaySpecialEffect(selectionSound);
                    SceneManager.LoadScene(level01Name);
                    break;
                case 1:
                    AudioManager.instance.PlaySpecialEffect(selectionSound);
                    SceneManager.LoadScene(level02Name);
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

    #endregion
}
