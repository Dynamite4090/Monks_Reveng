
using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpsound;

    private void Awake()
    {
        //Grab references for rigdbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        // Wall jump logic
        if (wallJumpCooldown < 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();

                if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
                    SoundManager.instance.PlayerSound(jumpsound);

            }
        }
        else
            wallJumpCooldown += Time.deltaTime;


    }

    private void Jump()
    {
        if (isGrounded())
        {
            SoundManager.instance.PlayerSound(jumpsound);
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.z);
            }
            else

                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            wallJumpCooldown = 0;

        }


    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}

//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    [SerializeField] private float speed;
//    [SerializeField] private float jumpPower;
//    [SerializeField] private LayerMask groundLayer;
//    [SerializeField] private LayerMask wallLayer;
//    private Rigidbody2D body;
//    private Animator anim;
//    private BoxCollider2D boxCollider;
//    private float wallJumpCooldown;
//    private float horizontalInput;
//    private bool isStableOnPlatform; // Flag to check if the player is stable on a platform

//    [Header("SFX")]
//    [SerializeField] private AudioClip jumpSound;

//    private void Awake()
//    {
//        //Grab references for rigdbody and animator from object
//        body = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        boxCollider = GetComponent<BoxCollider2D>();
//    }

//    private void Update()
//    {
//        horizontalInput = Input.GetAxis("Horizontal");

//        //Flip player when moving left-right
//        if (horizontalInput > 0.01f)
//            transform.localScale = Vector3.one;
//        else if (horizontalInput < -0.1f)
//            transform.localScale = new Vector3(-1, 1, 1);

//        //Set animator parameters
//        anim.SetBool("run", horizontalInput != 0);
//        anim.SetBool("grounded", isGrounded());

//        // Wall jump logic
//        if (wallJumpCooldown < 0.2f)
//        {
//            if (!isStableOnPlatform)
//            {
//                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

//                if (onWall() && !isGrounded())
//                {
//                    body.gravityScale = 0;
//                    body.velocity = Vector2.zero;
//                }
//                else
//                    body.gravityScale = 7;

//                if (Input.GetKey(KeyCode.Space))
//                {
//                    Jump();

//                    if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
//                        SoundManager.instance.PlayerSound(jumpSound);
//                }
//            }
//        }
//        else
//            wallJumpCooldown += Time.deltaTime;
//    }

//    private void Jump()
//    {
//        if (isGrounded())
//        {
//            SoundManager.instance.PlayerSound(jumpSound);
//            body.velocity = new Vector2(body.velocity.x, jumpPower);
//            anim.SetTrigger("jump");
//        }
//        else if (onWall() && !isGrounded())
//        {
//            if (horizontalInput == 0)
//            {
//                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
//                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.z);
//            }
//            else
//                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
//            wallJumpCooldown = 0;
//        }
//    }

//    private bool isGrounded()
//    {
//        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
//        return raycastHit.collider != null;
//    }

//    private bool onWall()
//    {
//        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
//        return raycastHit.collider != null;
//    }

//    public bool canAttack()
//    {
//        return horizontalInput == 0 && isGrounded() && !onWall();
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("MovingPlatform"))
//        {
//            transform.parent = collision.transform; // Set the platform as the parent of the player
//            isStableOnPlatform = true; // Set flag to true
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("MovingPlatform"))
//        {
//            transform.parent = null; // Unset the parent of the player
//            isStableOnPlatform = false; // Set flag to false
//        }
//    }
//}