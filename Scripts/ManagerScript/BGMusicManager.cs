using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicManager : MonoBehaviour
{
    public static BGMusicManager instance { private set; get; }

    AudioSource audioSource;

    public AudioClip[] audioClip;




    private void Awake()
    {
        if (instance == null) instance = this;

        if (audioSource == null) audioSource = GetComponent<AudioSource>();





    }

    private void Update()
    {

        if (!audioSource.isPlaying) 
        {
            int randSound = Random.Range(0,audioClip.Length);

            audioSource.clip = audioClip[randSound];

            audioSource.Play();

        }



    }






}
