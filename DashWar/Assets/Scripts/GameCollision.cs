using UnityEngine;

public interface IGameCollision
{
    string Collider1Tag { get; }
    string Collider2Tag { get; }
    void Resolve(GameObject collider1, GameObject collider2, Collision2D collision);
}

public abstract class GameCollisionAbstract : IGameCollision
{
    public abstract string Collider1Tag { get; protected set; }
    public abstract string Collider2Tag { get; protected set; }

    //protected TCollider1 Collider1;
    //protected TCollider2 Collider2;

    public GameCollisionAbstract()
    //public GameCollision(TCollider1 collider1, TCollider2 collider2)
    {
        //this.Collider1 = collider1;
        //this.Collider2 = collider2;
    }

    public abstract void Resolve(GameObject collider1, GameObject collider2, Collision2D collision);
}

public abstract class GameCollision : GameCollisionAbstract
{
    public override string Collider1Tag { get; protected set; }
    public override string Collider2Tag { get; protected set; }

    public GameCollision() : base()
    {

    }
    protected GameCollision(string collider1Tag, string collider2Tag) : base()
    {
        this.Collider1Tag = collider1Tag;
        this.Collider2Tag = collider2Tag;
    }
}

