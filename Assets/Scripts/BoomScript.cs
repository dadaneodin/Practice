using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{

    public float TimeToExplosion;
    public float power;
    public float radius;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeToExplosion -= Time.deltaTime;
        
        if(TimeToExplosion <= 0)
        {
            Boom();
        }
    }

    void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody B in blocks)
        {
            if(Vector3.Distance(transform.position, B.transform.position) < radius)
            {
                Vector3 direction = B.transform.position - transform.position;

                B.AddForce(direction.normalized * power * (radius - Vector3.Distance(transform.position, B.transform.position)), ForceMode.Impulse);
            }
        }
        TimeToExplosion = 3;
    }
}
