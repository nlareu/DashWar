using UnityEngine;

public class AvatarGroundCollision : GameCollision
{
    public override string Collider1Tag { get { return "Player"; } }
    public override string Collider2Tag { get { return "Ground"; } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        AvatarController ac = collider1.GetComponent<AvatarController>();

        ac.IsJumping = false;
    }
}