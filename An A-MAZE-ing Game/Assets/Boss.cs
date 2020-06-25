using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private string currentState = "Patrol";

    public bool music = true;

    public float speed = 5;
    public float range = 150;
    public float HP = 1000;
    public bool gotHit = false;
    public bool gotHitBlue = false;
    public bool stage3 = false;
    public bool stage2 = false;
    public bool Vibecheck = true;
    

    private Transform target;

    public GameObject Victory;
    public GameObject No;

    public Animator anim;

    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    public Transform waypoint4;
    public Transform waypoint5;

    public LayerMask Mask;

    private Transform nextWaypoint;

    private AudioSource[] allAudioSources;


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Sword")
        {

            gotHit = true;
        }
        if (col.gameObject.name == "BlueSword")
        {
            gotHitBlue = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        Victory = GameObject.Find("HUD/Victory");
        Victory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(TargetAquired() == true && music == true)
        {
            SoundManager.PlaySound("BossBGM");
            music = false;
        }
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

        if (gotHit == true)
        {
            HP -= 25;
            anim.Play("EnemyTakesDamage");
            gotHit = false;
            SoundManager.PlaySound("BossDamage");
            
        }
        if (gotHitBlue == true)
        {
            HP -= 50;
            anim.Play("EnemyTakesDamage");
            gotHitBlue = false;
            SoundManager.PlaySound("BossDamage");

        }
        if (HP <= 600 && Vibecheck == true)
        {
            anim.Play("BossInhale");
            stage2 = true;
            speed = 10;
            Vibecheck = false;
        }
        if (HP <= 300)
        {
            nextWaypoint = waypoint5;
            stage3 = true;
            stage2 = false;
            
        }
        if (HP <= 0)
        {
            
                allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
                foreach (AudioSource audio in allAudioSources)
                {
                    audio.Stop();
                }
                SoundManager.PlaySound("Victory");
                Victory.SetActive(true);
                No = GameObject.Find("player");
                Destroy(No);

            
            Destroy(this.gameObject);
        }




    }

    bool TargetAquired()
    {
        GameObject targetGO = GameObject.FindGameObjectWithTag("player");
        bool inRange = false;
        bool inVision = false;

        if (Vector2.Distance(targetGO.transform.position, transform.position) < range)
        {
            inRange = true;

        }

        var linecast = Physics2D.Linecast(transform.position, targetGO.transform.position, Mask);
        if (linecast.transform == null)
        {
            inVision = true;


        }
        return inRange && inVision;
    }



}
