using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    public float speed = 4f;
    public int Attack = 10;
    public GameObject effect;

    private void Update()
    {
        float distanceY = speed * Time.deltaTime;
        //transform.Translate(0, distanceY, 0);
        transform.Translate(Vector2.up * distanceY);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(go, 1);

            collision.gameObject.GetComponent<Monster>().Damage(Attack);

            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            GameObject go = Instantiate(effect, /*collision.*/transform.position, Quaternion.identity);
            Destroy(go, 1);

            //collision.gameObject.GetComponent<Monster>().Damage(1);

            Destroy(gameObject);
        }
    }
}
