using UnityEngine;
using System.Collections;

public class StickmanAttack : MonoBehaviour {

    StickmanAnim anim;
    bool canAttack = true;
    public int damage = 200;

    void SetAnimator(StickmanAnim an)
    {
        anim = an;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!canAttack)
            return;
        if (col.CompareTag("Castle"))
        {
            anim.Attack();
            canAttack = false;
            StartCoroutine(castleDamage());
        }
    }

    void Run()
    {
        canAttack = true;
    }


    void Stop()
    {
        canAttack = false;
        StopAllCoroutines();
    }


    IEnumerator castleDamage()
    {
        while (true)
        {
            Castle.Instance.DealDamage(damage);
            yield return new WaitForSeconds(1f);
        }

    }
}
