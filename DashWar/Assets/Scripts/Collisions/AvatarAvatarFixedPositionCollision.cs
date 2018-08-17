using UnityEngine;

public class AvatarAvatarFixedPositionCollision : AvatarAvatarCollision
{
    public override string Collider1Tag { get { return Tags.PLAYER; } protected set { } }
    public override string Collider2Tag { get { return Tags.PLAYER_FIXED_POSITION; } protected set { } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        AvatarController avatar = collider1.GetComponent<AvatarController>();
        AvatarFixedPositionController otherAvatar = collider2.GetComponent<AvatarFixedPositionController>();

        if (otherAvatar != null)
        {
            //By Nicolas Larey 2018-08-04:
            //It is necesary pass the state of other avatar in a separate argument to make it work when
            //State property is overrided on child classes.
            AvatarAvatarCollision.ResolveCollision(avatar, avatar.State, otherAvatar, otherAvatar.State);
        }
    }
}