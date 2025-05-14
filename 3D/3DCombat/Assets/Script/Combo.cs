using UnityEngine;

public class Combo : MonoBehaviour
{
    Animator playerAnim;
    public GameObject hitBox;

    bool comboPossible;
    bool inputSmash;
    public int comboStep;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NormalAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SmashAttack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.Play("ARPG_Samurai_Parry");
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void NextAttack()
    {
        if (!inputSmash)
        {
            HitStop.Instance.stopTime = 0.1f;
            HitStop.Instance.timeScaleRecoverySpeed = 5f;
            HitStop.Instance.shakeFrequency = 0.1f;
            HitStop.Instance.shakeIntensity = 0.1f;

            if (comboStep == 2)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Combo2");
            }
            if (comboStep == 3)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Combo3");
            }
            if (comboStep == 4)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Combo4");
            }
        }

        if (inputSmash)
        {
            HitStop.Instance.stopTime = 0.2f;
            HitStop.Instance.timeScaleRecoverySpeed = 3f;
            HitStop.Instance.shakeFrequency = 0.3f;
            HitStop.Instance.shakeIntensity = 0.3f;

            if (comboStep == 2)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Sprint");
            }
            if (comboStep == 3)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Heavy2");
            }
            if (comboStep == 4)
            {
                playerAnim.Play("ARPG_Samurai_Attack_Heavy1_Start");
            }
        }
    }

    public void ResetCombo()
    {
        comboStep = 0;
        comboPossible = false;
        inputSmash = false;
    }

    void NormalAttack()
    {
        if (comboStep == 0)
        {
            playerAnim.Play("ARPG_Samurai_Attack_Combo1");
            comboStep = 1;
            return;
        }
        
        if (comboStep != 0)
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep++;
            }
        }
    }

    void SmashAttack()
    {
        if (comboPossible)
        {
            comboPossible = false;
            inputSmash = true;
        }
    }

    // void SmashAttack()
    // {
    //     if (smashComboStep == 0)
    //     {
    //         playerAnim.Play("ARPG_Samurai_Attack_Heavy1_Start");
    //         smashComboStep = 1;
    //         inputSmash = true;
    //         return;
    //     }

    //     if (smashComboStep != 0)
    //     {
    //         if (comboPossible)
    //         {
    //             smashComboStep++;
    //             comboPossible = false;
    //             inputSmash = true;
    //         }
    //     }
    // }

    void ChangeTag(string tag)
    {
        hitBox.tag = tag;
    }
}
