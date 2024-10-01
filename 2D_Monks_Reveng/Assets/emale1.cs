using UnityEngine;
using System.Collections;

public class Emale1 : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float stopTime = 2f; // Time to stop at each point
    private Vector3 target;
    private bool isIdle = false;
    private Animator animator;

    void Start()
    {
        target = pointB.position;
        animator = GetComponent<Animator>();

        // Check if Animator exists to avoid errors
        if (animator == null)
        {
            Debug.LogError("Animator component missing from the Emale1 GameObject.");
        }
        else
        {
            StartCoroutine(Patrol());
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            // Move enemy towards the target
            while (Vector3.Distance(transform.position, target) > 0.1f)
            {
                MoveEnemy();
                yield return null;
            }

            // Once the enemy reaches the target, flip the direction and stop for a while
            Flip();

            // Set idle animation if animator exists
            if (animator != null)
            {
                animator.SetBool("runm1", false); // Set idle animation
            }
            
            isIdle = true;
            yield return new WaitForSeconds(stopTime); // Wait at point

            // Switch to running animation and move to the next point
            if (animator != null)
            {
                animator.SetBool("runm1", true); // Set running animation
            }

            isIdle = false;
            target = target == pointA.position ? pointB.position : pointA.position;
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
}
