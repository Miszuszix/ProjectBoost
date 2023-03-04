using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody body;
    AudioSource audioSource;

    [SerializeField] int thrust = 200;
    [SerializeField] int rotation = 200;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem leftBoosterParticle;
    [SerializeField] ParticleSystem rightBoosterParticle;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        processThrust();
        processRotation();
    }

    private void processRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartRotatingLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartRotatingRight();
        }
        else
        {
            StopRotatingEffects();
        }
    }

    private void StopRotatingEffects()
    {
        rightBoosterParticle.Stop();
        leftBoosterParticle.Stop();
    }

    private void StartRotatingRight()
    {
        Rotation(-rotation);
        if (!leftBoosterParticle.isPlaying)
        {
            leftBoosterParticle.Play();
        }
    }

    private void StartRotatingLeft()
    {
        Rotation(rotation);
        if (!rightBoosterParticle.isPlaying)
        {
            rightBoosterParticle.Play();
        }
    }

    private void Rotation(float rorationThisFrame)
    {
        body.freezeRotation = true;
        transform.Rotate(Vector3.forward * rorationThisFrame * Time.deltaTime);
        body.freezeRotation = false;
    }

    void processThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        thrustParticle.Stop();
    }

    private void StartThrusting()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!thrustParticle.isPlaying)
        {
            thrustParticle.Play();
        }
        body.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);
    }
}
