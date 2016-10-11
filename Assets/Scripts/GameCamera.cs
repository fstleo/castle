using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    Camera cam;

    public static bool NeedFlip
    {
        get
        {            
            return PlayerPrefs.GetInt("CameraFlip", 0) > 0;
        }
        set
        {
            PlayerPrefs.SetInt("CameraFlip", value ? 1 : 0);
        }
    }

	void Awake()
    {        
        cam = GetComponent<Camera>();
        if (NeedFlip)
        {
            transform.position = -transform.position;
            transform.rotation = Quaternion.Euler(0, 180, 0);            
        }
        ChangeBounds();
	}

    void ChangeBounds()
    {
        float aspectRatio = (float)Screen.width/Screen.height;
        cam.orthographicSize = 5 + (1.75f - aspectRatio) * 5;
    }
	
}

