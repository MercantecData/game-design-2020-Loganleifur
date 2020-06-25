﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDoor1 : MonoBehaviour
{
    public Animator anim;



    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }


    public void OpenDoor()
    {
        anim = GetComponent<Animator>();
        anim.Play("GoldOpenR");

    }
}