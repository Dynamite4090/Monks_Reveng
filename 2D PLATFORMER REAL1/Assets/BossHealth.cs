using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathsound;
    [SerializeField] private AudioClip hurtsound;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        // Ensure the game over screen is initially disabled
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt2");
            StartCoroutine(Invulnerability());
            SoundManager.instance.PlayerSound(hurtsound);
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die2");

                // Disable the boss-specific behavior or other actions upon death
                if (GetComponent<BossHealth>() != null)
                    GetComponent<BossHealth>().enabled = false;

                dead = true;

                SoundManager.instance.PlayerSound(deathsound);

                // Activate game over screen
                if (gameOverScreen != null)
                {
                    gameOverScreen.SetActive(true);
                }
            }
        }
    }

    public void PlayAgain()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator Invulnerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.1f);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(0.1f); // Adjust the delay if needed
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
