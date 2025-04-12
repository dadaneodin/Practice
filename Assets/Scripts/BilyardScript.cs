using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilyardScript : MonoBehaviour
{
    public float force;
    Rigidbody rb;

    void Start()
    {
        {
            rb = GetComponent<Rigidbody>();

            Vector3 direction = new Vector3(0, 0, -5);

            rb.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}

//     private void OollisionEnter(Collision col)
//     {
//         Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();

//         Vector3 direction = new Vector3(0, 0, 5);

//         rb.AddForce(direction * force, ForceMode.Impulse);
//     }
// }
