//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    public float jumpForce = 10f;
//    private bool isGrounded = false;
//    private Rigidbody2D rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {

//        float moveInput = Input.GetAxis("Horizontal");
//        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

//        if (Input.GetButtonDown("Jump") && isGrounded)
//        {
//            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = false;
//        }
//    }
//}
using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isFacingRight = true;
    private bool isDead = false; // To prevent player movement after death

    public int collectibleCount = 0; // Counter for collectibles
    public Text collectibleCountText; // Reference to the UI Text component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        UpdateCollectibleCountText(); // Update the UI at the start
    }

    void Update()
    {
        // Prevent player from moving if they are dead
        if (isDead) return;

        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Set the speed parameter in Animator
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Flip the player based on movement direction
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        // Handle jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
    }

    // Flip the player's direction
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Check for death (assuming "Enemy" tag causes player death)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with Enemy detected!");
            Die();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Trigger the death animation and stop the player's movement
    private void Die()
    {
        if (!isDead)
        {
            Debug.Log("Player is dying!");
            isDead = true;  // Player can no longer move
            animator.SetTrigger("Death");  // Trigger the death animation
            rb.velocity = Vector2.zero;  // Stop any movement
            rb.isKinematic = true;  // Disable further physics interactions (optional)
        }
    }

    // Method to handle collecting items
    public void CollectItem()
    {
        collectibleCount++;
        UpdateCollectibleCountText(); // Update the UI when an item is collected
    }

    // Method to update the UI Text element
    private void UpdateCollectibleCountText()
    {
        if (collectibleCountText != null)
        {
            collectibleCountText.text = "Collectibles: " + collectibleCount.ToString();
        }
    }
}




