using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	void Start () {
        Application.targetFrameRate = 30;
        Application.LoadLevel(1);	
	}
	
}
