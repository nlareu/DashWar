using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapVine : MonoBehaviour
{
    #region Fields

    public float trapTime = 1.0f;
    [HideInInspector] public bool catchPlayer;
    private AvatarController touchedPlayer;

    [Tooltip("The vine will change to this color while catching players.")] public Color trappingColor;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private Collider2D trapCollider;

    #endregion

    #region Properties

    /// <summary>
    /// Gets and sets the color of the sprite of this object.
    /// </summary>
    public Color SpriteColor
    {
        get { return spriteRenderer.color; }
        set
        {
            spriteRenderer.color = value;
        }
    }

    /// <summary>
    /// Gets and sets the active state of the collider.
    /// </summary>
    public bool ColliderEnabled
    {
        get { return trapCollider.enabled; }
        set { trapCollider.enabled = value; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        trapCollider = GetComponent<Collider2D>();
    }

    /// <summary>
    /// OnTriggerEnter2D is called when the Collider2D collider enters the trigger.
    /// </summary>
    /// <param name="collider">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Atrapando al jugador, solamente uno a la vez
        if(collider.CompareTag("Player"))
        {
            if (touchedPlayer != null)
                return;

            touchedPlayer = collider.GetComponent<AvatarController>();

            if(touchedPlayer == null)
            {
                Debug.Log("The player misses the AvatarController component");
                return;
            }

            if (catchPlayer)
            {
                //Debug.Log(gameObject.name + " has touched " + collider.name);
                touchedPlayer.State = AvatarStates.Still;
                Invoke("ReleasePlayer", trapTime);
            }
            else if (!catchPlayer)
            {
                //Debug.Log(gameObject.name + " should let " + collider.name + " go");
                CancelInvoke();
                //ReleasePlayer();
            }
        }
    }

    /// <summary>
    /// Releases the player from the trap.
    /// </summary>
    public void ReleasePlayer()
    {
        //Debug.Log("Release the player");
        SpriteColor = originalColor;
        catchPlayer = false;

        if (touchedPlayer != null)
        {
            touchedPlayer.State = AvatarStates.Normal;
            touchedPlayer = null;
        }        
    }

    /// <summary>
    /// Resets the color of the Sprite.
    /// </summary>
    public void ResetColor()
    {
        SpriteColor = originalColor;
    }

    #endregion
}
