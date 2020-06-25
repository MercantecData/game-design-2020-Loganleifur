using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public float HP = 250;

    public Animator anim;
    public bool gotHit = false;
    public bool gotHitBlue = false;

    public GameObject Victory;
    public GameObject No;

    

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

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        
        
        if(gotHit == true)
        {
            HP -= 50;
            anim.Play("EnemyTakesDamage");
            gotHit = false;
            if (name == "Boss")
            {
                
                SoundManager.PlaySound("BossDamage");
            }
        }
        if (gotHitBlue == true)
        {
            HP -= 100;
            anim.Play("EnemyTakesDamage");
            gotHit = false;
            if (name == "Boss")
            {

                SoundManager.PlaySound("BossDamage");
            }
        }
        if (HP <= 0)
        {
            SoundManager.PlaySound("ZombieDeath");
            Destroy(this.gameObject);
        }
    }
}
