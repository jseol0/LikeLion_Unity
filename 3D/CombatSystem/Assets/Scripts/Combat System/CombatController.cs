using UnityEngine;

// 전투 시스템을 총괄하는 컨트롤러 클래스
public class CombatController : MonoBehaviour
{
    // 근접 전투 시스템 참조
    MeleeFighter meeleFighter;

    private void Awake()
    {
        // 근접 전투 컴포넌트 가져오기
        meeleFighter = GetComponent<MeleeFighter>();
    }

    private void Update()
    {
        // 마우스 좌클릭 시 공격 시도
        if (Input.GetMouseButtonDown(0))
        {
            // var enemy = EnemyManager.i.GetAttackingEnemy();
            // if (enemy != null && enemy.Fighter.IsCounterable && !meeleFighter.inAction)
            // {
            //     //StartCoroutine(meeleFighter.PerformCounterAttack(enemy));
            // }
            // else
            // {
            //     meeleFighter.TryToAttack();
            // }
            meeleFighter.TryToAttack();
        }
        if (Input.GetMouseButtonDown(1))
        { 
            var enemy = EnemyManager.i.GetAttackingEnemy();
            if (enemy != null && enemy.Fighter.IsCounterable && !meeleFighter.inAction)
            {
                StartCoroutine(meeleFighter.PerformCounterAttack(enemy));
            }
        }
    }
}
