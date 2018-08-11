using UnityEngine;

public class DestroyBothObjectsCollision : GameCollision
{
    public DestroyBothObjectsCollision(string collider1Tag, string collider2Tag) : base(collider1Tag, collider2Tag) { }

    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        Object.Destroy(collider1);
        Object.Destroy(collider2);
    }
}