using UnityEngine;

public class Stickman : MonoBehaviour {
    
    public AttackerParameters aParams;    
    public RunnerParameters rParams;    
    public FlyingParameters fParams;

    StickmanStateMachine stateController;

    private Transform tform;
    private StickmanAnim anim;

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
        Catchable catchScript = GetComponent<Catchable>();
        catchScript.OnCatchEvent += SetFly;
    }

    private void InitAnimation()
    {
        anim = GetComponent<StickmanAnim>();
        anim.Init();
        anim.SetSpeed(rParams.GetSpeedValue());
        stateController.GetState(StickmanStateEnum.Attack).OnEnterState += anim.Attack;
        stateController.GetState(StickmanStateEnum.Fly).OnEnterState += anim.Fly;
        stateController.GetState(StickmanStateEnum.Run).OnEnterState += anim.Run;
    }

    void Update()
    {
        stateController.Process();
        if (stateController.CurrentStateType == StickmanStateEnum.Run)
        {
            CheckTarget();
        }
    }

    private void SetFly()
    {
        Debug.Log("State is fly");
        stateController.SetState(StickmanStateEnum.Fly);
    }

    private void SetRun()
    {
        Debug.Log("State is run");
        stateController.SetState(StickmanStateEnum.Run);
    }

    private void SetAttack()
    {
        Debug.Log("State is attack");
        stateController.SetState(StickmanStateEnum.Attack);
    }

    private void CheckTarget()
    {
        if ((tform.position - aParams.Target.Tform.position).sqrMagnitude < aParams.Range * aParams.Range)
        {
            SetAttack();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Stickman hitted on floot with velocity: ");
        Debug.Log(other.relativeVelocity.sqrMagnitude);
        if (other.relativeVelocity.sqrMagnitude > 110)
        {
            SetDie();
        }
        else
        {
            SetRun();
            
        }
    }

    private void SetDie()
    {
        gameObject.layer += 7;        
        enabled = false;
        anim.Die();
    }
}
