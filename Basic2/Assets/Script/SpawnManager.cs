using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //몬스터 가지고오기
    public GameObject enemy;

    void SpwanEnemy()
    {
        float randomX = Random.Range(-2f, 2f);

        Instantiate(enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }


    void Start()
    {
        InvokeRepeating("SpwanEnemy", 1.0f, 0.7f);
    }

    void Update()
    {
        
    }
}
