using UnityEngine;

public class AvatarWaterCollision : GameCollision
{
    public override string Collider1Tag { get { return "Player"; } }
    public override string Collider2Tag { get { return "Water"; } }

    public override void Resolve(GameObject collider1, GameObject collider2)
    {
        AvatarController ac = collider1.GetComponent<AvatarController>();
        WaterController wc = collider1.GetComponent<WaterController>();

        //Just destroy avatar for now.
        Object.Destroy(collider1);
    }
}