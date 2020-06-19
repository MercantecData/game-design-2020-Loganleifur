using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public float HP = 250;

    public Animator anim;
    public bool gotHit = false;

    public GameObject Victory;
    public GameObject No;

    public string name;

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name == "Sword")
        {
            
            gotHit = true;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        name = this.gameObject.name;
        if(name == "Boss") {
        Victory = GameObject.Find("HUD/Victory");
        Victory.SetActive(false);
        }
    }

    void Update()
    {
        
        
        if(gotHit == true)
        {
            HP -= 50;
            anim.Play("EnemyTakesDamage");
            gotHit = false;
            
        }
        if (HP <= 0)
        {
            if (name == "Boss")
            {
                Victory.SetActive(true);
                No = GameObject.Find("player");
                Destroy(No);
                
            }
            Destroy(this.gameObject);
        }
    }
}
