using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSiren : MonoBehaviour
{
    // References to the red and blue lights of the police siren
    public Light redLight;
    public Light blueLight;

    // Time interval for flashing lights (adjustable for speed control)
    public float flashInterval = 0.5f;

    private float timer; // Timer to track flashing intervals
    private bool isRedOn = true; // Determines which light is currently active

    void Update()
    {
        // Increment timer based on elapsed time
        timer += Time.deltaTime;

        // If the timer exceeds the set interval, switch the lights
        if (timer >= flashInterval)
        {
            isRedOn = !isRedOn; // Toggle between red and blue light

            redLight.enabled = isRedOn;  // Enable red light if isRedOn is true
            blueLight.enabled = !isRedOn; // Enable blue light when red is off

            timer = 0f; // Reset timer for next flash cycle
        }
    }
}
