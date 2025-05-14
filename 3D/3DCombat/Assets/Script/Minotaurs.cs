using UnityEngine;

public class Minotaurs : MonoBehaviour
{
    public Animator minoAnim;
    public Transform target;
    public float minoSpeed;
    bool enableAct;
    int attackStep;

    void Start()
    {
        minoAnim = GetComponent<Animator>();
        enableAct = true;
    }

    void Update()
    {
        if (enableAct)
        {
            RotateMino();
            MoveMino();
        }
    }

    void  RotateMino()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), Time.deltaTime * 5f);
    }

    void MoveMino()
    {
        if ((target.position - transform.position).magnitude >= 3f)
        {
            minoAnim.SetBool("Walk", true);
            transform.Translate(Vector3.forward * minoSpeed * Time.deltaTime);
        }
        
        if ((target.position - transform.position).magnitude < 3f)
        {
            minoAnim.SetBool("Walk", false);
        }
    }

    void MinoAttack()
    {
        if ((target.position - transform.position).magnitude < 3f)
        {
            switch (attackStep)
            {
                case 0:
                    attackStep++;
                    minoAnim.Play("MinoAttack1");
                    break;
                case 1:
                    attackStep++;
                    minoAnim.Play("MinoAttack2");
                    break;
                case 2:
                    attackStep = 0;
                    minoAnim.Play("MinoAttack3");
                    break;
            }
        }
    }

    void FreezeMino()
    {
        enableAct = false;
    }

    void UnFreezeMino()
    {
        enableAct = true;
    }
}
