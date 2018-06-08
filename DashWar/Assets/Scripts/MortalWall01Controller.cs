using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MortalWall01Controller : MonoBehaviour
{
    private void Awake()
    {
        this.tag = "MortalWall01";
    }
}
