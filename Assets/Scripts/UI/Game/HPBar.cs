using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    Slider bar;

	void Start ()
    {
        bar = GetComponent<Slider>();
        Castle.Instance.OnChangeHealthValue += BarValueChange;
	}


    public void BarValueChange(int value, int maxValue)
    {
        bar.value = (float)value / maxValue;
    }

    void OnDestroy()
    {
        Castle.Instance.OnChangeHealthValue -= BarValueChange;
    }
}