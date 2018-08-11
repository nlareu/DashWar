using UnityEngine;

public class SimpleColliderObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
    }
}
