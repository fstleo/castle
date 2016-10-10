using UnityEngine;
using UnityEngine.UI;
using System;

public class Castle : MonoBehaviour {

    [SerializeField]
    Slider bar;

    public event Action GameOverEvent;
    
    public event Action<float> OnChangeHealthValue;

    public static Castle Instance
    {
        get;
        private set;
    }

    Destroyable hpScript;   

	void Awake ()
    {
        Instance = this;
        hpScript = GetComponent<Destroyable>();
        hpScript.OnGetDamageEvent += HpScript_OnGetDamageEvent;
        hpScript.OnDieEvent += Gameover;
	}

    private void HpScript_OnGetDamageEvent(float currentHpValue)
    {
        bar.value = currentHpValue;
    }

    void Gameover()
    {
        if (GameOverEvent != null)
        {
            GameOverEvent();
        }

    }

}
