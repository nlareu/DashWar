using UnityEngine;

public class AvatarFixedPositionController : AvatarController
{
    private new AvatarStates state = AvatarStates.Normal;
    public new AvatarStates State
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
                            this.animator.SetBool("HiperMoving", true);
                            this.animator.SetFloat("HiperMoveX", this.animator.GetFloat("MoveX"));

                            this.spriteRendered.color = Color.yellow;

                            this.rigidBody.gravityScale = 0f;
                            //To disable gravity effects, also settings is velicity to zero.
                            this.rigidBody.velocity = Vector2.zero;

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
                            this.animator.SetFloat("MoveX", this.animator.GetFloat("HiperMoveX"));
                            this.animator.SetBool("HiperMoving", false);
                            this.animator.SetFloat("HiperMoveX", 0);
                            this.animator.SetFloat("HiperMoveY", 0);

                            this.spriteRendered.color = Color.green;

                            this.rigidBody.gravityScale = 1f;

                            break;
                        }
                    #endregion
                    #region Stunned
                    case AvatarStates.Stunned:
                        {
                            this.spriteRendered.color = Color.red;

                            //Ignore collision with other avatars.
                            AppController
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
    public AvatarStates FixedState;

    public float CurrentDirectionX = 1f;
    public float CurrentDirectionY = 1f;
    internal new Vector2 currentDirection
    {
        get
        {
            return new Vector2(this.CurrentDirectionX, this.CurrentDirectionY);
        }
    }

    protected override void Awake()
    {
        base.Awake();

        this.tag = Tags.PLAYER_FIXED_POSITION;

        //this.rigidBody.gravityScale = 0.0f;

        //Duplicate Fixed State into State property.
        this.State = this.FixedState;
    }

    protected override void Update()
    {
        //this.rigidBody.gravityScale = 0.0f;

        //Duplicate Fixed State into State property.
        this.State = this.FixedState;

        base.Update();
    }
}