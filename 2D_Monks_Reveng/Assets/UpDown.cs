using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public Transform pointA; // The starting point
    public Transform pointB; // The destination point
    public float speed = 3f; // Speed of the saw

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = pointB.position; // Start moving towards point B
    }

    void Update()
    {
        MoveSaw();
    }

    void MoveSaw()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the saw reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Switch target position when reaching point A or B
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }
}


