using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class UnityAd : MonoBehaviour {

    bool needShow = false;
    bool threeDaysCheck
    {
        get
        {
            if (PlayerPrefs.HasKey("firstappstart"))
            {                
                System.DateTime k = System.DateTime.Parse(PlayerPrefs.GetString("firstappstart"));                                
                return (k.AddDays(1).CompareTo(System.DateTime.Today) < 0);
            }
            else
            {
                PlayerPrefs.SetString("firstappstart", System.DateTime.Today.ToString());
                return false;
            }
                
        }
    }

	void Start ()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void OnLevelWasLoaded(int num)
    {
        if (needShow)
        {
            ShowAd();
            needShow = false;
        }
         if ((num == 2) && (threeDaysCheck))
        {
            needShow = true;
        }
    }
	
	public void ShowAd()
    {

        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

}
