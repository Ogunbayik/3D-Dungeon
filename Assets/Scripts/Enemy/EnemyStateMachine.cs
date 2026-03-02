using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : BaseStateMachine
{
    public EnemyStateMachine(List<IState> states) : base(states) { }

    public override void Initialize()
    {
        base.Initialize();

        SwitchState<EnemyPatrolState>();
    }
}
