
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickSound;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlayerSound(pickSound);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
