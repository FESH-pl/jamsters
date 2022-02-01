using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    private static Sounds instance;
    public static Sounds Instance { get { return instance; } }

    private AudioSource source;

    public AudioClip[] attackAudio;
    public AudioClip[] hurtAudio;
    public AudioClip[] enemyTaunts;
    public AudioClip[] coinSounds;
    public AudioClip[] enemyHurt;

    private bool soundPlayed = true;
    private float timeSinceLastSound = 0.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        source = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        timeSinceLastSound += Time.deltaTime;
        if (soundPlayed)
        {
            soundPlayed = false;
            timeSinceLastSound = 0.0f;
        }

        if(timeSinceLastSound >= 15.0f)
        {
            timeSinceLastSound = 0.0f;
            if(Random.Range(0,2) == 1)
            {
                source.PlayOneShot(enemyTaunts[Random.Range(0, enemyTaunts.Length)]);
            }
        }
    }

    public void playAttackSound()
    {
        soundPlayed = true;
        int randomNumber = Random.Range(0, 4);

        if(randomNumber <= 1) source.PlayOneShot(attackAudio[Random.Range(0,attackAudio.Length)]);
        if(randomNumber > 1) source.PlayOneShot(enemyHurt[Random.Range(0, enemyHurt.Length)]);
    }

    public void playCoinSound()
    {
        soundPlayed = true;
        source.PlayOneShot(coinSounds[Random.Range(0, coinSounds.Length)]);
    }
}
