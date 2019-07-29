using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMargin : MonoBehaviour
{
    public Vector3 resetPosition = Vector3.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = resetPosition;
        }
    }
}
