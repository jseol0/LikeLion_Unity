using System.Collections;
using UnityEngine;

public class AxeController : CloseWeaponController
{
    public static bool isActivate = false;

    void Update()
    {
        if (isActivate)
            TryAttack();
    }

    protected override IEnumerator HitCoroutine()
    {
        while (isSwing)
        {
            if (CheckObject())
            {
                isSwing = false;

            }
            yield return null;
        }
    }

    public override void CloseWeaponChange(closeWeapon _closeWeapon)
    {
        base.CloseWeaponChange(_closeWeapon);
        isActivate = true;
    }
}
