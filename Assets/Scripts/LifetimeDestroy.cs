using UnityEngine;
using System.Collections;

public class LifetimeDestroy : MonoBehaviour {

    public float lifeTime = 1;
		
	void FixedUpdate () {
        if (lifeTime <= 0)
            Destroy(gameObject);
        lifeTime -= Time.fixedDeltaTime;
	}
}
