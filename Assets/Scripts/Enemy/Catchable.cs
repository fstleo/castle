using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Catchable : MonoBehaviour
{
    public bool IsCatched
    {
        get; private set;
    }

    public event Action OnCatchEvent;
    public event Action OnThrowEvent;

    private Rigidbody2D rbody;
    private Transform tform;

	void Awake ()
    {
        tform = transform;
        rbody = GetComponent<Rigidbody2D>();
	}

    public void Catch()
    {
        IsCatched = true;
        if (OnCatchEvent != null)
            OnCatchEvent();
    }

    public void Move(Vector2 position)
    {
        tform.position = position;
    }

    public void Throw(Vector2 velocity)
    {
        IsCatched = false;
        if (OnThrowEvent != null)
            OnThrowEvent();
        rbody.WakeUp();        
        rbody.AddForce(velocity * 1000);
    }
}
