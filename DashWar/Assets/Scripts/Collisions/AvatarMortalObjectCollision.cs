using UnityEngine;

public class AvatarMortalObjectCollision : GameCollision
{
    public AvatarMortalObjectCollision(string mortalObjectColliderTag) : base("Player", mortalObjectColliderTag) { }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
       //Just destroy avatar for now.
        Object.Destroy(collider1);
    }
}