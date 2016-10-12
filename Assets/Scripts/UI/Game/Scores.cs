using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using Assets.Crypto;

public class Scores :MonoBehaviour
{

    static int scoreValue
    {
        get
        {
            int result;
            if ((PlayerPrefs.HasKey("aaaaa")) && (int.TryParse(MemoryCrypto.Decode(PlayerPrefs.GetString("aaaaa")), out result)))
                return result;
            else
                return 0;
        }
        set
        {
            PlayerPrefs.SetString("aaaaa", MemoryCrypto.Encode(value.ToString()));
        }
    }

    public static void PushScores(int value)
    {
        if (scoreValue < value)
        {
            scoreValue = value;
        }
        if (!GPServices.isAuthenticated)
            GPServices.Instance.Authenticate(() => { PushSocial(value); });
        else
            PushSocial(value);
    }

    static void PushSocial(int value)
    {
        Social.ReportScore(value, GPGclass.leaderboard_scores, (bool success) => {
            //Log.Write("score push success is " + success.ToString());
        });
    }


    [SerializeField]
    Text recordLabel;

    void Awake()
    {
        recordLabel = GetComponent<Text>();
        recordLabel.text = "Your top scores: " + scoreValue.ToString();
    }
    

}
