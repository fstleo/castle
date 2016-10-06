using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

    Camera cam;
    LayerMask mask;
    Catchable current;

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
                Catchable fly = hit.transform.GetComponent<Catchable>();
                if ((fly != null) & (!fly.IsCatched))
                {
                    fly.Catch();
                    current = fly;
                }
            }

        }
        if (current != null)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);                
                current.Move(mousePos);
            }
            else
            {
                current.Throw(Vector2.zero);
                current = null;
            }
        }
            
	}
}
