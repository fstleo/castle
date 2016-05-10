using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

    Camera cam;
    LayerMask mask;

    void Start()
    {
        cam = GetComponent<Camera>();
        for (int i = 15; i < 22; i++)
            mask.value |= 1 << i;
    }
	
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 1, mask);
            if (hit)
            {
                StickmanFly fly = hit.transform.GetComponent<StickmanFly>();
                if ((fly != null) & (!fly.isDead))
                    fly.Catch();
            }

        }
            
	}
}
