using UnityEngine;
using System.Collections.Generic;

public class AttackState : StickmanState {
   
    AttackerParameters parameters;    

    float currentCooldown = 0;

    Destroyable currentVictim;

    Transform tform;    

    public AttackState(AttackerParameters param, Transform transform)
    {
        tform = transform;
        parameters = param;        
    }

    public override void ProcessState()
    {
        if (!IsProcessing)
            return;
	    if (currentCooldown < 0)
        {
            currentCooldown = parameters.Cooldown;
            Attack();
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
	}

    public override void EnterState()
    {
        if (IsProcessing)
            return;

        base.EnterState();
    }

    private void Attack()
    {
        currentVictim.GetDamage(parameters.Damage);
    }

    public void SetTarget(Destroyable target)
    {
        currentVictim = target;
    }
   
}
