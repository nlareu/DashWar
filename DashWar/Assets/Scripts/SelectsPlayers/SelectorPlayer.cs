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

    /// <summary>
    /// Selects the avatar in the selection menu.
    /// </summary>
    /// <param name="numAvatar">The avatar to be chosen.</param>
    public void Selector(int numAvatar)
    {
        if (movement)
        {            
            if (Input.GetButtonDown("Player" + this.numPlayer + "-Dash"))
            {
                spriteAvatar.SetActive(false);
                //El numAvatar que se setea en el SetPlayer representa el avatar que tendra ese jugador.
                DataLevel.InstanceDataLevel.SetPlayerByNumber(this.numPlayer, numAvatar);
                movement = false;
                selectAvatar.SetMovement(this.numPlayer, false);
                app.InstanciarJugador(this.numPlayer, false);
                //selectCantPlayerDefinitive.SetSubstract(false);
                app.activateAvatarController = true;
                app.cancelSelectionAvatarControllers[this.numPlayer - 1] = true;

                //Debug.Log("El jugador 1 se ha decidido, reproducir sonido");
                AudioManager.instance.PlaySpecialEffect(selectionSound);
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
