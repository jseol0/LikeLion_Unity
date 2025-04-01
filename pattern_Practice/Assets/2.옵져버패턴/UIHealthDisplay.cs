using UnityEngine;


//이벤트 리스너 (옵저버)
public class UIHealthDisplay : MonoBehaviour
{
    
    void Start()
    {
        //이벤트 구독
        EventManager.Instance.AddListener("PlayerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.AddListener("PlayerDied", OnPlayerDied);
    }

    private void OnDestroy()
    {
        //객체가 삭제될때 동작하는 함수
        EventManager.Instance.RemoveListener("PlayerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.RemoveListener("PlayerDied", OnPlayerDied);
    }



    private void OnPlayerHealthChanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI 업데이트: 플레이어 체력이 {health}로 변경되었습니다.");
        //실제로는 여기서 UI요소를 업데이트합니다.
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI 업데이트: 플레이어가 사망했습니다!");
        //게임 오버 화면 표시 등의 동작 수행
    }


}
