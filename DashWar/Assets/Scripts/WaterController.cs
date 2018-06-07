using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WaterController : MonoBehaviour
{
    private void Awake()
    {
        this.tag = "Water";
    }
}
