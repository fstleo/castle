using UnityEngine;
using System.Collections;
using System;

public class RunState : StickmanState
{
    private RunnerParameters parameters;
    private Transform tform;

    float timeout = 0.5f;

    public RunState(RunnerParameters param, Transform transform)
    {
        parameters = param;
        tform = transform;
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
            tform.position += tform.right * parameters.MaxSpeed * Time.deltaTime;
        }
    }

}
