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
    
    
    
}
