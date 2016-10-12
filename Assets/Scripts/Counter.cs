using UnityEngine;
using UnityEngine.UI;
using Assets.Crypto;

public class Counter : MonoBehaviour {

    public static Counter Instance
    {
        get;
        private set;
    }

    Text label;
    
    public int lclscrs
    {
        get
        {
            int result;            
            if ((PlayerPrefs.HasKey("aaa")) && (int.TryParse(MemoryCrypto.Decode(PlayerPrefs.GetString("aaa")), out result)))
                return result;
            else
                return 0;
        }
        private set
        {
            PlayerPrefs.SetString("aaa", MemoryCrypto.Encode(value.ToString()));
        }
    }

	void Start ()
    {
        Instance = this;
        lclscrs = 0;
        label = GetComponent<Text>();
        label.text = "0";
        Castle.Instance.GameOverEvent += PushScores;
    }

    void OnDestroy()
    {
        Castle.Instance.GameOverEvent -= PushScores;
    }
		
	public void StickmanDeath ()
    {
        lclscrs++;        
        label.text = lclscrs.ToString();	    
	}

    public void PushScores()
    {
        CDAnalytics.Event(AnalyticsEvent.GameOver, lclscrs);
        Scores.PushScores(lclscrs);        
    }
}
