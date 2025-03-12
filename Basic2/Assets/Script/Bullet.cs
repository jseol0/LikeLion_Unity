using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject exposion;
    void Start()
    {
        //Singleton.Instance.PrintMessage();
    }

    void Update()
    {
        //Y축 이동
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //2D 충돌 트리거 이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딪치면
        if (collision.CompareTag("Enemy"))
        {
            //폭발 이펙트 생성
            Instantiate(exposion, transform.position, Quaternion.identity);
            //죽음사운드
            SoundManager.instance.PlayDieSound();
            //점수올리기
            GameManager.instance.AddScore(10);
            //적 지우기
            Destroy(collision.gameObject);
            //총알 지우기
            Destroy(gameObject);
        }
    }
}
