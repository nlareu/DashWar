using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public float debugvar = 10f;

    public float AxisSensitive = 0.7f;
    public float HipervelocityBurnMaxTime = 0.5f;
    public float HipervelocityCooldownMaxTime = 1.0f;
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
                            this.animator.SetBool("Moving", false);
                            this.animator.SetFloat("MoveX", 0);
                            this.animator.SetBool("HiperMoving", true);
                            this.animator.SetFloat("HiperMoveX", this.animator.GetFloat("MoveX"));

                            this.spriteRendered.color = Color.yellow;

                            this.rigidBody.gravityScale = 0f;
                            //To disable gravity effects, also settings is velicity to zero.
                            this.rigidBody.velocity = Vector2.zero;

                            this.hiperActivedTime = 0f;

                            //Set initial values for hiper move line.
                            this.hiperMoveLine.positionCount = 2;
                            this.hiperMoveLine.SetPositions(new Vector3[] {
                                new Vector2(this.rigidBody.position.x, this.rigidBody.position.y),
                                new Vector2(this.rigidBody.position.x, this.rigidBody.position.y),
                            });

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
                            this.animator.SetBool("Moving", true);
                            this.animator.SetFloat("MoveX", this.animator.GetFloat("HiperMoveX"));
                            this.animator.SetBool("HiperMoving", false);
                            this.animator.SetFloat("HiperMoveX", 0);
                            this.animator.SetFloat("HiperMoveY", 0);

                            this.spriteRendered.color = Color.green;

                            this.rigidBody.gravityScale = 1f;

                            this.hiperCooldownTime = 0f;

                            break;
                        }
                    #endregion
                    #region Stunned
                    case AvatarStates.Stunned:
                        {
                            this.spriteRendered.color = Color.red;

                            this.stunningTime = 0f;

                            break;
                        }
                        #endregion
                }
            }
        }
    }
    public float StunnedMaxTime = 1.5f;

    private int playerNumber;
    private string playerName
    {
        get { return "Player" + this.playerNumber + "-"; }
    }

    private Animator animator;
    private BoxCollider2D boxCollider;
    private Vector2 currentDirection
    {
        get
        {
            return new Vector2(
                        (this.rigidBody.position.x > this.previousPosition.x)
                            ? 1
                            : (this.rigidBody.position.x < this.previousPosition.x)
                                ? -1
                                : 0,
                        (this.rigidBody.position.y > this.previousPosition.y)
                            ? 1
                            : (this.rigidBody.position.y < this.previousPosition.y)
                                ? -1
                                : 0
            ); ;
        }
    }

    internal Vector2 ejectionVelocity = Vector2.zero;
    private float hiperActivedTime;
    private float hiperCooldownTime;
    private LineRenderer hiperMoveLine;
    private Vector2 previousDirection = Vector2.zero;
    private Vector2 previousPosition = Vector2.zero;
    private AvatarStates previousState;
    private SpriteRenderer spriteRendered;
    private Rigidbody2D rigidBody;
    private float stunningTime;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.hiperMoveLine = GetComponent<LineRenderer>();
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

                    if (this.hiperCooldownTime > this.HipervelocityCooldownMaxTime)
                    {
                        this.State = AvatarStates.Normal;
                    }

                    //Reset hiper move line
                    this.hiperMoveLine.positionCount = 0;

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

                    if (this.hiperActivedTime > this.HipervelocityBurnMaxTime)
                    {
                        this.State = AvatarStates.CoolingDown;
                        break;
                    }


                    this.CheckAvatarHiperMove();


                    //If move direction changed, add new position to hiper move line.
                    if ((this.previousState == AvatarStates.Hipervelocity)
                        && (this.previousDirection != Vector2.zero)
                        && (this.previousDirection != this.currentDirection))
                    {
                        this.hiperMoveLine.positionCount++;
                    }

                    //Update hiper move line liast position.
                    this.hiperMoveLine.SetPosition(this.hiperMoveLine.positionCount - 1, new Vector2(this.rigidBody.position.x, this.rigidBody.position.y));

                    //Vector3[] pos = new Vector3[this.hiperMoveLine.positionCount];
                    //this.hiperMoveLine.GetPositions(pos);
                    //Debug.Log(string.Join(",", pos.Select(item => string.Format("x: {0}, y: {1}", item.x, item.y)).ToArray()));

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
                    this.stunningTime += Time.deltaTime;

                    if (this.stunningTime > this.StunnedMaxTime)
                    {
                        this.State = AvatarStates.Normal;
                    }

                    this.ejectionVelocity = this.rigidBody.velocity;

                    break;
                }
            #endregion
        }


        this.previousDirection = this.currentDirection;
        this.previousPosition = new Vector2(this.rigidBody.position.x, this.rigidBody.position.y);
        this.previousState = this.State;

        //Debug.Log("Velocity: " + this.rigidBody.velocity.ToString());
        //if (this.rigidBody.velocity.x != 0) 
        //    Debug.Log("Velocity: " + this.rigidBody.velocity.ToString());
        //Debug.Log(string.Format("Axis H: {0}, V: {1}.", (float)Input.GetAxis(this.playerName + "Horizontal"), (float)Input.GetAxis(this.playerName + "Vertical")));
    }

    private void CheckAvatarHiperMove()
    {
        Vector2 moveVector = new Vector2();
        float axisHor = Input.GetAxis(this.playerName + "Horizontal");
        float axisVer = Input.GetAxis(this.playerName + "Vertical");

        //if (Input.GetButton(this.playerName + "Left"))
        if (axisHor <= -this.AxisSensitive)
        {
            moveVector += Vector2.left * this.HipervelocitySpeed * Time.deltaTime;

            //this.animator.SetBool("HiperMoving", true);
            this.animator.SetFloat("HiperMoveX", -1.5f);
            this.animator.SetFloat("HiperMoveY", 0);
        }
        //if (Input.GetButton(this.playerName + "Right"))
        if (axisHor >= this.AxisSensitive)
        {
            moveVector += Vector2.right * this.HipervelocitySpeed * Time.deltaTime;

            //this.animator.SetBool("HiperMoving", true);
            this.animator.SetFloat("HiperMoveX", 1.5f);
            this.animator.SetFloat("HiperMoveY", 0);
        }

        //if (Input.GetButton(this.playerName + "Up"))
        if (axisVer >= this.AxisSensitive)
        {
            moveVector += Vector2.up * this.HipervelocitySpeed * Time.deltaTime;

            ////this.animator.SetBool("HiperMoving", true);
            //this.animator.SetFloat("HiperMoveX", 0);
            //this.animator.SetFloat("HiperMoveY", 1.5f);
        }
        //if (Input.GetButton(this.playerName + "Down"))
        else if (axisVer <= -this.AxisSensitive)
        {
            moveVector += Vector2.down * this.HipervelocitySpeed * Time.deltaTime;

            ////this.animator.SetBool("HiperMoving", true);
            //this.animator.SetFloat("HiperMoveX", 0);
            //this.animator.SetFloat("HiperMoveY", -1.5f);
        }

        this.transform.Translate(moveVector);
    }
    private void CheckAvatarMove()
    {
        Vector2 moveVector = new Vector2();
        float axisHor = Input.GetAxis(this.playerName + "Horizontal");
        float axisVer = Input.GetAxis(this.playerName + "Vertical");

        //if (Input.GetButton(this.playerName + "Left"))
        if (axisHor <= -this.AxisSensitive)
        {
            moveVector += Vector2.left * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveX", -1.5f);
        }
        //else if (Input.GetButton(this.playerName + "Right"))
        else if (axisHor >= this.AxisSensitive)
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
            var avatar = this;
            var otherAvatar = col.gameObject.GetComponent<AvatarController>();

            AvatarController hittingAvatar = null;
            AvatarController hittedAvatar = null;
            Vector2 hitDirection = Vector2.zero;
            var avatarPos = this.rigidBody.position;
            var otherAvatarPos = otherAvatar.rigidBody.position;
            var otherAvatarBounds = otherAvatar.boxCollider.bounds;


            if ((avatar.State == AvatarStates.Hipervelocity) && (otherAvatar.State == AvatarStates.Hipervelocity))
            {
                #region Not working
                //To know who hit who, check if hitting center of object is between bounds of hitted object.
                //Also the direction of the hit will determine the direction of the ejection.
                if ((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y))
                {
                    hittedAvatar = otherAvatar;
                    hittingAvatar = avatar;

                    if (avatarPos.x < otherAvatarPos.x)
                        hitDirection = Vector2.right;
                        //otherAvatar.rigidBody.AddForce(Vector2.right * this.HitForce);
                    else
                        hitDirection = Vector2.left;
                    //otherAvatar.rigidBody.AddForce(Vector2.left * this.HitForce);

                    //otherAvatar.State = AvatarStates.Stunned;
                }
                else if ((avatarPos.x >= otherAvatarBounds.min.x) && (avatarPos.x <= otherAvatarBounds.max.x))
                {
                    hittedAvatar = otherAvatar;
                    hittingAvatar = avatar;

                    if (avatarPos.y < otherAvatarPos.y)
                        hitDirection = Vector2.up;
                        //otherAvatar.rigidBody.AddForce(Vector2.up * this.HitForce);
                    else
                        hitDirection = Vector2.down;
                    //otherAvatar.rigidBody.AddForce(Vector2.left * this.HitForce);

                    //otherAvatar.State = AvatarStates.Stunned;
                }
                ////If code goes here, is because this object is the hitted one.
                //else
                //{
                //    if (avatarPos.x < otherAvatarPos.x)
                //        this.rigidBody.AddForce(Vector2.right * this.HitForce);
                //    else
                //        this.rigidBody.AddForce(Vector2.left * this.HitForce);

                //    this.State = AvatarStates.Stunned;
                //}
                #endregion
            }
            else if (avatar.State == AvatarStates.Hipervelocity)
            {
                hittingAvatar = avatar;
                hittedAvatar = otherAvatar;

                if ((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y))
                {
                    if (avatarPos.x < otherAvatarPos.x)
                        hitDirection = Vector2.right;
                    else
                        hitDirection = Vector2.left;
                }
                else if ((avatarPos.x >= otherAvatarBounds.min.x) && (avatarPos.x <= otherAvatarBounds.max.x))
                {
                    if (avatarPos.y < otherAvatarPos.y)
                        hitDirection = Vector2.up;
                    else
                        hitDirection = Vector2.down;
                }
            }
            //else if (otherAvatar.State == AvatarStates.Hipervelocity)
            //{
            //    hittingAvatar = otherAvatar;
            //    hittedAvatar = avatar;

            //    if ((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y))
            //    {
            //        if (avatarPos.x < otherAvatarPos.x)
            //            hitDirection = Vector2.right;
            //        else
            //            hitDirection = Vector2.left;
            //    }
            //    else if ((avatarPos.x >= otherAvatarBounds.min.x) && (avatarPos.x <= otherAvatarBounds.max.x))
            //    {
            //        if (avatarPos.y < otherAvatarPos.y)
            //            hitDirection = Vector2.up;
            //        else
            //            hitDirection = Vector2.down;
            //    }
            //}


            //Means that a hit happens.
            if (hittedAvatar != null)
            {
                hittedAvatar.State = AvatarStates.Stunned;

                hittedAvatar.rigidBody.AddForce(hitDirection * this.HitForce);
            }
        }
        else
        {
            CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
        }
    }
}
