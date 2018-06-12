using UnityEngine;

public class AvatarWallCollision : GameCollision
{
    public override string Collider1Tag { get { return "Player"; } }
    public override string Collider2Tag { get { return "Wall"; } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        AvatarController ac = collider1.GetComponent<AvatarController>();
        Rigidbody2D rb = collider1.GetComponent<Rigidbody2D>();

        //var contact = collision.contacts[0];
        //var newDir = Vector3.zero;
        //var curDir = ac.transform.TransformDirection(Vector3.forward);
        //newDir = Vector3.Reflect(curDir, contact.normal);
        //ac.transform.rotation = Quaternion.FromToRotation(Vector3.forward, newDir);

        Debug.Log("Wall hit");

        //Reverse horizontal direction of avatar to make a bounce.
        rb.AddForce(new Vector2(
            collision.relativeVelocity.normalized.x * (Mathf.Abs(collision.relativeVelocity.x) * ac.HitForce / ac.ejectionVelocity.x),
            0
        ));


        //float factor = 250f;
        //var opositeForce = new Vector2(
        //    (collision.relativeVelocity.x > 0)
        //        ? -collision.relativeVelocity.x + ac.debugvar
        //        : -collision.relativeVelocity.x - ac.debugvar,
        //    collision.relativeVelocity.y
        //);
        //rb.AddForce(opositeForce);

        //rb.velocity = Vector2.zero;
        //rb.AddForce(new Vector2(collision.relativeVelocity.x * -1, collision.relativeVelocity.y));

        //var opposite = -collision.relativeVelocity;
        //rb.AddForce(opposite * Time.deltaTime);

        //var curSpeed = rb.velocity.magnitude;

        //rb.velocity = rb.velocity.normalized * (curSpeed * Time.deltaTime);
    }
}