using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    // Speed of rotation (degrees per second)
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotates the coin around the X-axis continuously
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
