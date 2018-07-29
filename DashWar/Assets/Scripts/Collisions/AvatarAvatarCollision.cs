using UnityEngine;

public class AvatarAvatarCollision : GameCollision
{
    public override string Collider1Tag { get { return "Player"; } }
    public override string Collider2Tag { get { return "Player"; } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        AvatarController avatar = collider1.GetComponent<AvatarController>();
        AvatarController otherAvatar = collider2.GetComponent<AvatarController>();

        AvatarController hittingAvatar = null;
        AvatarController hittedAvatar = null;
        Vector2 hitDirection = Vector2.zero;
        var avatarPos = avatar.rigidBody.position;
        var AvatarBounds = avatar.boxCollider.bounds;
        var otherAvatarPos = otherAvatar.rigidBody.position;
        var otherAvatarBounds = otherAvatar.boxCollider.bounds;

        //This collision will be fired by both avatars. Only process the one fired by the player
        //with smaller player number.
        if (avatar.PlayerNumber > otherAvatar.PlayerNumber)
            return;

        if ((avatar.State == AvatarStates.Hipervelocity) && (otherAvatar.State == AvatarStates.Hipervelocity))
        {
            //If avatar is going to right or left and other avatar is going up or down
            if (
                (avatar.currentDirection.x == 1 || avatar.currentDirection.x == -1) &&
                (otherAvatar.currentDirection.y == 1 || otherAvatar.currentDirection.y == -1)
               )
            {
                if (((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y)))
                {
                    hittedAvatar = otherAvatar;
                    hittingAvatar = avatar;

                    if (avatar.currentDirection.x == 1)
                    {
                        hitDirection = Vector2.right;
                        otherAvatar.rigidBody.AddForce(Vector2.right * avatar.HitForce);
                    }
                    else
                    {
                        hitDirection = Vector2.left;
                        otherAvatar.rigidBody.AddForce(Vector2.left * avatar.HitForce);
                    }

                }
            }
        }
        else if (avatar.State == AvatarStates.Hipervelocity)
        {
            hittingAvatar = avatar;
            hittedAvatar = otherAvatar;

            if ((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y))
            {
                if (avatarPos.x < otherAvatarPos.x)
                    hitDirection = Vector2.right;
                else
                    hitDirection = Vector2.left;
            }
            else if ((avatarPos.x >= otherAvatarBounds.min.x) && (avatarPos.x <= otherAvatarBounds.max.x))
            {
                if (avatarPos.y < otherAvatarPos.y)
                    hitDirection = Vector2.up;
                else
                    hitDirection = Vector2.down;
            }
        }
        else if (otherAvatar.State == AvatarStates.Hipervelocity)
        {
            hittingAvatar = otherAvatar;
            hittedAvatar = avatar;

            if ((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y))
            {
                if (avatarPos.x < otherAvatarPos.x)
                    hitDirection = Vector2.right;
                else
                    hitDirection = Vector2.left;
            }
            else if ((avatarPos.x >= otherAvatarBounds.min.x) && (avatarPos.x <= otherAvatarBounds.max.x))
            {
                if (avatarPos.y < otherAvatarPos.y)
                    hitDirection = Vector2.up;
                else
                    hitDirection = Vector2.down;
            }
        }

                //if ((avatar.State == AvatarStates.Hipervelocity) && (otherAvatar.State == AvatarStates.Hipervelocity))
                //{
                //    #region Not working
                //    To know who hit who, check if hitting center of object is between bounds of hitted object.
                //    Also the direction of the hit will determine the direction of the ejection.
                //    if ((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y))
                //    {
                //        hittedAvatar = otherAvatar;
                //        hittingAvatar = avatar;

                //        if (avatarPos.x < otherAvatarPos.x)
                //            hitDirection = Vector2.right;
                //        otherAvatar.rigidBody.AddForce(Vector2.right * this.HitForce);
                //        else
                //            hitDirection = Vector2.left;
                //        otherAvatar.rigidBody.AddForce(Vector2.left * this.HitForce);

                //        otherAvatar.State = AvatarStates.Stunned;
                //    }
                //    else if ((avatarPos.x >= otherAvatarBounds.min.x) && (avatarPos.x <= otherAvatarBounds.max.x))
                //    {
                //        hittedAvatar = otherAvatar;
                //        hittingAvatar = avatar;

                //        if (avatarPos.y < otherAvatarPos.y)
                //            hitDirection = Vector2.up;
                //        otherAvatar.rigidBody.AddForce(Vector2.up * this.HitForce);
                //        else
                //            hitDirection = Vector2.down;
                //        otherAvatar.rigidBody.AddForce(Vector2.left * this.HitForce);

                //        otherAvatar.State = AvatarStates.Stunned;
                //    }
                //    //If code goes here, is because this object is the hitted one.
                //    else
                //    {
                //        if (avatarPos.x < otherAvatarPos.x)
                //            this.rigidBody.AddForce(Vector2.right * this.HitForce);
                //        else
                //            this.rigidBody.AddForce(Vector2.left * this.HitForce);

                //        this.State = AvatarStates.Stunned;
                //    }
                //    #endregion
                //}
                //else if (avatar.State == AvatarStates.Hipervelocity)
                //{
                //    hittingAvatar = avatar;
                //    hittedAvatar = otherAvatar;

                //    if ((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y))
                //    {
                //        if (avatarPos.x < otherAvatarPos.x)
                //            hitDirection = Vector2.right;
                //        else
                //            hitDirection = Vector2.left;
                //    }
                //    else if ((avatarPos.x >= otherAvatarBounds.min.x) && (avatarPos.x <= otherAvatarBounds.max.x))
                //    {
                //        if (avatarPos.y < otherAvatarPos.y)
                //            hitDirection = Vector2.up;
                //        else
                //            hitDirection = Vector2.down;
                //    }
                //}
                //else if (otherAvatar.State == AvatarStates.Hipervelocity)
                //{
                //    hittingAvatar = otherAvatar;
                //    hittedAvatar = avatar;

                //    if ((avatarPos.y >= otherAvatarBounds.min.y) && (avatarPos.y <= otherAvatarBounds.max.y))
                //    {
                //        if (avatarPos.x < otherAvatarPos.x)
                //            hitDirection = Vector2.right;
                //        else
                //            hitDirection = Vector2.left;
                //    }
                //    else if ((avatarPos.x >= otherAvatarBounds.min.x) && (avatarPos.x <= otherAvatarBounds.max.x))
                //    {
                //        if (avatarPos.y < otherAvatarPos.y)
                //            hitDirection = Vector2.up;
                //        else
                //            hitDirection = Vector2.down;
                //    }
                //}


                //Means that a hit happens.
        if (hittedAvatar != null)
        {
            hittedAvatar.State = AvatarStates.Stunned;

            hittedAvatar.rigidBody.AddForce(hitDirection * hittingAvatar.HitForce);
        }
    }
}