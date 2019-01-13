using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorPlayer : MonoBehaviour {

    // Use this for initialization
    public int numPlayer;
    public SelectAvatarDefinitive selectAvatar;
    private bool Movement;
    private bool activate;
    private bool select;
    //Aqui poner los Sprites idle de todos los avatars
    //(IMPORTANTE QUE SE AGREGUEN ORDENADAMENTE TIENEN QUE ESTAR EN EL MISMO ORDEN QUE LOS PREFABS DE AVATARS)
    public List<Sprite> avatarSprite;
    public SpriteRenderer spriteRenderer;
    public AppController app;
    public SelectCantPlayerDefinitive selectCantPlayerDefinitive;
    protected bool activateCollision;
    private void Start()
    {
        Movement = true;
        spriteRenderer.enabled = false;
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
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
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
    private void OnTriggerStay(Collider other)
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
    }
    public void SetMovement(bool _movement)
    {
        Movement = _movement;
    }
    public bool GetMovement()
    {
        return Movement;
    }
}
