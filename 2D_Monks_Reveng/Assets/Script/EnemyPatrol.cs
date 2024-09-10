using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector3 target;
    private Animator animator;

    void Start()
    {
        target = pointB.position;
        animator = GetComponent<Animator>();
        SetAnimationState("Run");
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
            Flip();
        }

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            SetAnimationState("Idle");
        }
        else
        {
            SetAnimationState("Run");
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void SetAnimationState(string state)
    {
        animator.Play(state);
    }
}
