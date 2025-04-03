using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    public void AttackTrigger()
    {
        player.AttackOver();
    }

    public void DashAttackTrigger()
    {
        player.DashAttackOver();
    }
}
