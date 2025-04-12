using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class beguniScript : MonoBehaviour
{
    public Transform[] runners;
    public Transform movementObject;
    // public Transform newParent;

    public bool Go;
    public float Speed = 3;
    public float passDistance = 0.5f;

    private int activeRunner = 0;
    



    void Start()
    {

    }

    void Update()
    {
        Transform current = runners[activeRunner];
        Transform next = runners[(activeRunner + 1) % runners.Length];
        movementObject.SetParent(current, false);

        current.position = Vector3.MoveTowards(current.position, next.position, Speed * Time.deltaTime);

        current.LookAt(next);

        float distance = Vector3.Distance(current.position, next.position);

        if(distance < passDistance)
        {
            activeRunner = (activeRunner + 1) % runners.Length;
        }


    }
}
