using UnityEngine;

public class StateMachine
{
    private IState currentState;

    public void ChangeState(IState newState)
    {
        currentState?.OnExit();     // 이전 상태의 OnExit() 호출
        currentState = newState;    // 상태 변경
        currentState.OnEnter();     // 새로운 상태의 OnEnter() 호출
    }

    public void Update()
    {
        currentState?.OnUpdate();   // 현재 상태의 OnUpdate() 호출
    }
}
