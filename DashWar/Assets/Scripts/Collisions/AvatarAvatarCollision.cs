using UnityEngine;

public class AvatarAvatarCollision : GameCollisionAbstract
{
    public override string Collider1Tag { get { return Tags.PLAYER; } protected set { } }
    public override string Collider2Tag { get { return Tags.PLAYER; } protected set { } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        AvatarController avatar = collider1.GetComponent<AvatarController>();
        AvatarController otherAvatar = collider2.GetComponent<AvatarController>();

        //This collision will be fired by both avatars. Only process the one fired by the player
        //with smaller player number.
        if (avatar.PlayerNumber > otherAvatar.PlayerNumber)
            return;

        //By Nicolas Larey 2018-08-04:
        //It is necesary pass the state of other avatar in a separate argument to make it work when
        //State property is overrided on child classes.
        ResolveCollision(avatar, avatar.State, otherAvatar, otherAvatar.State);
    }

    public static void ResolveCollision(AvatarController avatar, AvatarStates avatarState, AvatarController otherAvatar, AvatarStates otherAvatarState)
    {
        float boundsDiffCheck = 0.5f;
        AvatarController hittingAvatar = null;
        AvatarController hittedAvatar = null;
        Vector2 hitDirection = Vector2.zero;
        bool isDraw = false;

        var avatarPos = avatar.rigidBody.position;
        var avatarBounds = avatar.boxCollider.bounds;
        var otherAvatarPos = otherAvatar.rigidBody.position;
        var otherAvatarBounds = otherAvatar.boxCollider.bounds;


        if ((avatarState == AvatarStates.Hipervelocity) && (otherAvatarState == AvatarStates.Hipervelocity))
        {
            //Check if it is an horizontal collision.
            if (((Mathf.Abs(avatarBounds.max.x - otherAvatarBounds.min.x) <= boundsDiffCheck) || (Mathf.Abs(avatarBounds.min.x - otherAvatarBounds.max.x) <= boundsDiffCheck)))
            {
                //If the collision is horizontal, then the hitting avatar is the one which it's direction is horizontal.
                if ((avatar.currentDirection.x != 0) && (otherAvatar.currentDirection.x == 0))
                {
                    hittingAvatar = avatar;
                    hittedAvatar = otherAvatar;
                }
                else if ((avatar.currentDirection.x == 0) && (otherAvatar.currentDirection.x != 0))
                {
                    hittingAvatar = otherAvatar;
                    hittedAvatar = avatar;
                }
                //Draw
                else
                {
                    isDraw = true;
                }
            }
            //Check if it is a vertical collision.
            else if (((Mathf.Abs(avatarBounds.max.y - otherAvatarBounds.min.y) <= boundsDiffCheck) || (Mathf.Abs(avatarBounds.min.y - otherAvatarBounds.max.y) <= boundsDiffCheck)))
            {
                //If the collision is vertical, then the hitting avatar is the one which it's direction is vertical.
                if ((avatar.currentDirection.y != 0) && (otherAvatar.currentDirection.y == 0))
                {
                    hittingAvatar = avatar;
                    hittedAvatar = otherAvatar;
                }
                else if ((avatar.currentDirection.y == 0) && (otherAvatar.currentDirection.y != 0))
                {
                    hittingAvatar = otherAvatar;
                    hittedAvatar = avatar;
                }
                //Draw
                else
                {
                    isDraw = true;
                }
            }
        }
        else if (avatarState == AvatarStates.Hipervelocity)
        {
            hittingAvatar = avatar;
            hittedAvatar = otherAvatar;
        }
        else if (otherAvatarState == AvatarStates.Hipervelocity)
        {
            hittingAvatar = otherAvatar;
            hittedAvatar = avatar;
        }

        //Means that a hit happens.
        if (hittedAvatar != null)
        {
            if (hittingAvatar.currentDirection.x == 1)
                hitDirection = Vector2.left;
            else if (hittingAvatar.currentDirection.x == -1)
                hitDirection = Vector2.right;
            else if (hittingAvatar.currentDirection.y == 1)
                hitDirection = Vector2.down;
            else if (hittingAvatar.currentDirection.y == -1)
                hitDirection = Vector2.up;

            hittedAvatar.State = AvatarStates.Stunned;

            hittedAvatar.rigidBody.AddForce(hitDirection * hittingAvatar.HitForce);
        }
        //If it is a draw, both are hit.
        else if (isDraw == true)
        {
            avatar.State =
            otherAvatar.State = AvatarStates.Stunned;

            if (Mathf.Abs(avatar.currentDirection.x) == 1)
            {
                //For some reason, at this point, the current direction of avatar is wrong due to something weird
                //that I can't understand with rigidbody.position values.
                //Due to this, use previous direction for avatar.
                var avatarHitDir = new Vector2(avatar.previousDirection.x * -1, avatar.previousDirection.y);
                var otherAvatarHitDir = new Vector2(otherAvatar.currentDirection.x * -1, otherAvatar.currentDirection.y);

                avatar.rigidBody.AddForce(avatarHitDir * otherAvatar.HitForce);
                otherAvatar.rigidBody.AddForce(otherAvatarHitDir * avatar.HitForce);
            }
            else if (Mathf.Abs(avatar.currentDirection.y) == 1)
            {
                //For some reason, at this point, the current direction of avatar is wrong due to something weird
                //that I can't understand with rigidbody.position values.
                //Due to this, use previous direction for avatar.
                var avatarHitDir = new Vector2(avatar.previousDirection.x, avatar.previousDirection.y * -1);
                var otherAvatarHitDir = new Vector2(otherAvatar.currentDirection.x, otherAvatar.currentDirection.y * -1);

                avatar.rigidBody.AddForce(avatarHitDir * otherAvatar.HitForce);
                otherAvatar.rigidBody.AddForce(otherAvatarHitDir * avatar.HitForce);
            }
        }
    }
}