using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public float debugvar = 10f;

    public float HipervelocityBurnTime = 0.5f;
    public float HipervelocityCooldownTime = 1.0f;
    public float HipervelocitySpeed = 17.0f;
    public float HitForce = 500.0F;
    public bool IsJumping = false;
    public float JumpHeight = 250.0f;
    public float Speed = 6.0F;
    private AvatarStates state = AvatarStates.Normal;
    public AvatarStates State
    {
        get
        {
            return this.state;
        }
        set
        {
            if (this.state != value)
            {
                this.state = value;

                //Set variables depending new state.
                switch (this.state)
                {
                    #region Hipervelocity
                    case AvatarStates.Hipervelocity:
                        {
                            this.spriteRendered.color = Color.yellow;

                            this.rigidBody.gravityScale = 0f;
                            //To disable gravity effects, also settings is velicity to zero.
                            this.rigidBody.velocity = Vector2.zero;

                            this.hiperActivedTime = 0f;

                            break;
                        }
                    #endregion
                    #region Normal
                    case AvatarStates.Normal:
                        {
                            this.spriteRendered.color = Color.white;

                            this.rigidBody.gravityScale = 1f;

                            break;
                        }
                    #endregion
                    #region CoolingDown
                    case AvatarStates.CoolingDown:
                        {
                            this.spriteRendered.color = Color.blue;

                            this.rigidBody.gravityScale = 1f;

                            this.hiperCooldownTime = 0f;

                            break;
                        }
                        #endregion
                }
            }
        }
    }

    private int playerNumber;
    private string playerName
    {
        get { return "Player" + this.playerNumber + "-"; }
    }

    private Animator animator;
    private Rigidbody2D rigidBody;
    private float hiperActivedTime;
    private float hiperCooldownTime;
    private SpriteRenderer spriteRendered;
    internal Vector2 ejectionVelocity = Vector2.zero;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.playerNumber = AppController.GetPlayerNumber();
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.spriteRendered = GetComponent<SpriteRenderer>();
        this.tag = "Player";
    }

    void Update()
    {
        switch (this.State)
        {
            #region CoolingDown
            case AvatarStates.CoolingDown:
                {
                    this.CheckAvatarMove();

                    this.hiperCooldownTime += Time.deltaTime;

                    if (this.hiperCooldownTime > this.HipervelocityCooldownTime)
                    {
                        this.State = AvatarStates.Normal;
                    }

                    break;
                }
            #endregion
            #region Hipervelocity
            case AvatarStates.Hipervelocity:
                {
                    if (Input.GetButton(this.playerName + "Hipervelocity") == false)
                    {
                        this.State = AvatarStates.CoolingDown;
                        break;
                    }

                    this.hiperActivedTime += Time.deltaTime;

                    if (this.hiperActivedTime > this.HipervelocityBurnTime)
                    {
                        this.State = AvatarStates.CoolingDown;
                        break;
                    }


                    Vector2 moveVector = new Vector2();

                        if (Input.GetButton(this.playerName + "Left"))
                            moveVector += Vector2.left * this.HipervelocitySpeed * Time.deltaTime;
                        else if (Input.GetButton(this.playerName + "Right"))
                            moveVector += Vector2.right * this.HipervelocitySpeed * Time.deltaTime;

                        if (Input.GetButton(this.playerName + "Up"))
                            moveVector += Vector2.up * this.HipervelocitySpeed * Time.deltaTime;
                        else if (Input.GetButton(this.playerName + "Down"))
                            moveVector += Vector2.down * this.HipervelocitySpeed * Time.deltaTime;

                        this.transform.Translate(moveVector);
                    
                    break;
                }
            #endregion
            #region Normal
            case AvatarStates.Normal:
                {
                    if (Input.GetButton(this.playerName + "Hipervelocity"))
                    {
                        this.State = AvatarStates.Hipervelocity;
                        break;
                    }

                    this.CheckAvatarMove();

                    break;
                }
            #endregion
            #region Stunned
            case AvatarStates.Stunned:
                {
                    this.ejectionVelocity = this.rigidBody.velocity;

                    break;
                }
            #endregion
        }

        if (this.rigidBody.velocity.x != 0) 
            Debug.Log("Velocity: " + this.rigidBody.velocity.ToString());
    }

    private void CheckAvatarMove()
    {
        Vector2 moveVector = new Vector2();

        if (Input.GetButton(this.playerName + "Left"))
        {
            moveVector += Vector2.left * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveX", -1.5f);
        }
        else if (Input.GetButton(this.playerName + "Right"))
        {
            moveVector += Vector2.right * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveX", 1.5f);
        }
        else
        {
            this.animator.SetBool("Moving", false);
            //this.animator.SetFloat("MoveX", 0.5f);
        }

        if (Input.GetButton(this.playerName + "Jump") && this.IsJumping == false)
        {
            this.rigidBody.AddForce(Vector2.up * this.JumpHeight);

            this.IsJumping = true;
        }

        this.transform.Translate(moveVector);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (this.State == AvatarStates.Hipervelocity)
            {
                var gbColl = col.gameObject;
                var rbColl = col.gameObject.GetComponent<Rigidbody2D>();
                Vector2 move = new Vector2();

                if (this.gameObject.transform.position.x < gbColl.transform.position.x)
                    move += Vector2.right;
                else
                    move += Vector2.left;

                //if (this.gameObject.transform.position.y < gbColl.transform.position.y)
                move += Vector2.up;
                //else
                //    move += Vector2.down;

                rbColl.AddForce(move * this.HitForce);

                rbColl.GetComponent<AvatarController>().State = AvatarStates.Stunned;
            }
        }
        else
        {
            CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
        }
    }
}
