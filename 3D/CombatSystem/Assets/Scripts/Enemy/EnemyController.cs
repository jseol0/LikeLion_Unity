using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyStates {  Idle, CombatMovement, Attack , RetreatAfterAttack, Dead }

public class EnemyController : MonoBehaviour
{
    [field:SerializeField]public float Fov { get; private set; } = 180f;
    public List<MeleeFighter> TargetsInRange { get; private set; } = new List<MeleeFighter>();
    public MeleeFighter Target {  get;  set; }
    public float combatMovementTimer { get; set; } = 0f;

    public StateMachine<EnemyController> StateMachine { get; private set; }

    Dictionary<EnemyStates, State<EnemyController>> stateDict;

    public NavMeshAgent NavAgent { get; private set; }

    public Animator Anim {  get; private set; }

    public MeleeFighter Fighter { get; private set; }

    public VisionSensor visionSensor { get; set; }

    private void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        Fighter = GetComponent<MeleeFighter>();

        stateDict = new Dictionary<EnemyStates, State<EnemyController>>();
        stateDict[EnemyStates.Idle] = GetComponent<IdleState>();
        stateDict[EnemyStates.CombatMovement] = GetComponent<CombatMovementState>();
        stateDict[EnemyStates.Attack] = GetComponent<EnemyAttackState>();
        stateDict[EnemyStates.RetreatAfterAttack] = GetComponent<RetreatAfterAttackState>();
        stateDict[EnemyStates.Dead] = GetComponent<DeadState>();

        StateMachine = new StateMachine<EnemyController>(this);
        StateMachine.ChangeState(stateDict[EnemyStates.Idle]);
    }

    public void ChangeState(EnemyStates state)
    {
        StateMachine.ChangeState(stateDict[state]);
    }

    public bool IsInState(EnemyStates state)
    {
        return StateMachine.CurrentState == stateDict[state];
    }

    Vector3 prevPos;

    private void Update()
    {
        StateMachine.Execute();

        var deltaPos = transform.position - prevPos;
        var velocity = deltaPos / Time.deltaTime;

        float forwardSpeed =  Vector3.Dot(velocity, transform.forward);

        Anim.SetFloat("forwardSpeed", forwardSpeed / NavAgent.speed, 0.2f, Time.deltaTime);

        float angle = Vector3.SignedAngle(transform.forward, velocity, Vector3.up);
        float strafeSpeed = Mathf.Sin(angle * Mathf.Deg2Rad);
        Anim.SetFloat("strafeSpeed", strafeSpeed, 0.2f, Time.deltaTime);

        prevPos = transform.position;
    }
}