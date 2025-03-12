using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
