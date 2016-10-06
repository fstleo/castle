using UnityEngine;
using System;

public abstract class StickmanState
{

    public bool IsProcessing
    { get; private set; }

    public event Action OnEnterState;
    public event Action OnExitState;

    public virtual void EnterState()
    {
        if (IsProcessing)
            return;
        if (OnEnterState != null)
            OnEnterState();
        IsProcessing = true;
	}

    public abstract void ProcessState();

    public virtual void ExitState()
    {
        if (!IsProcessing)
            return;
        if (OnExitState != null)
            OnExitState();
        IsProcessing = false;
    }
}
