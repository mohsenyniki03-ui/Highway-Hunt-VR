// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Boost : MonoBehaviour
// {
//     public float nitroMaxSpeed = 5f;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     private void OnTriggerEnter (Collider other)
//     {
//         if (other.gameObject.CompareTag("policeCar"))
//         {
//             PoliceCarDrive2 pcarDrive = other.gameObject.GetComponent<PoliceCarDrive2>();
//             StartCoroutine("Booster", pcarDrive);
//         }
//     }

//     IEnumerator Booster(PoliceCarDrive2 pcarDrive) 
//     {
//         pcarDrive.maxSpeed += nitroMaxSpeed;
//         yield return new WaitForSeconds(5);
//         pcarDrive.maxSpeed -= nitroMaxSpeed;

//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float nitroMaxSpeed = 5f;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ColorFlash();
    }

    private void onTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("policeCar"))
        {
            PoliceCarDrive2 pcarDrive = other.gameObject.GetComponent<PoliceCarDrive2>();
            StartCoroutine("Booster", pcarDrive);
        }
    }

    IEnumerator Booster(PoliceCarDrive2 pcarDrive) 
    {
        pcarDrive.maxSpeed += nitroMaxSpeed;
        yield return new WaitForSeconds(5);
        pcarDrive.maxSpeed -= nitroMaxSpeed;

    }

    void ColorFlash()
    {
        Color color = renderer.material.color;
        color.b = Mathf.PingPong(Time.time * 5,9);
        renderer.material.color = color;
    }
}

