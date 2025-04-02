using UnityEngine;

public class RunState : IState
{
    public void OnEnter()
    {
        Debug.Log("RunState OnEnter");
    }

    public void OnUpdate()
    {
        Debug.Log("RunState OnUpdate");
    }

    public void OnExit()
    {
        Debug.Log("RunState OnExit");
    }
}
