using UnityEngine;

public class AvatarMortalObjectCollision : GameCollision
{
    public AvatarMortalObjectCollision(string mortalObjectColliderTag) : base(Tags.PLAYER, mortalObjectColliderTag) { }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        AvatarController av = collider1.GetComponent<AvatarController>();

        av.Kill();
    }
}