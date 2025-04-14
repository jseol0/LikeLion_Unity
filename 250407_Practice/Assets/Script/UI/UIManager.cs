using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //BlackOut
    public Image blackOut_Curtain;
    float blackOut_Curtain_value;
    float blackOut_Curtain_speed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        blackOut_Curtain_value = 1;
        blackOut_Curtain_speed = 0.5f;
    }

    private void Update()
    {
        if (blackOut_Curtain_value > 0)
            HideBlackOut_Curtain();
    }

    public void HideBlackOut_Curtain()
    {
        blackOut_Curtain_value -= Time.deltaTime * blackOut_Curtain_speed;
        blackOut_Curtain.color = new Color(0, 0, 0, blackOut_Curtain_value);
    }
}
