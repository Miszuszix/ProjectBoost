using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColissionHandler : MonoBehaviour
{
    [SerializeField] int delayRestart = 2;
    [SerializeField] int delayNext = 1;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;

    AudioSource audioSource;

    bool isTransitioning = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning)
        {
            return; 
        }
        switch (collision.transform.tag)
        {
            case "Finish":
                startNextSequence();
                break;
            case "Friendly":
                Debug.Log("Nothing happens");
                break;
            default:
                startCrashingSequence();
                break;
        }
    }

    private void startCrashingSequence()
    {
        crashParticle.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        disableMovement();
        Invoke("ReloadLevel", delayRestart);
    }

    private void startNextSequence()
    {
        successParticle.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        disableMovement();
        Invoke("LoadNextLevel", delayNext);
    }

    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    private void LoadNextLevel()
    {
        int targetScene = SceneManager.GetActiveScene().buildIndex + 1; 
        if(targetScene > SceneManager.sceneCountInBuildSettings - 1)
        {
            targetScene = 0;
        }
        SceneManager.LoadScene(targetScene);
    }

    private void disableMovement()
    {
        GetComponent<Movement>().enabled = false;
    }
}
