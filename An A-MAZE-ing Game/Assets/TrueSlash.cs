using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueSlash : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Enemy")
        {

        Destroy(col.gameObject);
        }
    }
}
