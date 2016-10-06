using UnityEngine;
using System.Collections;
using System;

public class FlyState : StickmanState
{
    private FlyingParameters parameters;
    private Transform tform;

    public bool IsDied
    { get; private set; }

    public FlyState(FlyingParameters param, Transform transform)
    {
        parameters = param;
        tform = transform;
    }

    public override void ProcessState()
    {
        if (!IsProcessing)
            return;
        if (tform.position.y > parameters.MaximumFlyHeight)
            IsDied = true;
    }
}