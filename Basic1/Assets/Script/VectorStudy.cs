using UnityEngine;

public class VectorStudy : MonoBehaviour
{

    //public Vector2 v2 = new Vector2(10, 10);
    //public Vector3 v3 = new Vector3(1, 1, 1);

    void Start()
    {
        //Vector3 a = new Vector3(1, 1, 0);
        //Vector3 b = new Vector3(2, 0, 0);

        //Vector3 c = a + b;

        //Debug.Log($"Vector {c}");
        //Debug.Log($"길이 : {c.magnitude}");

        // 정규화 normalize
        // 벡터의 크기를 1로 반들고 방향만 유지
        Vector3 a = new Vector3(3, 0, 0);
        Vector3 normalizedVector = a.normalized;

        Debug.Log($"정규화 : {normalizedVector}");
    }

    void Update()
    {
        
    }
}
