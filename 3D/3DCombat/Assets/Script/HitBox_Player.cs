using TMPro;
using UnityEngine;

public class HitBox_Player : MonoBehaviour
{
    public Animator playerAni;
    public TextMeshProUGUI message;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Col_EnemyAttack"))
        {
            Debug.Log("타격받음");
            if(gameObject.CompareTag("HitBox_Player"))
            {
                //데미지입은 애니메이션

                message.text = "Player Damage";
                message.gameObject.SetActive(true);
            }

            if(gameObject.CompareTag("Defence"))
            {
                message.text = "Block";
                message.gameObject.SetActive(true) ;
            }

            if (gameObject.CompareTag("Parrying"))
            {
                playerAni.Play("Counter");
                message.text = "Parrying";
                message.gameObject.SetActive(true);
            }
        }
    }
}