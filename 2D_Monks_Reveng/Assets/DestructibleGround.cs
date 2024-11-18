using UnityEngine;
using System.Collections;

public class DestructibleGround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DestroyGround());
        }
    }

    private IEnumerator DestroyGround()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds
        Destroy(gameObject); // Destroy the ground
    }
}
