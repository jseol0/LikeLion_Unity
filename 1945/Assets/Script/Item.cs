using UnityEngine;

public class Item : MonoBehaviour
{
    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;
       
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));

        Destroy(gameObject, 15f);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.LevelUp(); // 레벨 증가
            }
            Destroy(gameObject);
        }
    }
}
