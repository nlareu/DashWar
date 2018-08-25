using System.Collections.Generic;
using UnityEngine;

public class FixedWayPointsMove : MonoBehaviour
{
    public float Speed = 0.25f;
    public List<GameObject> ListOfWaypoints;
    public int StartIndex = 0;

    private Vector2 currentWaypont;
    private int currentWaypointIndex;
    private Vector2 nextWaypoint;
    private float timer = 5.0f;
    public List<Vector2> waypoints;

    void Start()
    {
        //If waypoints are not defined, build it automatically
        //depending the initial position of the object.
        if (this.ListOfWaypoints.Count == 0)
            this.BuildWaypoints_HorizontalSimple();
        else
            this.ListOfWaypoints.ForEach(item => this.waypoints.Add(item.transform.position));


        this.currentWaypointIndex = this.StartIndex;


        this.currentWaypont = this.waypoints[this.currentWaypointIndex];

        this.currentWaypointIndex++;

        this.nextWaypoint = this.waypoints[this.currentWaypointIndex];
    }

    void FixedUpdate()
    {
        if (this.nextWaypoint != null)
        {
            Vector2 initPos = this.currentWaypont;
            Vector2 endPos = this.nextWaypoint;

            this.timer += Time.deltaTime * this.Speed;

            var newPos = Vector2.Lerp(initPos, endPos, timer);

            this.transform.position = newPos;
        }


        if (this.timer >= 1.0f)
        {
            this.timer = 0;

            this.currentWaypont = this.nextWaypoint;

            this.currentWaypointIndex++;

            if (this.currentWaypointIndex == this.waypoints.Count)
                this.currentWaypointIndex = 0;

            this.nextWaypoint = this.waypoints[this.currentWaypointIndex];
        }
    }

    private void BuildWaypoints_HorizontalSimple()
    {
        //Build list of waypoints depending the initial position.

        //Create a new instance to prevent reference.
        this.waypoints.Add(new Vector2(this.transform.position.x, this.transform.position.y));

        this.waypoints.Add(new Vector2(this.transform.position.x + 1, this.transform.position.y));
    }
}
