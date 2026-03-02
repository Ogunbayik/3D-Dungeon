using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class StateMachine : IInitializable, ITickable
{
    private List<IState> _states;

    private IState _currentState;
    public StateMachine(List<IState> states) => _states = states;
    public void Initialize()
    {
        foreach (var state in _states)
            state.SetStateMachine(this);

        SwitchState<PlayerIdleState>();
    }
    public void Tick() => _currentState.Tick();
    public void SwitchState<T>() where T : IState
    {
        _currentState?.ExitState();

        _currentState = _states.OfType<T>().FirstOrDefault();
        _currentState?.EnterState();
    }

}
