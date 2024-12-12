// using UnityEngine;
// using System.Collections;

// public class BossMove : MonoBehaviour
// {
//     public Transform pointA;
//     public Transform pointB;
//     public float speed = 2f;
//     public float stopTime = 2f; // Time to stop at each point
//     private Vector3 target;
//     private bool isIdle = false;
//     private Animator animator;

//     void Start()
//     {
//         target = pointB.position;
//         animator = GetComponent<Animator>(); // Assuming you have an Animator for the idle/run animations
//         StartCoroutine(Patrol());
//     }

//     IEnumerator Patrol()
//     {
//         while (true)
//         {
//             // Move enemy towards the target
//             while (Vector3.Distance(transform.position, target) > 0.1f)
//             {
//                 MoveEnemy();
//                 yield return null;
//             }

//             // Once the enemy reaches the target, flip the direction and stop for a while
//             Flip();
//             animator.SetBool("Idel1", false); // Set idle animation
//             isIdle = true;
//             yield return new WaitForSeconds(stopTime); // Wait at point

//             // Switch to running animation and move to the next point
//             animator.SetBool("run2", true);
//             isIdle = false;
//             target = target == pointA.position ? pointB.position : pointA.position;
//         }
//     }

//     void MoveEnemy()
//     {
//         if (!isIdle)
//         {
//             transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
//         }
//     }

//     void Flip()
//     {
//         Vector3 localScale = transform.localScale;
//         localScale.x *= -1;
//         transform.localScale = localScale;
//     }
// }
using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float stopTime = 2f; // Time to stop at each point
    public float attackRange = 5f; // Range within which boss attacks
    public Transform player;
    private Vector3 target;
    private bool isIdle = false;
    private Animator animator;

    void Start()
    {
        target = pointB.position;
        animator = GetComponent<Animator>(); // Assuming you have an Animator for the idle/run animations
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            if (PlayerInBossArea())
            {
                AttackPlayer();
                yield return new WaitForSeconds(stopTime); // Pause briefly during attack
            }
            else
            {
                // Move enemy towards the target
                while (Vector3.Distance(transform.position, target) > 0.1f)
                {
                    MoveEnemy();
                    yield return null;
                }

                // Once the enemy reaches the target, flip the direction and stop for a while
                Flip();
                animator.SetBool("Idle1", false); // Set idle animation
                isIdle = true;
                yield return new WaitForSeconds(stopTime); // Wait at point

                // Switch to running animation and move to the next point
                animator.SetBool("run2", true);
                isIdle = false;
                target = target == pointA.position ? pointB.position : pointA.position;
            }
        }
    }

    void MoveEnemy()
    {
        if (!isIdle)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    bool PlayerInBossArea()
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }

    void AttackPlayer()
    {
        animator.SetTrigger("attack2"); // Trigger attack animation
        Debug.Log("Boss is attacking the player!");
        // Implement damage to player here, if required.
    }
}
