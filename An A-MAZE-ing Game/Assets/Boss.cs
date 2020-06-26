using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    private string currentState = "Patrol";

    public bool music = true;

    public float speed = 5;
    public float range = 150;
    public float HP = 1000;
    public float lifesteal;

    public string Enchantment;

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
        Enchantment = GameObject.Find("HUD/Enchantment").GetComponent<Text>().text;
        if (TargetAquired() == true && music == true)
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audio in allAudioSources)
            {
                audio.Stop();
            }
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
            if (Enchantment == "Enchantment: Sharpness")
            {
                HP -= 75;
            }
            if (Enchantment == "Enchantment: Lifesteal")
            {
                GameObject.Find("player").GetComponent<Player>().HP += 25;
                lifesteal = GameObject.Find("player").GetComponent<Player>().HP;
                GameObject.Find("HUD/Healthbar").GetComponent<Text>().text = "HP: " + lifesteal;
                HP -= 50;
            }
            else
            {
                HP -= 50;
            }
            
            anim.Play("EnemyTakesDamage");
            gotHit = false;
            SoundManager.PlaySound("BossDamage");
            
        }
        if (gotHitBlue == true)
        {
            if (Enchantment == "Enchantment: Sharpness")
            {
                HP -= 150;
            }
            if (Enchantment == "Enchantment: Lifesteal")
            {
                GameObject.Find("player").GetComponent<Player>().HP += 50;
                lifesteal = GameObject.Find("player").GetComponent<Player>().HP;
                GameObject.Find("HUD/Healthbar").GetComponent<Text>().text = "HP: " + lifesteal;
                HP -= 100;
            }
            else
            {
                HP -= 100;
            }
            
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
