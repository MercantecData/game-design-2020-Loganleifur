using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10;
    public float HP = 200;
    public bool gotHitByZombie = false;
    public bool gotHitByBullet = false;
    public bool enchant = true;

    public Animator anim;

    private AudioSource[] allAudioSources;

    public GameObject gameOver;
    public GameObject Lifesteal;
    public GameObject Sharpness;
    public GameObject blueSword;
    public GameObject normalSword;
    

    void OnCollisionEnter2D(Collision2D col)
    {
        //print(col.gameObject.name);
        
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
        if (col.gameObject.name == "Diamond")
        {

        normalSword.SetActive(false);
        blueSword.SetActive(true);
        Destroy(col.gameObject);

        }

        if (col.gameObject.name == "Easter Egg")
        {


            Destroy(col.gameObject);
            anim.Play("EasterEgg");
        }

        if (col.gameObject.name == "Enchantments" && enchant == true)
        {
            Lifesteal.SetActive(true);
            Sharpness.SetActive(true);
            enchant = false;
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

        blueSword = GameObject.Find("player/BlueSword");
        blueSword.SetActive(false);

        normalSword = GameObject.Find("player/Sword");
        normalSword.SetActive(true);

        Lifesteal = GameObject.Find("HUD/LifestealButton");
        Lifesteal.SetActive(false);

        Sharpness = GameObject.Find("HUD/SharpnessButton");
        Sharpness.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        
        

        if (gotHitByZombie == true)
        {
           SoundManager.PlaySound("PlayerDamage");
            HP -= 20;
            GameObject.Find("HUD/Healthbar").GetComponent<Text>().text = "HP: " + HP;
            anim.Play("Damage");
            gotHitByZombie = false;
        }

        if (gotHitByBullet == true)
        {
            SoundManager.PlaySound("PlayerDamage");
            HP -= 25;
            GameObject.Find("HUD/Healthbar").GetComponent<Text>().text = "HP: " + HP;

            anim.Play("Damage");
            gotHitByBullet = false;
        }

        if (HP <= 0)
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audio in allAudioSources)
            {
                audio.Stop();
            }
            SoundManager.PlaySound("GameOver");
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

