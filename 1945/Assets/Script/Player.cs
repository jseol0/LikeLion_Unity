using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Animator ani;

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
    }
}
