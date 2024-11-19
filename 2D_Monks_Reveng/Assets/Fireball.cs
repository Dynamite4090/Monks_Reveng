using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Add your collision logic here (e.g., damage to player)
        Destroy(gameObject);
    }
}
