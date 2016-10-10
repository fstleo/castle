using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StickmanStateEnum
{
    Fly,
    Run,
    Attack
}

public class StickmanStateMachine
{
    private Dictionary<StickmanStateEnum, StickmanState> states = new Dictionary<StickmanStateEnum, StickmanState>();

    public StickmanState CurrentState
    {
        get
        {
            return GetState(CurrentStateType);
        }
    }

    public StickmanStateEnum CurrentStateType
    {
        get; private set;
    }

    public StickmanStateMachine(Transform transform, FlyingParameters fParams, RunnerParameters rParams, AttackerParameters aParams)
    {        
        states.Add(StickmanStateEnum.Fly, new FlyState(fParams, transform));
        states.Add(StickmanStateEnum.Run, new RunState(rParams, transform));
        states.Add(StickmanStateEnum.Attack, new AttackState(aParams));        
    }

    public void SetState(StickmanStateEnum state)
    {
        if (CurrentState != null)
        {
            CurrentState.ExitState();
        }
        CurrentStateType = state;
        CurrentState.EnterState();
    }

    public StickmanState GetState(StickmanStateEnum state)
    {
        return states[state];
    }	

    public void Process()
    {
        CurrentState.ProcessState();
    }
}
