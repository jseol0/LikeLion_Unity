using UnityEngine;

public class IdleState : IState
{
    public void OnEnter()
    {
        Debug.Log("IdleState OnEnter");
    }

    public void OnUpdate()
    {
        Debug.Log("IdleState OnUpdate");
    }

    public void OnExit()
    {
        Debug.Log("IdleState OnExit");
    }
}
