using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private float gunAccuracy;

    [SerializeField]
    private GameObject go_crosshairHUD;
    [SerializeField]
    private GunController theGunController;

    public void WalkingAnimation(bool _flag)
    {
        WeaponManager.currentWeaponAnim.SetBool("Walk", _flag);
        anim.SetBool("Walking", _flag);
    }

    public void RunningAnimation(bool _flag)
    {
        WeaponManager.currentWeaponAnim.SetBool("Run", _flag);
        anim.SetBool("Running", _flag);
    }

    public void JumpingAnimation(bool _flag)
    {
        anim.SetBool("Running", _flag);
    }

    public void CrouchingAnimation(bool _flag)
    {
        anim.SetBool("Crouching", _flag);
    }

    public void FineSightAnimation(bool _flag)
    {
        anim.SetBool("FineSight", _flag);
    }

    public void FireAnimation()
    {
        if (anim.GetBool("Walking"))
            anim.SetTrigger("Walk_Fire");
        else if (anim.GetBool("Crouching"))
            anim.SetTrigger("Crouch_Fire");
        else 
            anim.SetTrigger("Idle_Fire");
    }

    public float GetAccuracy()
    {
        if (anim.GetBool("Walking"))
            gunAccuracy = 0.06f;
        else if (anim.GetBool("Crouching"))
            gunAccuracy = 0.015f;
        else if (theGunController.GetFineSightMode())
            gunAccuracy = 0.001f;
        else
            gunAccuracy = 0.035f;

        return gunAccuracy;
    }
}
