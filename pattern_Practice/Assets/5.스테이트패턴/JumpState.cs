using UnityEngine;

public class JumpState : IState
{
    public void OnEnter()
    {
        Debug.Log("JumpState OnEnter");
    }

    public void OnUpdate()
    {
        Debug.Log("JumpState OnUpdate");
    }

    public void OnExit()
    {
        Debug.Log("JumpState OnExit");
    }
}
