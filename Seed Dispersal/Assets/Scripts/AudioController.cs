using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : PlacementController
{
    public AudioClip firstClip;
    public AudioClip secondClip;
    public AudioClip thirdClip;
    public GameObject soundObject;
    public AudioSource audioSound;
    bool firstClipStartBool = false;
    bool firstSoundPlayed = false;
    bool secondSoundPlayed = false;
    public GameObject startButton;
    //public PlacementController refScript;
    void Start()
    {
        //audioSound = soundObject.GetComponent<AudioSource>();
        audioSound = soundObject.GetComponent<AudioSource>();
        audioSound.clip = firstClip;
        //audioSound.Play();
    }
    void Update()
    {
        // if(refScript.step1Bool)
        // {
        //     firstClipStartBool = true;
        // }
        // if(step1Bool == true)
        // {
        //     // audioSound.clip = firstClip;
        //     audioSound.Play();
        //     firstClipStartBool = false;
        //     //soundObject.GetComponent<AudioSource>().clip = firstClip;
        //     //soundObject.GetComponent<AudioSource>().Play;
        // }
        // if(hitObject.transform.name.Contains("Check1Button"))
        // {
        //     //target.position = target2.position;
        //     //step1.gameObject.SetActive(true);
        //     //step1Bool = true;
        //     audioSound.Play();
        // }


        // if(step1.gameObject.activeInHierarchy == true)
        // {
        //     audioSound.clip = secondClip;
        //     audioSound.Play();
        //     firstSoundPlayed = true;
        // }


        // if(firstSoundPlayed == true && audioSound.isPlaying == false)
        // {
        //     audioSound.clip = secondClip;
        //     audioSound.Play();
        // }
        if(firstSoundPlayed == true)
        {
            if(!audioSound.isPlaying && secondSoundPlayed == false)
            {
                audioSound.clip = secondClip;
                audioSound.Play();
                secondSoundPlayed = true;
            }
        }
        if(!audioSound.isPlaying && secondSoundPlayed == true)
            {
                audioSound.Pause();
            }
    }

    public void BeginButtonPress()
    {
        audioSound.Play();
        startButton.gameObject.SetActive(false);
        firstSoundPlayed = true;
    }
    public void NextIdea1Press()
    {
        audioSound.clip = thirdClip;
        audioSound.Play();
        nextIdea1.gameObject.SetActive(false);
    }
}
