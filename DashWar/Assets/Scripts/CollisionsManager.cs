using System.Collections.Generic;
using UnityEngine;

public class CollisionsManager {

    private static List<IGameCollision> Collisions;

    static CollisionsManager() {
        Collisions = new List<IGameCollision>
        {
            new AvatarAvatarCollision(),
            new AvatarAvatarFixedPositionCollision(),
            new AvatarGroundCollision(),
            new AvatarMortalObjectCollision("MortalWall01"),
            new AvatarMortalObjectCollision("SnowBall"),
            new AvatarMortalObjectCollision("Spikes"),
            new AvatarMortalObjectCollision("Water"),
            new DestroySecondObjectCollision("Spikes", "SnowBall"),
        };
    }

    public static void ResolveCollision(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        IGameCollision gameColl = Collisions.Find(item => (collider1.CompareTag(item.Collider1Tag)) && (collider2.CompareTag(item.Collider2Tag)));

        if (gameColl != null)
            gameColl.Resolve(collider1, collider2, collision);
    }
}
