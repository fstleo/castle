using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    Camera cam;

	void Awake() {
        cam = GetComponent<Camera>();
        ChangeBounds();
	}

    void ChangeBounds()
    {
        float aspectRatio = (float)Screen.width/Screen.height;
        cam.orthographicSize = 5 + (1.75f - aspectRatio) * 5;
    }
	
}

