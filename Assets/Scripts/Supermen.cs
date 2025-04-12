using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supermen : MonoBehaviour
{
    public float force;



    void FixUpdate()
    {
        // TimeToExplosion -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Rigidbody rigidbodyOther = other.gameObject.GetComponent<Rigidbody>();

            // if (rigidbodyOther != null)
            // {
                Vector3 direction = rigidbodyOther.transform.position - transform.position;

                rigidbodyOther.AddForce(direction.normalized * force * (Vector3.Distance(transform.position, rigidbodyOther.transform.position)), ForceMode.Impulse);
            // }
        }
    }

    private void FixedUpdate()
    {
        
    }
}
