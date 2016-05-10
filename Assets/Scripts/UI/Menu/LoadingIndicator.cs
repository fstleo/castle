using UnityEngine;
using System.Collections;

public class LoadingIndicator : MonoBehaviour {
    
    RectTransform graphicTform;

	void Awake ()
    {        
        graphicTform = (RectTransform)transform.GetChild(0);
	}

    void Update()
    {
        graphicTform.Rotate(0, 0, -2);
    }

	
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
