using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        ////키 입력에 따라 이동
        //float move = Input.GetAxis("Horizontal");

        //// 방향 * 스피드 * 타임델타타임
        //transform.Translate(Vector3.right * move * speed * Time.deltaTime);

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);    //x,y 이동
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));      //x.z 이동
        
        transform.position += move * speed * Time.deltaTime;
        //transform.Translate(move * speed * Time.deltaTime);
    }
}
