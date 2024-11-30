
using System.Collections;
using UnityEngine;

public class Distructive : MonoBehaviour
{
    private bool isPlayerOnPlatform = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isPlayerOnPlatform)
            {
                isPlayerOnPlatform = true;
                StartCoroutine(DestroyPlatformAfterDelay());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }

    private IEnumerator DestroyPlatformAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 2 seconds

        if (isPlayerOnPlatform) // Destroy only if player is still on the platform
        {
            Destroy(gameObject); // Destroy the platform
        }
    }
}
