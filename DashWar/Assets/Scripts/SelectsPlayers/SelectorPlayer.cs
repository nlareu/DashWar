using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorPlayer : MonoBehaviour {

    #region Fields

    [Header("Modalidad")]
    public bool screenSelectLevel;
    public bool screenSelectAvatar;

    [Header("General")]
    public AppController app;

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

    private bool Movement;
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

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    private void Start()
    {
        Movement = true;

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
        if (screenSelectLevel)
        {
            CheckSelectorLevel();
        }
    }

    public void Selector(int numAvatar)
    {
        //SI HAY LA CAPACIDAD DE JUGADORES ES MAYOR AGREGAR UN IF CON OTRO NUM PLAYER
        // Observación (Por hacer): Para lo señalado en el comentario anterior, sería
        // más eficiente el uso de un for loop que itere según el número de jugadores
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

                    //Debug.Log("El jugador 1 se ha decidido, reproducir sonido");
                    AudioManager.instance.PlaySpecialEffect(selectionSound);
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

                    //Debug.Log("Jugador 2 ya decdido");
                    AudioManager.instance.PlaySpecialEffect(selectionSound);
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

                    AudioManager.instance.PlaySpecialEffect(selectionSound);
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
    
    // POR HACER: Debería considerarse colocar los dos métodos siguientes como una property, ya que
    // están sirviendo tal cual como una property

    /// <summary>
    /// Sets the movement variable.
    /// </summary>
    /// <param name="_movement">The movement to set.</param>
    public void SetMovement(bool _movement)
    {
        Movement = _movement;
    }

    /// <summary>
    /// Gets the movement variable.
    /// </summary>
    /// <returns></returns>
    public bool GetMovement()
    {
        return Movement;
    }

    #endregion
}
