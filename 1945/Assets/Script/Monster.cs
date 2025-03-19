using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Monster : MonoBehaviour
{

    public int HP = 100;
    public float speed = 2f;
    public float delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;

    public GameObject item = null;

    void Start()
    {
        //Invoke("CreateBullet", delay);
        StartCoroutine(CreateCoroutine());
    }
    void Update()
    {
        float distanceY = speed * Time.deltaTime;

        transform.Translate(Vector2.down * distanceY);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        //재귀 호출
        //Invoke("CreateBullet", delay);
    }

    IEnumerator CreateCoroutine()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            CreateBullet();
            yield return new WaitForSeconds(1f);
        }
    }

    public void Damage(int attack)
    {
        HP -= attack;

        if (HP <= 0)
        {

            ItemDrop();
            Destroy(gameObject);
            //PoolManager.Instance.Return(gameObject);
        }
    }

    void ItemDrop()
    {
        float dropChance = Random.Range(0f, 10f);

        if (dropChance <= 4f)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
    
}
