using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : PlacementController
{
    public AudioClip firstClip;
    public AudioClip secondClip;
    public AudioClip thirdClip;
    public AudioClip fourthClip;
    public AudioClip fifthClip;
    public GameObject soundObject;
    public AudioSource audioSound;
    bool firstClipStartBool = false;
    bool firstSoundPlayed = false;
    bool secondSoundPlayed = false;
    public GameObject startButton;
    public GameObject seedAppear;
    bool fourthClipPlayed = false;
    public GameObject step3Map;
    bool seedHit = false;
    bool seedSoundRun = false;
    bool fifthClipPlayed = false;
    public GameObject seedDisperse;
    bool seedDisperseActiveOnce = false;
    void Start()
    {
        audioSound = soundObject.GetComponent<AudioSource>();
        audioSound.clip = firstClip;
    }
    void Update()
    {
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
        if(seedAppear.activeInHierarchy && fourthClipPlayed == false)
        {
            audioSound.clip = fourthClip;
            audioSound.Play();
            fourthClipPlayed = true;
            step3Map.SetActive(true);
        }
        // if(seedBegin == true && seedSoundRun == false)
        // {
        //     audioSound.clip = fifthClip;
        //     audioSound.Play();
        //     seedSoundRun = true;
        // }
        if(fourthClipPlayed == true && fifthClipPlayed == false && !audioSound.isPlaying && seedDisperseActiveOnce == false)
        {
            seedDisperse.SetActive(true);
            seedDisperseActiveOnce = true;
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

        //pollenObj.gameObject.SetActive(true);

        //target.position = flyOverPosition.position;
    }
    public void DisperseSeeds()
    {
        if(seedSoundRun == false)
        {
            step3Map.SetActive(true);
            audioSound.clip = fifthClip;
            audioSound.Play();
            seedSoundRun = true;
            seedDisperse.SetActive(false);
        }
        
    }
}
