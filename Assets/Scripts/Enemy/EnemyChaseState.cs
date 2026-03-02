using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IState
{
    public void EnterState()
    {
        Debug.Log("Enemy is chasing");
    }

    public void ExitState()
    {

    }

    public void SetStateMachine(BaseStateMachine stateMachine)
    {

    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }
}
