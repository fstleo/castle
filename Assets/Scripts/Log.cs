using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Log : MonoBehaviour {

    static Text label;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(transform.parent.gameObject);
        label = GetComponent<Text>();
	}
	
	public static void Write(string log)
    {
        label.text = label.text + '\n' + log;
    }
}
