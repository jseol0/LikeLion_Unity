using UnityEngine;

public class Monster_Bullet : MonoBehaviour
{
    public float speed = 3f;
    public GameObject effect;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(go, 1);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
