using UnityEngine;
using System.Collections;
using System;

public class RunState : StickmanState
{
    private RunnerParameters parameters;
    private Transform tform;

    float timeout = 0.5f;

    public float Speed
    {
        get; private set;
    }

    public RunState(RunnerParameters param, Transform transform)
    {
        parameters = param;        
        tform = transform;
        Speed = parameters.GetSpeedValue();
    }

    public override void EnterState()
    {
        timeout = 0.5f;
        base.EnterState();
    }

    public override void ProcessState()
    {
        if (timeout > 0)
        {
            timeout -= Time.deltaTime;
        }
        else
        {
            tform.position += tform.right * Speed * Time.deltaTime;
        }
    }

}
