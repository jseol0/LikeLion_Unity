using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 1.5f;
    void Start()
    {
        
    }

    void Update()
    {
        float distanceY = speed * Time.deltaTime;

        transform.Translate(0, -distanceY, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
