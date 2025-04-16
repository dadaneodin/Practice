using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevetationScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void Update()
    {
        // Debug.Log()
    }
}
