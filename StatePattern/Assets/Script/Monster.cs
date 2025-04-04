using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterStateMachine stateMachine { get; private set; }
    public MonsterIdleState idleState { get; private set; }
    public MonsterMoveState moveState { get; private set; }

    void Awake()
    {
        stateMachine = new MonsterStateMachine();
        idleState = new MonsterIdleState(this, stateMachine, "idle");
        moveState = new MonsterMoveState(this, stateMachine, "move");
    }
    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        stateMachine.currentState.Update();
    }
}
