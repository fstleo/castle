using UnityEngine;
using System;

public class Destroyable : MonoBehaviour {

    [SerializeField]
    DestroyableParameters parameters;

    public int Health
    {
        get; private set;
    }

    public Transform Tform
    { get; private set; }

    public event Action OnDieEvent;
    public event Action<float> OnGetDamageEvent;

    private void Awake()
    {
        Tform = transform;
        Health = parameters.MaximumHealth;
    }

    private void Die()
    {
        if (OnDieEvent != null)
        {
            OnDieEvent();
        }
    }

    public void GetDamage(int damage)
    {
        Health = Mathf.Clamp(Health - damage, 0, parameters.MaximumHealth);
        if (OnGetDamageEvent != null)
        {
            OnGetDamageEvent(CalculateRatio());
        }
        if (Health == 0)
        {
            Die();
        }
    }

    private float CalculateRatio()
    {
        return 1f * Health / parameters.MaximumHealth;
    }
}
