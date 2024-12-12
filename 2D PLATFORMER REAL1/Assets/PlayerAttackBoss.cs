using UnityEngine;

public class PlayerAttackBoss : MonoBehaviour
{
    public int attackDamage = 20;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BossHealth bossHealth = collision.gameObject.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(attackDamage);
            }
        }
    }
}

