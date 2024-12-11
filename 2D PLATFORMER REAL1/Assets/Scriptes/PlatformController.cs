//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlatformController : MonoBehaviour
//{
//    public Transform posA, posB;
//    public int Speed;
//    Vector2 targetPos;

//    void Start()
//    {
//        targetPos = posB.position;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;

//        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;

//        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            collision.transform.SetParent(this.transform);
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            collision.transform.SetParent(null);
//        }

//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform posA, posB;
    public int Speed;
    Vector2 targetPos;

    void Start()
    {
        targetPos = posB.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
            targetPos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < 0.1f)
            targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    // This method ensures the player's position is updated relative to the platform's movement
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Calculate the position difference between the player and the platform
            Vector3 offset = collision.transform.position - transform.position;
            collision.transform.position = transform.position + offset;
        }
    }
}

