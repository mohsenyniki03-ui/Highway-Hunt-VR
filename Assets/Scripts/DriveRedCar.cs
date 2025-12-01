using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;

    void Update()
    {
        float move = 0f;
        float turn = 0f;

        if (Input.GetKey(KeyCode.W)) move = 1f;      // Forward
        if (Input.GetKey(KeyCode.S)) move = -1f;     // Backward
        if (Input.GetKey(KeyCode.A)) turn = -1f;     // Left
        if (Input.GetKey(KeyCode.D)) turn = 1f;      // Right

        transform.Translate(Vector3.forward * move * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime);
    }
}
