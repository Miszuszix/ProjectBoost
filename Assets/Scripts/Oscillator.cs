using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 3f;
    void Start()
    {
        startingPos = transform.position;
    }
    
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }
        const float TAU = Mathf.PI * 2;
        float cycles = Time.time / period;
        float rawSineWave = Mathf.Sin(cycles * TAU);

        movementFactor = (rawSineWave + 1) / 2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
