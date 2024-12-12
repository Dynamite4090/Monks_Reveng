// // using UnityEngine;

// public class BossEnemyPatrol : MonoBehaviour
// {
//     [Header("Patrol Points")]
//     [SerializeField] private Transform leftEdge;
//     [SerializeField] private Transform rightEdge;

//     [Header("Enemy")]
//     [SerializeField] private Transform enemy;

//     [Header("Movement Parameters")]
//     [SerializeField] private float speed;
//     private Vector3 initScale;
//     private bool movingLeft;

//     [Header("Idle Behavior")]
//     [SerializeField] private float idleDuration;
//     private float idleTimer;

//     [Header("Attack Parameters")]
//     [SerializeField] private float attackCooldown;
//     [SerializeField] private float attackRange;
//     [SerializeField] private int attackDamage;

//     [Header("Collider Parameters")]
//     [SerializeField] private float colliderDistance;
//     [SerializeField] private BoxCollider2D boxCollider;

//     [Header("Player Layer")]
//     [SerializeField] private LayerMask playerLayer;
//     private float cooldownTimer = Mathf.Infinity;

//     [Header("Enemy Animator")]
//     [SerializeField] private Animator anim;

//     // References
//     private Health playerHealth;

//     private void Awake()
//     {
//         initScale = enemy.localScale;
//         anim = enemy.GetComponent<Animator>();

//         if (anim == null)
//         {
//             Debug.LogError("Animator component not found on " + enemy.gameObject.name);
//         }
//         else
//         {
//             Debug.Log("Animator component successfully found on " + enemy.gameObject.name);
//         }
//     }

//     private void OnDisable()
//     {
//         if (anim != null)
//         {
//             anim.SetBool("run2", false); // Stop running animation when disabled
//         }
//     }

//     private void Update()
//     {
//         cooldownTimer += Time.deltaTime;

//         if (PlayerInSight())
//         {
//             if (cooldownTimer >= attackCooldown)
//             {
//                 cooldownTimer = 0;
//                 DamagePlayer();
//             }
//         }
//         else
//         {
//             Patrol();
//         }
//     }

//     private void Patrol()
//     {
//         if (movingLeft)
//         {
//             if (enemy.position.x >= leftEdge.position.x)
//                 MoveInDirection(-1);
//             else
//                 DirectionChange();
//         }
//         else
//         {
//             if (enemy.position.x <= rightEdge.position.x)
//                 MoveInDirection(1);
//             else
//                 DirectionChange();
//         }
//     }

//     private void DirectionChange()
//     {
//         if (anim != null)
//         {
//             anim.SetBool("run2", false); // Set idle animation
//         }
//         idleTimer += Time.deltaTime;

//         if (idleTimer > idleDuration)
//             movingLeft = !movingLeft;
//     }

//     private void MoveInDirection(int _direction)
//     {
//         idleTimer = 0;
//         if (anim != null)
//         {
//             anim.SetBool("run2", true); // Set running animation
//         }

//         // Make enemy face direction
//         enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

//         // Move in that direction
//         enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
//     }

//     private bool PlayerInSight()
//     {
//         RaycastHit2D hit = Physics2D.BoxCast(
//             boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
//             new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
//             0, Vector2.left, 0, playerLayer);

//         if (hit.collider != null)
//             playerHealth = hit.transform.GetComponent<Health>();

//         return hit.collider != null;
//     }

