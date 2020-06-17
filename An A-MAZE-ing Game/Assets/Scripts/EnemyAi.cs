using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private string currentState = "Patrol";

    public float speed = 5;
    public float range = 15;

    private Transform target;



    private Transform nextWaypoint;
    public Transform waypoint1;
    public Transform waypoint2;

    public LayerMask Mask;

    

    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == "Patrol")
        {
            Vector2 nextPosition = Vector2.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime*speed);
            transform.position = nextPosition;
            if(transform.position == nextWaypoint.position)
            {
                if(nextWaypoint == waypoint1)
                {
                    nextWaypoint = waypoint2;
                }
                else
                {
                    nextWaypoint = waypoint1;
                }
            }
            if(TargetAquired())
            {
                currentState = "Pursuit";
            }
        }
        else if (currentState == "Pursuit"){

            print("GET EM!");
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            ZombieSound.playSound();

            if(!TargetAquired())
            {
                currentState = "Patrol";
            }
        }
    }

    bool TargetAquired()
    {
        GameObject targetGO = GameObject.FindGameObjectWithTag("player");
        bool inRange = false;
        bool inVision = false;

        if(Vector2.Distance(targetGO.transform.position, transform.position) < range)
        {
            inRange = true;
            
        }

        var linecast = Physics2D.Linecast(transform.position, targetGO.transform.position, Mask);
        if(linecast.transform == null)
        {
            inVision = true;
            
            
        }
        return inRange && inVision;
    }
}
