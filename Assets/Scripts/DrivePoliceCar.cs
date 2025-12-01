using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarController : MonoBehaviour
{
    // Base movement and turning speeds
    public float speed = 5f;
    public float turnSpeed = 50f;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = speed;  // Set initial speed to default
    }

    void Update()
    {
        float move = 0f;
        float turn = 0f;

        // Detect movement inputs for forward and backward motion
        if (Input.GetKey(KeyCode.UpArrow)) move = 1f;    // Move forward
        if (Input.GetKey(KeyCode.DownArrow)) move = -1f; // Move backward

        // Detect turning inputs for left and right rotation
        if (Input.GetKey(KeyCode.LeftArrow)) turn = -1f; // Turn left
        if (Input.GetKey(KeyCode.RightArrow)) turn = 1f; // Turn right

        // Apply movement based on current speed
        transform.Translate(Vector3.forward * move * currentSpeed * Time.deltaTime);

        // Apply rotation based on turn speed
        transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime);
    }

    // Function to apply a temporary speed boost
    public void ApplyBoost(float boostAmount, float duration)
    {
        currentSpeed = (boostAmount > 0) ? speed + boostAmount : speed; // Apply boost if positive
    }
}
