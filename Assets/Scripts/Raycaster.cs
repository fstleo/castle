using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

    Camera cam;
    LayerMask mask;
    Catchable current;
    Vector2 prevmousePos;     

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
                if ((fly != null) & (!fly.IsFlying))
                {
                    fly.Catch();
                    current = fly;
                    prevmousePos = Input.mousePosition;
                }
            }

        }
        if (current != null)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);                
                current.Move(mousePos);
                prevmousePos = Input.mousePosition;
            }
            else
            {
                Vector2 velocity = ((Vector2)Input.mousePosition - prevmousePos) * 20;
                if (GameCamera.NeedFlip)
                    velocity.Set(-velocity.x, velocity.y);
                Debug.Log(velocity);
                current.Throw(velocity);
                current = null;
            }
        }
            
	}
}
