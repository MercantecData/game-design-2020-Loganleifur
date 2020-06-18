using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public float HP = 100;

    public Animator anim;
    public bool gotHit = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name == "Sword")
        {
            print("OOF");
            gotHit = true;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        print(HP);
        if(gotHit == true)
        {
            HP -= 25;
            anim.Play("EnemyTakesDamage");
            gotHit = false;
            
        }
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
