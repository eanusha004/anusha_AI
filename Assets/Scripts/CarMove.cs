using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{

    public float carSpeed = 5f;
    public float stopDuration = 2f; // Duration of the stop in seconds
    public float resumeDuration = 1f; // Duration before resuming movement in seconds
    public float loopDistance = 20f; // Desired loop distance

    private Vector3 initialPosition;
    private bool isStopped = false;
    private float timer = 0f;

    void Start()
    {
        // Save the initial position of the car
        initialPosition = transform.position;
    }

    void Update()
    {
        // Check if the car is stopped
        if (isStopped)
        {
            // Increment the timer during the stop
            timer += Time.deltaTime;

            // Check if the stop duration is reached
            if (timer >= stopDuration)
            {
                // Reset the timer, resume movement, and mark as not stopped
                timer = 0f;
                isStopped = false;
            }
        }
        else
        {
            // Move the car forward
            transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);

            // Increment the timer during forward movement
            timer += Time.deltaTime;

            // Check if it's time to stop
            if (timer >= resumeDuration)
            {
                // Reset the timer, stop movement, and mark as stopped
                timer = 0f;
                isStopped = true;
            }

            // Check if the car has reached the loop distance
            if (Vector3.Distance(initialPosition, transform.position) > loopDistance)
            {
                // Reset the car to the initial position
                transform.position = initialPosition;
            }
        }
    }
}
