using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [HideInInspector]
    public AudioSource audioSrc;

    public AudioClip fire;
    public AudioClip fire1;
    public AudioClip fire2;
    public AudioClip fire3;
    public AudioClip fire4;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioSrc = GetComponent<AudioSource>();

    }


    public void PlaySoundEffect(string NameOfSoundEffect)
    {
        switch (NameOfSoundEffect)
        {
            case "fire":
                {
                    //audioSrc.PlayOneShot(fire);
                    Debug.Log(NameOfSoundEffect);
                    break;
                }
                
            case "fire2":
                {
                    audioSrc.PlayOneShot(fire);
                    Debug.Log(NameOfSoundEffect);

                    break;
                }

            default:
                break;
        }



    }


}
