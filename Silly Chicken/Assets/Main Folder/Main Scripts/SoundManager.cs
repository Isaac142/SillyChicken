using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip explodeSound, hurtSound, walkingSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        explodeSound = Resources.Load<AudioClip>("Explode");
        hurtSound = Resources.Load<AudioClip>("Hurt");
        walkingSound = Resources.Load<AudioClip>("Chicken");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch(clip){
            case "Explode":
            audioSrc.PlayOneShot(explodeSound);
            break;
            case "Hurt":
            audioSrc.PlayOneShot(hurtSound);
            break;
            case "Chicken":
            audioSrc.PlayOneShot(walkingSound);
            break;
        }
    }
}
