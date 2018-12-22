using UnityEngine;

 [System.Serializable]
public class TimeInterval
{
    public float Value { get; private set; }
    public float Interval { get; private set; }
    public bool IntervalExceeded
    {
        get { return (this.Value >= this.Interval); }
    }

    public TimeInterval(float interval)
    {
        this.Interval = interval;
    }

    public bool Accumulate()
    {
        this.Value += Time.deltaTime;

        return this.IntervalExceeded;
    }
    public void Reset()
    {
        this.Value = 0;
    }
}