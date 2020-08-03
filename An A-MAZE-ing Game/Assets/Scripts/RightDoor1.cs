using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoor1 : MonoBehaviour
{
    public Animator anim;
    public bool gotHit = false;

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Sword")
        {
            gotHit = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gotHit == true)
        {
            anim.Play("Open4");
            gotHit = false;
        }
    }
}  

