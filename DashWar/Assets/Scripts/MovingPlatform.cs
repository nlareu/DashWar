using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Any player that falls on the platform will stay on it
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Player leaves the platform and no longer follows it
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
