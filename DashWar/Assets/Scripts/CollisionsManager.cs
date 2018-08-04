using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsManager {

    private static List<IGameCollision> Collisions;

    static CollisionsManager() {
        Collisions = new List<IGameCollision>
        {
            new AvatarAvatarCollision(),
            new AvatarAvatarFixedPositionCollision(),
            new AvatarGroundCollision(),
            new AvatarWallCollision(),
            new AvatarWaterCollision(),
            new AvatarMortalWall01Collision(),
        };
    }

    public static void ResolveCollision(GameObject collider1, GameObject collider2, Collision2D collision)
    {
        IGameCollision gameColl = Collisions.Find(item => (collider1.CompareTag(item.Collider1Tag)) && (collider2.CompareTag(item.Collider2Tag)));

        if (gameColl != null)
            gameColl.Resolve(collider1, collider2, collision);
    }
}
