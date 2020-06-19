using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private string currentState = "Patrol";

    public float speed = 5;
    public float range = 15;


    private Transform target;

    public Animator anim;

    private Transform nextWaypoint;

    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    public Transform waypoint4;

    public LayerMask Mask;




    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == "Patrol")
        {
            Vector2 nextPosition = Vector2.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime * speed);
            transform.position = nextPosition;

            if (transform.position == nextWaypoint.position)
            {
                if (nextWaypoint == waypoint1)
                {
                    nextWaypoint = waypoint2;
                }

                else if (nextWaypoint == waypoint2)
                {
                    nextWaypoint = waypoint3;
                }

                else if (nextWaypoint == waypoint3)
                {
                    nextWaypoint = waypoint4;
                }

                else if (nextWaypoint == waypoint4)
                {
                    nextWaypoint = waypoint1;
                }

            }
        }



    }

    

}
