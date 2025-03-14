using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Animator ani;
    public GameObject[] bullet;
    public Transform pos = null;
    
    public int level = 0;
    [SerializeField]
    private GameObject powerUp;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        // 플레이어 이동
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") < 0f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);

        if (Input.GetAxis("Horizontal") > 0f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") > 0f)
            ani.SetBool("up", true);
        else
            ani.SetBool("up", false);

        transform.Translate(moveX, moveY, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet[level], pos.position, Quaternion.identity);
        }

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다
    }

    public void LevelUp()
    {
        if (level < 3)
        {
            level++;
            GameObject go = Instantiate(powerUp, transform.position, Quaternion.identity);
            Destroy(go, 1);
        }
        
        Debug.Log("레벨업! 현재 레벨: " + level);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            LevelUp();
            Destroy(collision.gameObject);
        }
    }
}
