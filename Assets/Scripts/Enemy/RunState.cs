using UnityEngine;
using System.Collections;
using System;

public class RunState : StickmanState
{
    private RunnerParameters parameters;
    private Transform tform;

    public RunState(RunnerParameters param, Transform transform)
    {
        parameters = param;
        tform = transform;
    }

    public override void ProcessState()
    {
        tform.position += tform.right * parameters.MaxSpeed * Time.deltaTime ;
    }

}
