using UnityEngine;

public class Boss_Head : MonoBehaviour
{
    [SerializeField]
    private GameObject bossBullet;

    public void RightDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);

        go.GetComponent<Boss_Bullet>().Move(new Vector2(1, -1));
        Debug.Log("R!");
    }

    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);

        go.GetComponent<Boss_Bullet>().Move(new Vector2(-1, -1));
        Debug.Log("L!");
    }

    public void DownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);

        go.GetComponent<Boss_Bullet>().Move(new Vector2(0, -1));
        Debug.Log("D!");
    }
}
