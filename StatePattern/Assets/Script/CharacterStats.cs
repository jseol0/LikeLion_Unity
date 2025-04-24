using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat strenght;
    public Stat maxHealth;
    public Stat damage;


    [SerializeField] private int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();

        //damage.AddModifier(4);
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        int totalDamage = damage.GetValue() + strenght.GetValue();

        _targetStats.TakeDamage(totalDamage);
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
}
