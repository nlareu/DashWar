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
            new AvatarMortalObjectCollision(Tags.MORTAL_WALL_01),
            new AvatarMortalObjectCollision(Tags.SNOWBALL),
            new AvatarMortalObjectCollision(Tags.SPIKES),
            new AvatarMortalObjectCollision(Tags.WATER),
            new DestroySecondObjectCollision(Tags.SPIKES, Tags.SNOWBALL),
        };
    }

    public static void ResolveCollision(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        IGameCollision gameColl = Collisions.Find(item => (collider1.CompareTag(item.Collider1Tag)) && (collider2.CompareTag(item.Collider2Tag)));

        if (gameColl != null)
            gameColl.Resolve(collider1, collider2, collision);
    }
}
