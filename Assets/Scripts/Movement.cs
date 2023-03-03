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
            Rotation(rotation); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotation(-rotation);
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
            if (!audioSource.isPlaying)
            { 
                audioSource.PlayOneShot(mainEngine);
            }
            body.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);
        }
        else
        { 
            audioSource.Stop(); 
        }
    }
}
