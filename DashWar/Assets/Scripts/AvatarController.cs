using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviour
{
    public string textScore;
    public float debugvar = 10f;
    public AppController AppController;
    public float AxisSensitive = 0.7f;
    public float DashBurnMaxTime = 0.5f;
    public float DashCooldownMaxTime = 1.0f;
    public float DashSpeed = 17.0f;
    public float HitForce = 500.0F;
    public bool IsJumping = false;
    public float JumpHeight = 250.0f;
    public int PlayerNumber;
    public float Speed = 6.0F;
    protected AvatarStates state = AvatarStates.Normal;
    public Animator animator;
    private float score;
    private bool death = false;
    private bool verifiedDeath = false;
    private bool notMove;

    private void OnDisable()
    {
        death = true;
        
    }
    public void SetVerifiedDeath(bool _verifiedDeath)
    {
        verifiedDeath = _verifiedDeath;
    }
    public bool GetVerifiedDeath()
    {
        return verifiedDeath;
    }
    public void SetDeath(bool _deadth)
    {
        death = _deadth;
    }
    public bool GetDeath()
    {
        return death;
    }
    public void SetScore(float _score)
    {
        score = _score;
    }
    public float GetScore()
    {
        return score;
    }
    public void AddScore(float _score)
    {
        score = score + _score;
    }
    public void SubstractScore(float _score)
    {
        score = score - _score;
    }
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
                    #region Dash
                    case AvatarStates.Dash:
                        {
                            this.animator.SetBool("Moving", false);
                            this.animator.SetFloat("MoveX", 0);
                            this.animator.SetBool("DashMoving", true);
                            this.animator.SetFloat("DashMoveX", this.animator.GetFloat("MoveX"));

                            this.spriteRendered.color = Color.yellow;

                            this.rigidBody.gravityScale = 0f;
                            //To disable gravity effects, also settings is velicity to zero.
                            this.rigidBody.velocity = Vector2.zero;

                            this.dashActivedTime = 0f;

                            //Set initial values for hiper move line.
                            this.dashMoveLine.positionCount = 2;
                            this.dashMoveLine.SetPositions(new Vector3[] {
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

                            //Enable again collision with other avatars, except with those that are stunned.
                            this.AppController
                                .GetPlayers()
                                .ForEach(item =>
                                {
                                    if ((item.PlayerNumber != this.PlayerNumber) && (item.State != AvatarStates.Stunned))
                                    {
                                        Physics2D.IgnoreCollision(this.boxCollider, item.boxCollider, false);
                                    }
                                });

                            break;
                        }
                    #endregion
                    #region CoolingDown
                    case AvatarStates.CoolingDown:
                        {
                            this.animator.SetBool("Moving", true);
                            this.animator.SetFloat("MoveX", this.animator.GetFloat("DashMoveX"));
                            this.animator.SetBool("DashMoving", false);
                            this.animator.SetFloat("DashMoveX", 0);
                            this.animator.SetFloat("DashMoveY", 0);

                            this.spriteRendered.color = Color.green;

                            this.rigidBody.gravityScale = 1f;

                            this.dashCooldownTime = 0f;

                            break;
                        }
                    #endregion
                    #region Stunned
                    case AvatarStates.Stunned:
                        {
                            this.spriteRendered.color = Color.red;

                            this.stunningTime = 0f;

                            //Ignore collision with other avatars.
                            this.AppController
                                .GetPlayers()
                                .ForEach(item =>
                                {
                                    if (item.PlayerNumber != this.PlayerNumber)
                                    {
                                        Physics2D.IgnoreCollision(this.boxCollider, item.boxCollider, true);
                                    }
                                });

                            break;
                        }
                        #endregion
                }
            }
        }
    }
    public float StunnedMaxTime = 1.5f;

    public event EventHandler Died;


    internal BoxCollider2D boxCollider;
    internal Vector2 currentDirection
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
    protected float dashActivedTime;
    protected float dashCooldownTime;
    protected LineRenderer dashMoveLine;
    protected string playerName
    {
        get { return "Player" + this.PlayerNumber + "-"; }
    }
    protected internal Vector2 previousDirection = Vector2.zero;
    protected internal Vector2 previousPosition = Vector2.zero;
    protected internal AvatarStates previousState;
    protected SpriteRenderer spriteRendered;
    protected internal Rigidbody2D rigidBody;
    protected float stunningTime;

    protected virtual void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.dashMoveLine = GetComponent<LineRenderer>();
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.spriteRendered = GetComponent<SpriteRenderer>();
        this.tag = Tags.PLAYER;
    }

    protected virtual void Update()
    {
        if (DataLevel.InstanceDataLevel != null)
        {
            if (!DataLevel.InstanceDataLevel.pause)
            {
                switch (this.State)
                {

                    #region CoolingDown
                    case AvatarStates.CoolingDown:
                        {
                            this.CheckAvatarMove();

                            this.dashCooldownTime += Time.deltaTime;

                            if (this.dashCooldownTime > this.DashCooldownMaxTime)
                            {
                                this.State = AvatarStates.Normal;
                            }

                            //Reset hiper move line
                            this.dashMoveLine.positionCount = 0;

                            break;
                        }
                    #endregion
                    #region Dash
                    case AvatarStates.Dash:
                        {
                            if (Input.GetButton(this.playerName + "Dash") == false)
                            {
                                this.State = AvatarStates.CoolingDown;
                                break;
                            }

                            this.dashActivedTime += Time.deltaTime;

                            if (this.dashActivedTime > this.DashBurnMaxTime)
                            {
                                this.State = AvatarStates.CoolingDown;
                                break;
                            }


                            this.CheckAvatarDashMove();


                            //If move direction changed, add new position to hiper move line.
                            if ((this.previousState == AvatarStates.Dash)
                                && (this.previousDirection != Vector2.zero)
                                && (this.previousDirection != this.currentDirection))
                            {
                                this.dashMoveLine.positionCount++;
                            }

                            //Update hiper move line liast position.
                            this.dashMoveLine.SetPosition(this.dashMoveLine.positionCount - 1, new Vector2(this.rigidBody.position.x, this.rigidBody.position.y));

                            //Vector3[] pos = new Vector3[this.hiperMoveLine.positionCount];
                            //this.hiperMoveLine.GetPositions(pos);
                            //Debug.Log(string.Join(",", pos.Select(item => string.Format("x: {0}, y: {1}", item.x, item.y)).ToArray()));

                            break;
                        }
                    #endregion
                    #region Normal
                    case AvatarStates.Normal:
                        {
                            if (Input.GetButton(this.playerName + "Dash") &&
                                 (
                                    (Input.GetButton(this.playerName + "Right") || Input.GetButton(this.playerName + "Left")) ||
                                    (Input.GetAxis(this.playerName + "Horizontal") <= -this.AxisSensitive || Input.GetAxis(this.playerName + "Horizontal") >= this.AxisSensitive) ||
                                    (Input.GetButton(this.playerName + "Up") || Input.GetButton(this.playerName + "Down")) ||
                                    (Input.GetAxis(this.playerName + "Vertical") <= -this.AxisSensitive || Input.GetAxis(this.playerName + "Vertical") >= this.AxisSensitive)
                                  )
                                )
                            {
                                this.State = AvatarStates.Dash;
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
            }
        }


        this.previousDirection = this.currentDirection;
        this.previousPosition = new Vector2(this.rigidBody.position.x, this.rigidBody.position.y);
        this.previousState = this.State;

        //Debug.Log("Velocity: " + this.rigidBody.velocity.ToString());
        //if (this.rigidBody.velocity.x != 0) 
        //    Debug.Log("Velocity: " + this.rigidBody.velocity.ToString());
        //Debug.Log(string.Format("Axis H: {0}, V: {1}.", (float)Input.GetAxis(this.playerName + "Horizontal"), (float)Input.GetAxis(this.playerName + "Vertical")));
    }

    private void CheckAvatarDashMove()
    {
        if (!notMove)
        {
            Vector2 moveVector = new Vector2();
            float axisHor = Input.GetAxis(this.playerName + "Horizontal");
            float axisVer = Input.GetAxis(this.playerName + "Vertical");

            if ((Input.GetButton(this.playerName + "Left") || axisHor <= -this.AxisSensitive)
                || (Input.GetButton(this.playerName + "Right") || axisHor >= this.AxisSensitive))
            {
                if (Input.GetButton(this.playerName + "Left") || axisHor <= -this.AxisSensitive)
                {
                    moveVector += Vector2.left * this.DashSpeed * Time.deltaTime;

                    //this.animator.SetBool("DashMoving", true);
                    this.animator.SetFloat("DashMoveX", -1.5f);
                    this.animator.SetFloat("DashMoveY", 0);
                }
                else if (Input.GetButton(this.playerName + "Right") || axisHor >= this.AxisSensitive)
                {
                    moveVector += Vector2.right * this.DashSpeed * Time.deltaTime;

                    //this.animator.SetBool("DashMoving", true);
                    this.animator.SetFloat("DashMoveX", 1.5f);
                    this.animator.SetFloat("DashMoveY", 0);
                }
            }
            else
            {
                if (Input.GetButton(this.playerName + "Up") || axisVer >= this.AxisSensitive)
                {
                    moveVector += Vector2.up * this.DashSpeed * Time.deltaTime;

                    ////this.animator.SetBool("DashMoving", true);
                    //this.animator.SetFloat("DashMoveX", 0);
                    //this.animator.SetFloat("DashMoveY", 1.5f);
                }
                else if (Input.GetButton(this.playerName + "Down") || axisVer <= -this.AxisSensitive)
                {
                    moveVector += Vector2.down * this.DashSpeed * Time.deltaTime;

                    ////this.animator.SetBool("DashMoving", true);
                    //this.animator.SetFloat("DashMoveX", 0);
                    //this.animator.SetFloat("DashMoveY", -1.5f);
                }
            }

            this.transform.Translate(moveVector);
        }
    }
    private void CheckAvatarMove()
    {
        if (!notMove)
        {
            Vector2 moveVector = new Vector2();
            float axisHor = Input.GetAxis(this.playerName + "Horizontal");
            //float axisVer = Input.GetAxis(this.playerName + "Vertical");

            //if (Input.GetButton(this.playerName + "Left"))
            if (Input.GetButton(this.playerName + "Left") || axisHor <= -this.AxisSensitive)
            {
                moveVector += Vector2.left * this.Speed * Time.deltaTime;

                this.animator.SetBool("Moving", true);
                this.animator.SetFloat("MoveX", -1.5f);
            }
            //else if (Input.GetButton(this.playerName + "Right"))
            else if (Input.GetButton(this.playerName + "Right") || axisHor >= this.AxisSensitive)
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
                //this.rigidBody.AddForce(Vector2.up * this.JumpHeight);
                this.rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, Vector2.up.y * this.JumpHeight);

                this.IsJumping = true;
            }

            this.transform.Translate(moveVector);
        }
    }
    public void Kill()
    {
        this.gameObject.SetActive(false);

        this.OnDied();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
    }
    private void OnDied()
    {
        if (this.Died != null)
            this.Died(this, new EventArgs());
    }
    public void SetNotMove(bool _notMove)
    {
        notMove = _notMove;
    }
    public bool GetNotMove()
    {
        return notMove;
    }
}
