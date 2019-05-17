using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField]
    WaveConfig waveConfig = null;
    List<Transform> waypoints = null;
    [SerializeField]
    private float movespeed = 2f;
    private int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();

        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = movespeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex ++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
