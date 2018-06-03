using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public float HitForce = 250.0F;
    public float JumpHeight = 250.0f;
    public float Speed = 6.0F;

    private bool isJumping = false;
    private int playerNumber;
    private string playerName
    {
        get { return "Player" + this.playerNumber + "-"; }
    }
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        this.playerNumber = AppController.GetPlayerNumber();
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if ((Input.GetAxisRaw("Horizontal") > 0.5f) || (Input.GetAxisRaw("Horizontal") < -0.5f))
        if (Input.GetButton(this.playerName + "Left"))
            transform.Translate(-this.Speed * Time.deltaTime, 0f, 0f);
        else if (Input.GetButton(this.playerName + "Right"))
            transform.Translate(this.Speed * Time.deltaTime, 0f, 0f);

        if (Input.GetButton(this.playerName + "Jump") && this.isJumping == false)
        {
            this.rigidBody.AddForce(Vector2.up * this.JumpHeight);

            this.isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            this.isJumping = false;
        }
        else if (col.gameObject.tag == "Player")
        {
            var gbColl = col.gameObject;
            var rbColl = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 move = new Vector2();

            if (this.gameObject.transform.position.x < gbColl.transform.position.x)
                move += Vector2.right;
            else
                move += Vector2.left;

            if (this.gameObject.transform.position.y < gbColl.transform.position.y)
                move += Vector2.up;
            else
                move += Vector2.down;

            rbColl.AddForce(move * this.HitForce);
        }
    }
}
