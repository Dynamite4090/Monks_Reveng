using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float stopTime = 2f; // Time to stop at each point
    public GameObject fireballPrefab; // Reference to the Fireball prefab
    public float fireballSpeed = 5f;
    public float fireballInterval = 2f; // Time between fireball shots

    private Vector3 target;
    private bool isIdle = false;
    private Animator animator;

    void Start()
    {
        target = pointB.position;
        animator = GetComponent<Animator>(); // Assuming you have an Animator for the idle/run animations
        StartCoroutine(Patrol());
        StartCoroutine(ShootFireball());
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
            animator.SetBool("runF1", false); // Set idle animation
            isIdle = true;
            yield return new WaitForSeconds(stopTime); // Wait at point

            // Switch to running animation and move to the next point
            animator.SetBool("runF1", true);
            isIdle = false;
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }

    IEnumerator ShootFireball()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireballInterval);
            Fire();
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

    void Fire() { GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity); fireball.GetComponent<Fireball>().speed = fireballSpeed * transform.localScale.x; }
}