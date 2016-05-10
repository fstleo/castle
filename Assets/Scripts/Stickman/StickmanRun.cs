using UnityEngine;
using System.Collections;

public class StickmanRun : MonoBehaviour {

    StickmanAnim anim;

    Transform tform;
    float startSpeed = 1;
    public float speed = 1;

	void Awake ()
    {
        tform = transform;       
	}
	
	void FixedUpdate ()
    {        
        tform.position += speed * tform.right * Time.fixedDeltaTime;
	}

    void SetAnimator(StickmanAnim an)
    {
        anim = an;
        anim.SetSpeed(speed);
        startSpeed = speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {            
        if (col.CompareTag("Castle"))
        {
            Stop();
        }
    }

    void Run()
    {
        speed = startSpeed;
    }

    void Stop()
    {
        speed = 0;
    }

}
