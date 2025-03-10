using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    //스크롤할 속도를 상수로 지정해 줍니다
    public float scrollSpeed = 1.2f;
    //쿼드의 머터리얼 데이터를 받아올 객체를 선언합니다.
    private Material thisMaterial;

    void Start()
    {
        //객체가 생성될때 최초 1회 호출되는 함수
        //현재 객체의 Component들을 참조해 Renderer 라는 컴포넌트의 Material정보

        thisMaterial = GetComponent<Renderer>().material;

    }

    void Update()
    {
        //새롭게 지정해줄 Offset 객체를 선언합니다
        Vector2 newoffset = thisMaterial.mainTextureOffset;
        //Y부분에 현재 Y값에 속도에 프레임 보정해서 더해줍니다
        newoffset.Set(0, newoffset.y + (scrollSpeed * Time.deltaTime));
        //최종적으로 offset값을 지정해줍니다
        thisMaterial.mainTextureOffset = newoffset;
    }
}
