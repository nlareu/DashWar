using UnityEngine;

public class AvatarWallCollision : GameCollision
{
    public override string Collider1Tag { get { return "Player"; } }
    public override string Collider2Tag { get { return "Wall"; } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
    }
}