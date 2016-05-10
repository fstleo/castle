using UnityEngine;
using System.Collections;

public class StickmanAnim : MonoBehaviour
{
    Animator anim;

    public void Go()
    {        
        anim = GetComponent<Animator>();
        gameObject.SendMessage("SetAnimator", this);
    }

    public void SetSpeed(float value)
    {
        anim.SetFloat("Speed", value);
    }

    public void Run()
    {
        anim.SetTrigger("Run");        
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void Fly()
    {
        anim.ResetTrigger("Stand");
        anim.SetTrigger("Fly");
    }

    public void StandUp()
    {
        anim.SetTrigger("Stand");       
    }

    void OnStandUp()
    {
        gameObject.SendMessage("Run");
    }

    public void Die()
    {
        //Instantiate(blood, transform.position, Quaternion.identity);
        //Destroy(gameObject);
        anim.SetTrigger("Die");        
        gameObject.AddComponent<LifetimeDestroy>().lifeTime = 2;
    }
}
