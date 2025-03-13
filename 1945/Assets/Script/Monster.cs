using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Monster : MonoBehaviour
{
    public float speed = 2f;
    public float delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    public GameObject item;

    void Start()
    {
        //Invoke("CreateBullet", delay);
        StartCoroutine(CreateCoroutine());
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

    void Update()
    {
        float distanceY = speed * Time.deltaTime;

        transform.Translate(Vector2.down * distanceY);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        float dropChance = Random.Range(0f, 10f);

        if (dropChance <= 3f)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
