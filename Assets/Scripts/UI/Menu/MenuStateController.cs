using UnityEngine;
using System.Collections.Generic;

public class MenuStateController : MonoBehaviour {

    private Dictionary<MenuState, State> states = new Dictionary<MenuState, State>();

    State currentState = null;

	void Start ()
    {
	    foreach (State s in GetComponentsInChildren<State>())
        {
            states.Add(s.stateType, s);
            s.Disable();
        }
        ShowMenu();
	}

    private void SetState(MenuState s)
    {
        if (currentState != null)
        {
            currentState.Disable();
        }
        currentState = states[s];
        currentState.Enable();
        SoundPlayer.PlaySound("paper");
    }
	
	public void ShowMenu()
    {
        SetState(MenuState.Main);
    }

    public void ShowTutorial()
    {
        SetState(MenuState.Tutorial);
    }
}
