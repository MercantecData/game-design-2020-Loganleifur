﻿using System.Collections;
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
            
            gotHit = true;
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
            
        }
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
