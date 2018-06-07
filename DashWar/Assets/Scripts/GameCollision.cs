using UnityEngine;

public interface IGameCollision
{
    string Collider1Tag { get; }
    string Collider2Tag { get; }
    void Resolve(GameObject collider1, GameObject collider2);
}

public abstract class GameCollision : IGameCollision
{
    public abstract string Collider1Tag { get; }
    public abstract string Collider2Tag { get; }

    //protected TCollider1 Collider1;
    //protected TCollider2 Collider2;

    public GameCollision()
    //public GameCollision(TCollider1 collider1, TCollider2 collider2)
    {
        //this.Collider1 = collider1;
        //this.Collider2 = collider2;
    }

    public abstract void Resolve(GameObject collider1, GameObject collider2);
}