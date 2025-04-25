using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat strenght;
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

    [SerializeField] private int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
        critPower.SetDefaultValue(150);

        //damage.AddModifier(4);
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        if (CanAvoidAttack(_targetStats))
            return;

        int totalDamage = damage.GetValue() + strenght.GetValue();

        if (CanCrit())
            totalDamage = CalculateCriticalDamage(totalDamage);

        totalDamage = CheckTargetArmor(_targetStats, totalDamage);

        //_targetStats.TakeDamage(totalDamage);
        DoMagicalDamage(_targetStats);
    }

    public virtual void DoMagicalDamage(CharacterStats _targetStats)
    {
        int _fireDamage = fireDamage.GetValue();
        int _iceDamage = iceDamage.GetValue();
        int _lightingDamage = lightingDamage.GetValue();

        int totalMagicalDamage = _fireDamage + _iceDamage + _lightingDamage + intelligence.GetValue();
        totalMagicalDamage = CheckTargetResistance(_targetStats, totalMagicalDamage);

        _targetStats.TakeDamage(totalMagicalDamage);
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
        float totalcirtPower = (critPower.GetValue() + strenght.GetValue()) * 0.01f;
        float critDamage = _damage * totalcirtPower;

        return Mathf.RoundToInt(critDamage);
    }
}
