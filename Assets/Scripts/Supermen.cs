using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float force;


    void FixUpdate()
    {
        TimeToExplosion -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject = collision.GameObject;

        RigidBody rb = other.GetCommponent<RigidBody>();

        Vector3 direction


        if(other.layer == LayerMask.NameToLayer("BadGuy"))
        {
            rb.AddForce(direction.normalized * force * (Radius - Vector3.Distance(transform.position, B.transform.position)), ForceMode.Impulse);
        }
    }


    //         if(Vector3.Distance(transform.position, B.transform.position) < Radius)
    //         {
    //             Vector3 direction = B.transform.position - transform.position;

    //             B.AddForce(direction.normalized * Power * (Radius - Vector3.Distance(transform.position, B.transform.position)), ForceMode.Impulse);
    //         }
    //     }
        
    //     TimeToExplosion = 3;
    //}



    private void FixedUpdate()
    {
        
    }
}
