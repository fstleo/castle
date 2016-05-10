using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

    public delegate void GameOverDelegate();
    public event GameOverDelegate GameOverEvent;

    public delegate void HealthChange(int value, int maxValue);
    public event HealthChange OnChangeHealthValue;

    public static Castle Instance
    {
        get;
        private set;
    }

    int maxHP = 1000;
    int _hp = 1000;
    int HP
    {
        get
        { return _hp; }
        set
        {
            _hp = value;
            if (_hp <= 0)
                Gameover();
        }
    }

    void Gameover()
    {
        if (GameOverEvent != null)
        {
            GameOverEvent();
        }
            
    }

	void Awake ()
    {
        Instance = this;
	}
	
	public void DealDamage(int value)
    {
        HP -= value;
        if (OnChangeHealthValue != null)
            OnChangeHealthValue(HP, maxHP);        
    }
}
