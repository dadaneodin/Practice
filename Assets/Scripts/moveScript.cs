using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
 

    public bool Go;
    public float Speed;
    private Vector3 target;
    



    void Start()
    {
        target = point1.position;
    }

    void Update()
    {
        
        transform.Rotate(0, 0, 1);

        if (Go)
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * Speed);

        if(transform.position == target)
        {
            if(target == point1.position)
                target = point2.position;
            else if (target == point2.position)
                target = point1.position;
            transform.LookAt(target);
        }
        
    }

}
