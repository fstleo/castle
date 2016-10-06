using UnityEngine;

public class Stickman : MonoBehaviour {

    [SerializeField]
    private AttackerParameters aParams;
    [SerializeField]
    private RunnerParameters rParams;
    [SerializeField]
    private FlyingParameters fParams;

    StickmanStateMachine stateController;

    private Transform tform;
    private StickmanAnim anim;

    void Awake()
    {
        tform = transform;
        anim = GetComponent<StickmanAnim>();
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
        anim.SetSpeed(rParams.MoveSpeed);
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
        stateController.SetState(StickmanStateEnum.Fly);
    }

    private void SetRun()
    {
        stateController.SetState(StickmanStateEnum.Run);
    }

    private void SetAttack()
    {
        stateController.SetState(StickmanStateEnum.Attack);
    }

    private void CheckTarget()
    {
        if ((tform.position - aParams.Target.Tform.position).sqrMagnitude < aParams.Range * aParams.Range)
        {
            SetAttack();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.sqrMagnitude > 10)
        { 
            enabled = false;
            anim.Die();
        }
    }
}
