using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates { Idle, Chase }

public class EnemyController : MonoBehaviour
{
    public StateMachine<EnemyController> StateMachine { get; private set; }

    Dictionary<EnemyStates, State<EnemyController>> stateDict;

    private void Start()
    {
        stateDict = new Dictionary<EnemyStates, State<EnemyController>>();
        stateDict[EnemyStates.Idle] = GetComponent<IdleState>();
        stateDict[EnemyStates.Chase] = GetComponent<ChaseState>();

        StateMachine = new StateMachine<EnemyController>(this);
        StateMachine.ChangeState(stateDict[EnemyStates.Idle]);
    }

    private void Update()
    {
        StateMachine.Execute();
    }

    public void ChangeState(EnemyStates state)
    {
        StateMachine.ChangeState(stateDict[state]);
    }
}