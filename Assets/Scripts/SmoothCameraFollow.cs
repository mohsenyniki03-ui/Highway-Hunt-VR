using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    // References to the two cars the camera can follow
    public GameObject normalCar;
    public GameObject policeCar;
    private GameObject targetObject; // The currently selected car to follow

    // Camera movement and rotation speeds for smooth transitions
    public float cameraFollowSpeed = 10.0f;
    public float cameraRotationSpeed = 10.0f;

    // Index to keep track of the current camera view
    private int currentViewIndex = 0;
    private Vector3[] cameraOffsets; // Array of different camera positions relative to the car
    private Quaternion[] cameraRotations; // Array of corresponding camera rotations

    void Start()
    {
        targetObject = normalCar; // Default to following the normal car at the start

        // Define different camera positions for various views
        cameraOffsets = new Vector3[]
        {
            new Vector3(0, 2, -5),  // Default third-person view
            new Vector3(0, 1.5f, 0.5f),  // First-person driver view
            new Vector3(2, 1.5f, -2), // Right-side view
            new Vector3(-2, 1.5f, -2), // Left-side view
            new Vector3(0, 3, 5)  // Rear view
        };

        // Define corresponding rotations for each view
        cameraRotations = new Quaternion[]
        {
            Quaternion.Euler(10, 0, 0),  // Third-person view rotation
            Quaternion.Euler(0, 0, 0),  // First-person driver view rotation
            Quaternion.Euler(10, 90, 0), // Right view rotation
            Quaternion.Euler(10, -90, 0), // Left view rotation
            Quaternion.Euler(10, 180, 0)  // Rear view rotation
        };
    }

    void Update()
    {
        HandleCarSwitching();  // Check if the user wants to switch cars
        HandleViewSwitching(); // Check if the user wants to change camera views

        // Calculate the target position based on the selected car and camera view
        Vector3 desiredPosition = targetObject.transform.position + 
                                  targetObject.transform.TransformDirection(cameraOffsets[currentViewIndex]);

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraFollowSpeed * Time.deltaTime);

        // Calculate the target rotation based on the selected view
        Quaternion desiredRotation = targetObject.transform.rotation * cameraRotations[currentViewIndex];

        // Smoothly rotate the camera to the desired orientation
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, cameraRotationSpeed * Time.deltaTime);
    }

    // Allows switching between the two cars using the number keys
    void HandleCarSwitching()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press '1' to follow the normal car
        {
            targetObject = normalCar;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Press '2' to follow the police car
        {
            targetObject = policeCar;
        }
    }

    // Allows switching between different camera views once a car is selected
    void HandleViewSwitching()
    {
        if (Input.GetKeyDown(KeyCode.F)) currentViewIndex = 1; // First-person driver view
        else if (Input.GetKeyDown(KeyCode.R)) currentViewIndex = 2; // Right-side view
        else if (Input.GetKeyDown(KeyCode.L)) currentViewIndex = 3; // Left-side view
        else if (Input.GetKeyDown(KeyCode.B)) currentViewIndex = 4; // Rear view
        else if (Input.GetKeyDown(KeyCode.T)) currentViewIndex = 0; // Third-person default view
    }
}
