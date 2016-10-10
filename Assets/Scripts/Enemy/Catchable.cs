using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Catchable : MonoBehaviour
{  

    public bool IsFlying
    {
        get; private set;
    }

    public event Action OnCatchEvent;
    public event Action OnThrowEvent;

    private Rigidbody2D rbody;
    private Transform tform;

    float minimumHeight;

	void Awake ()
    {
        tform = transform;
        rbody = GetComponent<Rigidbody2D>();
	}

    void Start()
    {
        minimumHeight = tform.position.y + 0.3f;
    }

    public void Catch()
    {
        IsFlying = true;
        if (OnCatchEvent != null)
            OnCatchEvent();
    }

    public void Move(Vector2 position)
    {
        position.Set(position.x, Mathf.Max(minimumHeight, position.y));
        tform.position = position;
    }

    public void Throw(Vector2 velocity)
    {
        IsFlying = false;
        if (OnThrowEvent != null)
            OnThrowEvent();
        rbody.WakeUp();        
        rbody.AddForce(velocity);
    }
}
