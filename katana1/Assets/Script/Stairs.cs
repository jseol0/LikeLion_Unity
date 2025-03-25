using UnityEngine;

public class Stairs : MonoBehaviour
{
    //trigger 충돌이 일어났을때 통과
    //collision 충돌이 일어났을때 통과x

    public GameObject Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
