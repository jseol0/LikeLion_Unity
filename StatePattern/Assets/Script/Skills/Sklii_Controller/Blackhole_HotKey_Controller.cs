using TMPro;
using UnityEngine;

public class Blackhole_HotKey_Controller : MonoBehaviour
{
    private SpriteRenderer sr;
    private KeyCode myHotKey;
    private TextMeshProUGUI myTexy;

    private Transform myEnemy;
    private Blackhole_Skill_Controller blackhole;

    public void SetupHotKey(KeyCode _myHotKey, Transform _myEnemy, Blackhole_Skill_Controller _myBlackhole)
    {
        sr = GetComponent<SpriteRenderer>();
        myHotKey = _myHotKey;
        myEnemy = _myEnemy;
        blackhole = _myBlackhole;

        myTexy = GetComponentInChildren<TextMeshProUGUI>();
        myTexy.text = _myHotKey.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(myHotKey))
        {
            blackhole.AddEnemyToList(myEnemy);

            myTexy.color = Color.clear;
            sr.color = Color.clear;
        }
    }
}
