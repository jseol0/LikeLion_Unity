using UnityEditor.Timeline;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        moveControl();
    }

    void moveControl()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, moveY, 0);
        transform.Translate(move * speed * Time.deltaTime);
    }
}
