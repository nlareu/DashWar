using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

    #region Fields

    public float recordTime = 5f;
    private bool isReplaying = false;
    private bool isRewinding = false;
    private int rewindPoints = 0;

    // This will store the position of the object at a given time, these will be the frames
    List<PointInTimeAvatar> pointsInTime;

    // Valores a registrar
    Rigidbody2D rb2d;
    AvatarController avatar;
    SpriteRenderer avatarRenderer;
    Animator animator;

    #endregion

    #region Methods

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        avatar = GetComponent<AvatarController>();
        avatarRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        pointsInTime = new List<PointInTimeAvatar>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Rewinding test
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            StartRewind();
            rewindPoints = 0; // Change
        }
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            StopRewind();
        }

        // Replaying test
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            StartReplay();
        }
    }

    // FixedUpdate is called once per physics update.
    private void FixedUpdate()
    {
        // If a replay is running, that means the match is over and there's no need to keep recording
        if(isReplaying)
        {
            Replay();
            return;
        }

        // Only rewind when the player commands to, otherwise record (a frame per FU cycle)
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    /// <summary>
    /// Replays the recording of the player.
    /// </summary>
    void Replay()
    {
        // Only replay when having values
        if (pointsInTime.Count > 0)
        {
            PointInTimeAvatar currentPoint = pointsInTime[pointsInTime.Count - 1];

            transform.position = currentPoint.position;
            avatar.State = currentPoint.state;
            //Debug.Log(currentPoint.sprite);
            avatarRenderer.sprite = currentPoint.sprite;

            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        else
        {
            StopReplay();
        }
    }

    /// <summary>
    /// Tells the avatar to start replaying.
    /// </summary>
    public void StartReplay()
    {
        isReplaying = true;
        rb2d.isKinematic = true; // So unity doesn't try to apply forces when replaying
        //avatar.enabled = false;
        animator.enabled = false;
    }

    /// <summary>
    /// Tells the avatar to stop replaying.
    /// </summary>
    public void StopReplay()
    {
        isReplaying = false;
        rb2d.isKinematic = false;
        //avatar.enabled = false;
        animator.enabled = true;
    }

    /// <summary>
    /// Rewinds the object in time.
    /// </summary>
    void Rewind()
    {
        // Only rewind when having values
        if (pointsInTime.Count > 0)
        {
            //PointInTimeAvatar currentPoint = pointsInTime[0];
            PointInTimeAvatar currentPoint = pointsInTime[rewindPoints];

            transform.position = currentPoint.position;
            avatar.State = currentPoint.state;
            //Debug.Log(currentPoint.sprite);
            avatarRenderer.sprite = currentPoint.sprite;

            //pointsInTime.RemoveAt(0); // Change
            rewindPoints++; // Change
        }
        else
        {
            StopRewind();
        }
    }

    /// <summary>
    /// Records (graphically) the activity of the avatar.
    /// </summary>
    void Record()
    {
        // This would add the value at the end of the list, so the first index has the oldest position 
        // and the last index has the newest
        //positions.Add(transform.position);

        // FixedUpdate usually runs 50 times per sec, but this value can be change so we don't hardcode it,
        // this calculation (1f / Time.fixedDeltaTime) will return the current frequency of FU: 1/0.02=50 eg,
        // though we hardcoded (at first) here 5 seconds XD. Only record the last 5 secs.
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        // This will put the newest value at the beginning and move the rest
        pointsInTime.Insert(0, new PointInTimeAvatar(transform.position, avatar.State, avatarRenderer.sprite));
    }

    /// <summary>
    /// Tells the avatar to rewind.
    /// </summary>
    public void StartRewind()
    {
        isRewinding = true;
        rb2d.isKinematic = true; // So unity doesn't try to apply forces when rewinding
        //avatar.enabled = false;
        animator.enabled = false;
    }

    /// <summary>
    /// Stops the avatar from rewinding.
    /// </summary>
    public void StopRewind()
    {
        isRewinding = false;
        rb2d.isKinematic = false;
        //avatar.enabled = true;
        animator.enabled = true;
    }

    #endregion
}
