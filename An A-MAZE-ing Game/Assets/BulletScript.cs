using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject bulletPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            //Throw a Knife
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Rigidbody2D rigibody = bullet.GetComponent<Rigidbody2D>();

            rigibody.velocity = Vector2.up * 10;

            Destroy(bullet, 10);
        }

    }

    
}
