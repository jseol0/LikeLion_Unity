using UnityEngine;
using UnityEngine.UI;

public class HP_Mino : MonoBehaviour
{
    public float hp;
    public float hp_Cur;

    public Image hpBar_Front;
    public Image hpBar_Back;


    
    void Start()
    {
        hp_Cur = hp;
    }

    void SyncBar()
    {
        hpBar_Front.fillAmount = hp_Cur / hp;

        if(hpBar_Back.fillAmount > hpBar_Front.fillAmount)
        {
            hpBar_Back.fillAmount = Mathf.Lerp(hpBar_Back.fillAmount, hpBar_Front.fillAmount, Time.deltaTime);
        }


    }
    
    void Update()
    {
        SyncBar();
    }

    public GameObject Mino;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Col_PlayerAttack"))
        {
            hp_Cur -= Random.Range(100, 500);

            if(hp_Cur <=0)
            {
                Mino.GetComponent<Minotaurs>().minoAnim.Play("Samurai_Hit_knockdown2");
                GameObject go = GameObject.Find("HPBar_Boss");
                if (go != null)
                    go.SetActive(false);
                Destroy(Mino, 3);
            }
        }
    }
}