using UnityEngine;



public enum AICombatStates {  Idle, Chase, Circling}


public class CombatMovementState : State<EnemyController>
{
    [SerializeField] float distanceToStand = 3f;
    [SerializeField] float adjustDistanceThreshold = 1f;


    AICombatStates state;
    
    EnemyController enemy;
    public override void Enter(EnemyController owner)
    {
        enemy = owner;

        enemy.NavAgent.stoppingDistance = distanceToStand;
    }

    public override void Execute()
    {

        if(Vector3.Distance(enemy.Target.transform.position,enemy.transform.position) >distanceToStand + adjustDistanceThreshold)
        {
            StartChase();
        }




        if(state == AICombatStates.Idle)
        {

        }
        else if(state == AICombatStates.Chase)
        {
            if (Vector3.Distance(enemy.Target.transform.position, enemy.transform.position) <= distanceToStand +0.03f )
            {
                StartIdle();
                return;
            }
                enemy.NavAgent.SetDestination(enemy.Target.transform.position);
        }
        else if(state ==AICombatStates.Circling)
        {

        }

        
        enemy.Anim.SetFloat("moveAmount", enemy.NavAgent.velocity.magnitude /enemy.NavAgent.speed);
    }

    void StartChase()
    {
        state = AICombatStates.Chase;
        enemy.Anim.SetBool("combatMode", false);
    }
    void StartIdle()
    {
        state = AICombatStates.Idle;
        enemy.Anim.SetBool("combatMode", true);
    }


    public override void Exit()
    {
        
    }


}