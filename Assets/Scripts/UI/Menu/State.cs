using UnityEngine;
using System.Collections;

public enum MenuState
{
    Tutorial,
    Main
}


public abstract class State : MonoBehaviour {

    [SerializeField]
    public MenuState stateType;

    private GameObject go;
    
    protected virtual void Awake()
    {
        go = gameObject;
    }
	
	public virtual void Enable()
    {
        go.SetActive(true);
	}	

    public virtual void Disable()
    {
        go.SetActive(false);
    }

}
