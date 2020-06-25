using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{

    public bool secondPhase = true;

    private float angle = 0f;

    public float hope = 2f;
    private bool stage2;
    private bool stage3;

    public GameObject bossTime;


    

    [SerializeField]
    private int bulletsAmount = 8;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, hope);
        bossTime = GameObject.FindGameObjectWithTag("Boss");

    }
   

    // Update is called once per frame


    private void Shoot()
    {

        if (stage3)
        {
            
            CancelInvoke("Shoot");
            stage2 = false;
            InvokeRepeating("Fire2", 0f, 0.3f);
            print("Oh yeah stage 3");
            Fire2();
        }
        else if (stage2)
        {
            print("stage 2 gang");
            CancelInvoke("Shoot");
            InvokeRepeating("Shoot2", 0f, 1f);
            Fire();
        }
        else
        {
            Fire();
        }

    }

    private void Shoot2()
    {
        if (stage3)
        {

            CancelInvoke("Shoot2");
            stage2 = false;
            InvokeRepeating("Fire2", 0f, 0.3f);
            InvokeRepeating("BossSounds", 0f, 2f);
            print("Oh yeah stage 3");
            Fire2();
        }
        else {

            Fire();

        }
    }

    private void bossSounds()
    {
        SoundManager.PlaySound("BossInhale");
    }
    private void Fire()
    {
        //SoundManager.PlaySound("BossFire");
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += angleStep;
            
            
        }
    }

    private void Fire2()
    {

        
        
        
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        }

        angle += 15f;

        if (angle >= 360f)
        {
            angle = 0f;
        }

    }
    

    void Update()
    {
        
        stage2 = bossTime.GetComponent<Boss>().stage2;
        stage3 = bossTime.GetComponent<Boss>().stage3;
        
        if(stage3)
        {
            stage2 = false;
        }
    }
}
