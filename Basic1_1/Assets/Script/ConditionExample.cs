using UnityEngine;

public class ConditionExample : MonoBehaviour
{
    //�����ڿ� ���ǹ�
    public int health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health -= 1;
        Debug.Log("Health : " + health);

        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
