using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDetector : MonoBehaviour
{
    public float HP = 250;

    public Animator anim;
    public bool gotHit = false;
    public bool gotHitBlue = false;

    public GameObject Victory;
    public GameObject No;
    public string Enchantment;
    public float lifesteal;

    

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
        Enchantment = GameObject.Find("HUD/Enchantment").GetComponent<Text>().text;

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
            if (name == "Boss")
            {
                
                SoundManager.PlaySound("BossDamage");
            }
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
