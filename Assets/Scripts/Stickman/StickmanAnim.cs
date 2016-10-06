using UnityEngine;
using System.Collections;

public class StickmanAnim : MonoBehaviour
{
    Animator anim;

    public void Init()
    {        
        anim = GetComponent<Animator>();        
    }

    public void SetSpeed(float value)
    {
        anim.SetFloat("Speed", value);
    }

    private void ResetBools()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Fly", false);
        anim.SetBool("Attack", false);
    }

    public void Run()
    {
        ResetBools();
        anim.SetBool("Run", true);        
    }

    public void Attack()
    {
        ResetBools();
        anim.SetBool("Attack", true);
    }

    public void Fly()
    {
        ResetBools();
        anim.SetBool("Fly", true);
    }

    public void Die()
    {
        ResetBools();
        anim.SetBool("Die", true);
        gameObject.AddComponent<LifetimeDestroy>().lifeTime = 2;
    }
}
