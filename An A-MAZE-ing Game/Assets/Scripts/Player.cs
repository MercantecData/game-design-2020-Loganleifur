using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10;
    public float HP = 100;
    public bool gotHitByZombie = false;
    public bool gotHitByBullet = false;

    public Animator anim;

    public GameObject gameOver;

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name == "Enemy")
        {
            
            gotHitByZombie = true;
            /*Vector2 difference = (transform.position - col.gameObject.transform.position).normalized;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);*/
        }

        if (col.gameObject.name == "Bullet" || col.gameObject.name == "Bullet(Clone)")
        {
            
            gotHitByBullet = true;
        }
    }






    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        gameOver = GameObject.Find("HUD/GameOverPanel");
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (gotHitByZombie == true)
        {
            
            HP -= 20;
            anim.Play("Damage");
            gotHitByZombie = false;
        }

        if (gotHitByBullet == true)
        {

            HP -= 25;
            anim.Play("Damage");
            gotHitByBullet = false;
        }

        if (HP <= 0)
        {
            
            gameOver.SetActive(true);
            Destroy(this.gameObject);
        }
        var horizontalinput = Input.GetAxis("Horizontal");
        var verticalinput = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime * horizontalinput;
        position.y += speed * Time.deltaTime * verticalinput;
        rigidbody.MovePosition(position);


       
    }
        

}

