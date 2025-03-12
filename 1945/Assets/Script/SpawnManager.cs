using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject monster;
    public GameObject item_power;

    void SpwanMonster()
    {
        float randomX = Random.Range(-2f, 2f);

        Instantiate(monster, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }

    void SpwanItem()
    {
        float randomX = Random.Range(-2f, 2f);

        Instantiate(item_power, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }
    IEnumerator SpwanMonsterCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            SpwanMonster();
            yield return new WaitForSeconds(0.7f);
        }
    }

    IEnumerator SpwanItemCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            SpwanItem();
            yield return new WaitForSeconds(3f);
        }
    }
    void Start()
    {
        StartCoroutine(SpwanMonsterCoroutine());
        StartCoroutine(SpwanItemCoroutine());
    }

    void Update()
    {
        
    }
}
