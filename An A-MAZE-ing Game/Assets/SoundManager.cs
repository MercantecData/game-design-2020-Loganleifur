using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerHit, PlayerLocate, Swing, Walk, GameOver, ZombieDamage, BossInhale, BossFire, Victory, BossDeath, BossDamage, BossBGM;
    static AudioSource audioSrc;

    
    void Start()
    {
        playerHit = Resources.Load<AudioClip>("PlayerDamage");
        Swing = Resources.Load<AudioClip>("Swing");
        GameOver = Resources.Load<AudioClip>("GameOver");
        Walk = Resources.Load<AudioClip>("");

        ZombieDamage = Resources.Load<AudioClip>("EnemyDamage");
        PlayerLocate = Resources.Load<AudioClip>("ZombieAttack");

        BossFire = Resources.Load<AudioClip>("FireBall");
        BossDeath = Resources.Load<AudioClip>("BossDeath");
        BossDamage = Resources.Load<AudioClip>("BossDamage");
        BossBGM = Resources.Load<AudioClip>("BossBGM");
        BossInhale = Resources.Load<AudioClip>("BossInhale");
        

        Victory = Resources.Load<AudioClip>("Victory");

        audioSrc = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "PlayerDamage":
                audioSrc.PlayOneShot(playerHit);
                break;
            case "Swing":
                audioSrc.PlayOneShot(Swing);
                break;
            case "GameOver":
                audioSrc.PlayOneShot(GameOver);
                break;
            case "EnemyDamage":
                audioSrc.PlayOneShot(ZombieDamage);
                break;
            case "ZombieAttack":
                audioSrc.PlayOneShot(PlayerLocate);
                break;
            case "BossBGM":
                audioSrc.PlayOneShot(BossBGM);
                break;
            case "BossDeath":
                audioSrc.PlayOneShot(BossDeath);
                break;
            case "BossInhale":
                audioSrc.PlayOneShot(BossInhale);
                break;
            case "BossDamage":
                audioSrc.PlayOneShot(BossDamage);
                break;
            case "BossFire":
                audioSrc.PlayOneShot(BossFire);
                break;
            case "Victory":
                audioSrc.PlayOneShot(Victory);
                break;


        }
    }
}
