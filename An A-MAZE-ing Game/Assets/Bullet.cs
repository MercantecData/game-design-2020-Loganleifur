using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private Vector2 moveDirection;
    private float moveSpeed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "wall")
        {
            Invoke("Destroy", 0f);
        }
        if(col.gameObject.name != "Boss")
        {
            if(col.gameObject.name == "Sword")
            {
                if (col.gameObject.name == "Bullet")
                {
                    if (col.gameObject.name == "Bullet(Clone)")
                    {

                    }
                    else
                    {
                        Invoke("Destroy", 0f);

                    }
                }
                
            }
            
        
        }
       
    }

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
