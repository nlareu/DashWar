using UnityEngine;

public class AvatarMortalWall01Collision : GameCollision
{
    public override string Collider1Tag { get { return "Player"; } }
    public override string Collider2Tag { get { return "MortalWall01"; } }

    public override void Resolve(GameObject collider1, GameObject collider2)
    {
       //Just destroy avatar for now.
        Object.Destroy(collider1);
    }
}