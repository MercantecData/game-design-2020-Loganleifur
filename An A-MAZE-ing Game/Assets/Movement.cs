using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10;


    public GameObject bulletright, bulletleft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.5f;




    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalinput = Input.GetAxis("Horizontal");
        var verticalinput = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime * horizontalinput;
        position.y += speed * Time.deltaTime * verticalinput;
        rigidbody.MovePosition(position);


        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            fire();
        }


            void fire()
            {
                bulletPos = transform.position;
                bulletPos += new Vector2 (+1.2f, 0.27f);
                Instantiate(bulletright, bulletPos, Quaternion.identity);
            }
    }
        

}

