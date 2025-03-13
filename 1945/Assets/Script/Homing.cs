using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject target;
    public float speed = 3f;
    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        //A - B = B에서 A를 바라보는 벡터
        dir = target.transform.position - transform.position;
        //정규화
        dirNo = dir.normalized;

        //함수로 있음
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void Update()
    {
        /*  방향을 Update에서 설정해주면 계속 타겟을 쫓아옴
        dir = target.transform.position - transform.position;
        dirNo = dir.normalized;
        */

        transform.Translate(dirNo * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
