using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsManager {

    private static List<IGameCollision> Collisions;

    static CollisionsManager() {
        Collisions = new List<IGameCollision>
        {
            new AvatarWaterCollision(),
        };
    }

    public static void ResolveCollision(GameObject collider1, GameObject collider2)
    {
        IGameCollision gameColl = Collisions.Find(item => (collider1.CompareTag(item.Collider1Tag)) && (collider2.CompareTag(item.Collider2Tag)));

        gameColl.Resolve(collider1, collider2);
    }
}
