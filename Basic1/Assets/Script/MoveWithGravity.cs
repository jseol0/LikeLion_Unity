using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{
    public Rigidbody rb;

    public float jumpForce = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        //space 키 입력하면 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Rigiedbody : 물리효과를 추가해 중력을 적용
            //AddForce : 점프를 위해 오프젝트에 힘을 준다
            //ForceMode.Impulse : 순간적으로 힘을 가하는 옵션
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
