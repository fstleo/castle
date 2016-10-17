using UnityEngine;
using System;

public class Stickman : MonoBehaviour {
    
    public AttackerParameters aParams;    
    public RunnerParameters rParams;    
    public FlyingParameters fParams;

    StickmanStateMachine stateController;
    Catchable catchScript;

    private Transform tform;
    private StickmanAnim anim;

    public Transform target;

    public event Action OnDieEvent;

    public void Init()
    {
        tform = transform;
        stateController = new StickmanStateMachine(tform, fParams, rParams, aParams);
        InitAnimation();
        InitCatching();
        SetRun();
    }

    private void InitCatching()
    {
        catchScript = GetComponent<Catchable>();
        catchScript.OnCatchEvent += SetFly;        
        catchScript.OnThrowEvent += () => GetComponent<Collider2D>().enabled = true;
    }

    private void InitAnimation()
    {
        anim = GetComponent<StickmanAnim>();
        anim.Init();        
        stateController.GetState(StickmanStateEnum.Attack).OnEnterState += anim.Attack;
        stateController.GetState(StickmanStateEnum.Fly).OnEnterState += anim.Fly;
        stateController.GetState(StickmanStateEnum.Run).OnEnterState += anim.Run;        
        anim.SetSpeed((stateController.GetState(StickmanStateEnum.Run) as RunState).Speed);
    }

    public void SetTarget(Destroyable target)
    {
        (stateController.GetState(StickmanStateEnum.Attack) as AttackState).SetTarget(target);
    }

    private void Update()
    {
        stateController.Process();
        if (stateController.CurrentStateType == StickmanStateEnum.Run)
        {
            CheckTarget();
        }
    }

    private void SetFly()
    {
        //Debug.Log("State is fly");
        SoundPlayer.PlaySound("flight_scream");
        GetComponent<Collider2D>().enabled = false;
        stateController.SetState(StickmanStateEnum.Fly);
    }

    private void SetRun()
    {
        //Debug.Log("State is run");
        stateController.SetState(StickmanStateEnum.Run);
    }

    private void SetAttack()
    {
        //Debug.Log("State is attack");
        stateController.SetState(StickmanStateEnum.Attack);
    }

    private void CheckTarget()
    {
        if ((tform.position - target.position).sqrMagnitude < aParams.Range * aParams.Range)
        {
            SetAttack();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (catchScript.IsFlying)
        {       
            return;
        }
            
        if (!enabled)
        {
            return;
        }
        Debug.Log("Collision enter");

        if (other.transform.CompareTag("Level"))
        {
            if (other.relativeVelocity.sqrMagnitude > 110)
            {
                SetDie();
            }
            else
            {
                SetRun();
            }
        }        
    }

    private void SetDie()
    {
        if (OnDieEvent != null)
            OnDieEvent();
        SoundPlayer.PlaySound("fall_scream");
        gameObject.layer += 7;        
        enabled = false;
        anim.Die();
    }
}
