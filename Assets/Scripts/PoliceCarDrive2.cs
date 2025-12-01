// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PoliceCarDrive2 : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public float forwardSpeed = 5f;
//     public float rotSpeed = 60;
//     public float nitroModifier = 15f;
//     public float nitroThreshold = 20;
//     public float accel = 10f;
//     public float decel = 10f;
//     public float maxSpeed = 10f;

//     float currentSpeed = 0f;

//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//        // Nitro();
//         MoveWithAccell();
//     }

//     bool CanActivateNitro(float speed, float threshold) {
//         return speed < threshold;
//     }

//     // void Move() 
//     // {
//     //     float forwardInput = forwardInput.GetAxis("Vertical");

//     //     forwardInput = forwardInput * forwardSpeed;
//     //     this.transform(Vector3.forward * Time.deltaTime * forwardInput);

//     //     float horizontInput = forwardInput.GetAxis("Horizontal");
//     //     horizontInput *= rotSpeed * Time.deltaTime;

//     //     this.transform.Rotate(0, horizontInput, 0);
//     // }
//     void Nitro() 
//     {

//     }
//     void MoveWithAccell() 
//     {
//         float forwardInput = Input.GetAxisRaw("Vertical");
//         currentSpeed += accel * forwardInput * Time.deltaTime;

//         if(currentSpeed > maxSpeed) {
//             currentSpeed = maxSpeed;
//         }
//         if(currentSpeed < -maxSpeed) {
//             currentSpeed = -maxSpeed;
//         }

//         // decel logic
//         if (forwardInput == 0) {
//             if(currentSpeed > 0)
//             {
//                 currentSpeed -= decel * Time.deltaTime;
//             }
//             if(currentSpeed < 0) 
//             {
//                 currentSpeed += decel * Time.deltaTime;
//             }
//         }
//         this.transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

//         float horizontInput = Input.GetAxis("Horizontal");
//         horizontInput *= rotSpeed * Time.deltaTime;

//         this.transform.Rotate(0, horizontInput, 0);
//     }


// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarDrive2 : MonoBehaviour
{
    public float currentSpeed = 10f;  // Current speed of the car
    public float forwardSpeed = 10f;  // Forward speed of the car
    public float turnSpeed = 60f;     // Turn speed of the car
    public float accel = 10f;         // Acceleration rate
    public float decel = 10f;         // Deceleration rate
    public float maxSpeed = 20f;      // Max speed the car can reach

    void Update()
    {
        MoveWithAccell();
    }

    void MoveWithAccell()
    {
        float move = 0f;
        float turn = 0f;

        // Control car's forward and backward movement with the arrow keys
        if (Input.GetKey(KeyCode.UpArrow)) move = 1f;    // Forward
        if (Input.GetKey(KeyCode.DownArrow)) move = -1f;  // Backward

        // Control car's turning with left and right arrow keys
        if (Input.GetKey(KeyCode.LeftArrow)) turn = -1f;  // Left
        if (Input.GetKey(KeyCode.RightArrow)) turn = 1f;   // Right

        // Acceleration logic: increase speed when moving forward
        if (move > 0f)
        {
            currentSpeed += accel * Time.deltaTime;
        }
        // Deceleration logic: decrease speed when not moving or moving backward
        else if (move < 0f)
        {
            currentSpeed -= accel * Time.deltaTime;
        }
        else if (currentSpeed > 0f)
        {
            currentSpeed -= decel * Time.deltaTime; // Gradual deceleration
        }
        else if (currentSpeed < 0f)
        {
            currentSpeed += decel * Time.deltaTime; // Gradual deceleration for negative speed
        }

        // Cap the speed at maxSpeed to prevent it from going beyond that
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Translate car's position (move forward/backward) based on speed
        transform.Translate(Vector3.forward * move * currentSpeed * Time.deltaTime);

        // Rotate car (turn left/right)
        transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime);
    }
}

