using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    public Text scoreText;
    public Text startText;

    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 씬이 바뀌어도 유지되게 하는 함수
        }
        else
        {
            Destroy(gameObject);    // 중복 생성 방지
        }
    }
    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        Time.timeScale = 0; //전체 시간 멈춤

        int i = 3;
        while (i > 0)
        {
            startText.text = i.ToString();
            //게임이 멈춰도 동작하는 대기
            yield return new WaitForSecondsRealtime(1); 
            //yield return new WaitForSeconds(1f);

            i--;
            if (i == 0)
            {
                startText.gameObject.SetActive(false);

                Time.timeScale = 1; //다시 시간 정상으로
            }
        }
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = $"Score : {score}";
    }
}
