using UnityEngine;

public class RegeneratedObjectPeriodically : MonoBehaviour
{
    public GameObject ObjectRegenerated;
    public float RegenerationInterval = 1f;

    private TimeInterval regenerationTimerInterval;

    // Use this for initialization
    void Start () {
        this.regenerationTimerInterval = new TimeInterval(this.RegenerationInterval);
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        this.regenerationTimerInterval.Accumulate();

        if (this.regenerationTimerInterval.IntervalExceeded == true)
        {
            GameObject bullet = Instantiate(
                this.ObjectRegenerated, 
                new Vector2(
                    this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y
                ),
                Quaternion.identity
            );

            this.regenerationTimerInterval.Reset();
        }
	}
}
