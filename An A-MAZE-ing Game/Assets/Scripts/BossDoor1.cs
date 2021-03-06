﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor1 : MonoBehaviour
{

    public Animator anim;



    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }


    public void OpenDoor()
    {
        SoundManager.PlaySound("DoorOpen");
        anim = GetComponent<Animator>();
        anim.Play("BossOpen");
        
    }
}