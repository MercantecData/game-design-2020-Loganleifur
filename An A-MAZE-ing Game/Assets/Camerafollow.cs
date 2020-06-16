using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform Obama;

     void FixedUpdate ()
    {
        transform.position = new Vector3(Obama.position.x, Obama.position.y, transform.position.z);
    }

    private Vector2 velocity;

    /*void Start()
    {
        
    }

    void Update()
    {
        var obamaPosition = Obama.position;
        obamaPosition.z = transform.position.z;

        var target = Vector2.SmoothDamp(transform.position, obamaPosition, ref velocity, 0.5f);
        transform.position = target;
    }
    */
}