//     private void OnDrawGizmos()
//     {
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireCube(
//             boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
//             new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
//     }

//     private void DamagePlayer()
//     {
//         if (PlayerInSight() && playerHealth != null)
//         {
//             playerHealth.TakeDamage(attackDamage);
//             // Trigger attack animation
//             if (anim != null)
//             {
//                 anim.SetTrigger("attack2"); // Trigger attack animation
//             }
//         }
//     }
// }
// using UnityEngine;

// public class BossEnemyPatrol : MonoBehaviour
// {
//     [Header("Patrol Points")]
//     [SerializeField] private Transform leftEdge;
//     [SerializeField] private Transform rightEdge;

//     [Header("Enemy")]
//     [SerializeField] private Transform enemy;

//     [Header("Movement Parameters")]
//     [SerializeField] private float speed;
//     private Vector3 initScale;
//     private bool movingLeft;

//     [Header("Idle Behavior")]
//     [SerializeField] private float idleDuration;
//     private float idleTimer;

//     [Header("Attack Parameters")]
//     [SerializeField] private float attackCooldown;
//     [SerializeField] private float attackRange;
//     [SerializeField] private int attackDamage;

//     [Header("Collider Parameters")]
//     [SerializeField] private float colliderDistance;
//     [SerializeField] private BoxCollider2D boxCollider;

//     [Header("Player Layer")]
//     [SerializeField] private LayerMask playerLayer;
//     private float cooldownTimer = Mathf.Infinity;

//     [Header("Enemy Animator")]
//     [SerializeField] private Animator anim;

//     // References
//     private Health playerHealth;

//     private void Awake()
//     {
//         initScale = enemy.localScale;
//         anim = enemy.GetComponent<Animator>();

//         if (anim == null)
//         {
//             Debug.LogError("Animator component not found on " + enemy.gameObject.name);
//         }
//         else
//         {
//             Debug.Log("Animator component successfully found on " + enemy.gameObject.name);
//         }
//     }

//     private void OnDisable()
//     {
//         if (anim != null)
//         {
//             anim.SetBool("run2", false); // Stop running animation when disabled
//         }
//     }

//     private void Update()
//     {
//         cooldownTimer += Time.deltaTime;

//         if (PlayerInSight())
//         {
//             if (cooldownTimer >= attackCooldown)
//             {
//                 cooldownTimer = 0;
//                 DamagePlayer();
//             }
//         }
//         else
//         {
//             Patrol();
//         }
//     }

//     private void Patrol()
//     {
//         if (movingLeft)
//         {
//             if (enemy.position.x >= leftEdge.position.x)
//                 MoveInDirection(-1);
//             else
//                 DirectionChange();
//         }
//         else
//         {
//             if (enemy.position.x <= rightEdge.position.x)
//                 MoveInDirection(1);
//             else
//                 DirectionChange();
//         }
//     }

//     private void DirectionChange()
//     {
//         if (anim != null)
//         {
//             anim.SetBool("Idel1", false); // Set idle animation
//         }
//         idleTimer += Time.deltaTime;

//         if (idleTimer > idleDuration)
//             movingLeft = !movingLeft;
//     }

//     private void MoveInDirection(int _direction)
//     {
//         idleTimer = 0;
//         if (anim != null)
//         {
//             anim.SetBool("run2", true); // Set running animation
//         }

//         // Make enemy face direction
//         enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

//         // Move in that direction
//         enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
//     }

//     private bool PlayerInSight()
//     {
//         RaycastHit2D hit = Physics2D.BoxCast(
//             boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
//             new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
//             0, Vector2.left, 0, playerLayer);

//         if (hit.collider != null)
//         {
//             playerHealth = hit.transform.GetComponent<Health>();
//             Debug.Log("Player in sight!");
//         }

//         return hit.collider != null;
//     }

//     private void OnDrawGizmos()
//     {
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireCube(
//             boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
//             new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
//     }

//     private void DamagePlayer()
//     {
//         if (PlayerInSight() && playerHealth != null)
//         {
//             playerHealth.TakeDamage(attackDamage);
//             // Trigger attack animation
//             if (anim != null)
//             {
//                 anim.SetTrigger("attack2"); // Trigger attack animation
//                 Debug.Log("Enemy attacked the player!");
//             }
//         }
//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
//         {
//             // Trigger attack animation when colliding with player
//             if (anim != null)
//             {
//                 anim.SetTrigger("attack2");
//                 Debug.Log("Collision with player detected - attack2 triggered");
//             }

//             // Optionally, apply damage to the player here
//             Health playerHealth = collision.gameObject.GetComponent<Health>();
//             if (playerHealth != null)
//             {
//                 playerHealth.TakeDamage(attackDamage);
//                 Debug.Log("Player took damage from collision");
//             }
//         }
//     }
// }
using UnityEngine;

public class BossEnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private int attackDamage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    // References
    private Health playerHealth;

    private void Awake()
    {
        initScale = enemy.localScale;
        anim = enemy.GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Animator component not found on " + enemy.gameObject.name);
        }
        else
        {
            Debug.Log("Animator component successfully found on " + enemy.gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (anim != null)
        {
            anim.SetBool("run2", false); // Stop running animation when disabled
        }
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                DamagePlayer();
            }
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        if (anim != null)
        {
            anim.SetBool("run2", false); // Stop running animation
            anim.SetBool("Idle1", true); // Set idle animation
            Debug.Log("Idle animation triggered");
        }
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
            if (anim != null)
            {
                anim.SetBool("Idle1", false); // Stop idle animation when changing direction
            }
        }
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        if (anim != null)
        {
            anim.SetBool("run2", true); // Set running animation
        }

        // Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        // Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
            Debug.Log("Player in sight!");
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight() && playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            // Trigger attack animation
            if (anim != null)
            {
                anim.SetTrigger("attack2"); // Trigger attack animation
                Debug.Log("Enemy attacked the player!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Trigger attack animation when colliding with player
            if (anim != null)
            {
                anim.SetTrigger("attack2");
                Debug.Log("Collision with player detected - attack2 triggered");
            }

            // Optionally, apply damage to the player here
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Player took damage from collision");
            }
        }
    }
}
