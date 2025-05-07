using System;
using System.ComponentModel;
using UnityEngine;

using Random = UnityEngine.Random;

public class CharacterStats : MonoBehaviour
{
    public Stat strength;
    public Stat health;
    public Stat maxHealth;
    public Stat damage;
    public Stat agility;
    public Stat intelligence;
    public Stat vitality;
    public Stat armor;
    public Stat evasion;
    public Stat critChance;
    public Stat critPower;

    public Stat magicResistance;
    public Stat fireDamage;
    public Stat iceDamage;
    public Stat lightingDamage;

    public bool isIgnite;
    public bool isChilled;
    public bool isShocked;

    public int currentHealth;

    public Action onHealtheChanged;

    protected virtual void Start()
    {
        currentHealth = GetMaxHealth();
        critPower.SetDefaultValue(150);

        //damage.AddModifier(4);
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        if (CanAvoidAttack(_targetStats))
            return;

        int totalDamage = damage.GetValue() + strength.GetValue();

        if (CanCrit())
            totalDamage = CalculateCriticalDamage(totalDamage);

        totalDamage = CheckTargetArmor(_targetStats, totalDamage);

        _targetStats.TakeDamage(totalDamage);
        //DoMagicalDamage(_targetStats);
    }

    public virtual void DoMagicalDamage(CharacterStats _targetStats)
    {
        int _fireDamage = fireDamage.GetValue();
        int _iceDamage = iceDamage.GetValue();
        int _lightingDamage = lightingDamage.GetValue();

        int totalMagicalDamage = _fireDamage + _iceDamage + _lightingDamage + intelligence.GetValue();
        totalMagicalDamage = CheckTargetResistance(_targetStats, totalMagicalDamage);

        _targetStats.TakeDamage(totalMagicalDamage);

        if (Mathf.Max(_fireDamage, _iceDamage, _lightingDamage) > 0)
        {
            return;
        }

        //bool canApplyIgnite = _fireDamage > _iceDamage && _fireDamage > _lightingDamage;
        //bool canApplyChill = _iceDamage > _fireDamage && _iceDamage > _lightingDamage;
        //bool canApplyShock = _lightingDamage > _fireDamage && _lightingDamage > _iceDamage;

        //while (!canApplyIgnite && !canApplyChill && !canApplyShock)
        //{
        //    if (Random.value < 0.5f && _fireDamage > 0)
        //    {
        //        canApplyIgnite = true;
        //        _targetStats.ApplyAilments(canApplyIgnite, canApplyChill, canApplyShock);
        //        return;
        //    }

        //    if (Random.value < 0.5f && _iceDamage > 0)
        //    {
        //        canApplyChill = true;
        //        _targetStats.ApplyAilments(canApplyIgnite, canApplyChill, canApplyShock);
        //        return;
        //    }

        //    if (Random.value < 0.5f && _lightingDamage > 0)
        //    {
        //        canApplyShock = true;
        //        _targetStats.ApplyAilments(canApplyIgnite, canApplyChill, canApplyShock);
        //        return;
        //    }
        //}

        //_targetStats.ApplyAilments(canApplyIgnite, canApplyChill, canApplyShock);
    }

    private static int CheckTargetResistance(CharacterStats _targetStats, int totalMagicalDamage)
    {
        totalMagicalDamage -= _targetStats.magicResistance.GetValue() + (_targetStats.intelligence.GetValue() * 3);
        totalMagicalDamage = Mathf.Clamp(totalMagicalDamage, 0, int.MaxValue);
        return totalMagicalDamage;
    }

    public void ApplyAilments(bool _ignite, bool _chill, bool _shock)
    {
        if (isIgnite || isChilled || isShocked)
        {
            return;
        }

        isIgnite = _ignite;
        isChilled = _chill;
        isShocked = _shock;
    }

    private static int CheckTargetArmor(CharacterStats _targetStats, int totalDamage)
    {
        totalDamage -= _targetStats.armor.GetValue();
        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }

    private bool CanAvoidAttack(CharacterStats _targetStats)
    {
        int totalEvasion = _targetStats.evasion.GetValue() + _targetStats.agility.GetValue();
        if (Random.Range(0, 100) < totalEvasion)
        {
            Debug.Log("회피됨");
            return true;
        }
        return false;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onHealtheChanged?.Invoke();

        if (currentHealth < 0)
            Die();
    }

    protected virtual void Die()
    {

    }

    private bool CanCrit()
    {
        int totalCriticalCahnce = critChance.GetValue() + agility.GetValue();

        if (Random.Range(0, 100) <= totalCriticalCahnce)
        {
            return true;
        }
        return false;
    }

    private int CalculateCriticalDamage(int _damage)
    {
        float totalcirtPower = (critPower.GetValue() + strength.GetValue()) * 0.01f;
        float critDamage = _damage * totalcirtPower;

        return Mathf.RoundToInt(critDamage);
    }

    public int GetMaxHealth()
    {
        return maxHealth.GetValue() + vitality.GetValue() * 10;
    }
}
