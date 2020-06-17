using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{

    public static AudioClip bruh;
    static AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        bruh = Resources.Load<AudioClip>("ZombieAttack");
        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public static void playSound()
    {
        audiosrc.PlayOneShot(bruh);
    }
}
