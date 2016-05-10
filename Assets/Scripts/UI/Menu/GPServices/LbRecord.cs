using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LbRecord : MonoBehaviour {

    IUserProfile profile;
    [SerializeField]
    Image img;
    [SerializeField]
    Text nameLabel;
    [SerializeField]
    Text rankLabel;
    [SerializeField]
    Text scoreLabel;
	
	void Init (IUserProfile user, IScore scores)
    {
        profile = user;
        img.sprite = Sprite.Create(profile.image, new Rect(0, 0, profile.image.width, profile.image.height), new Vector2(0.5f, 0.5f));
        nameLabel.text = profile.userName;
        scoreLabel.text = scores.ToString();
        rankLabel.text = scores.rank.ToString();
    }

    static GameObject pref = null;
    static GameObject emptyPref = null;

    public static void Create(Transform leaderboardTform, IUserProfile user, IScore scores)
    {
        if (pref == null)
        {
            pref = Resources.Load<GameObject>("Prefabs/UI/RecordPanel");
        }

        GameObject lb = Instantiate(pref);
        lb.transform.parent = leaderboardTform;
        LbRecord lbComp = lb.GetComponent<LbRecord>();
        lbComp.Init(user, scores);        
    }

    public static void CreateEmpty(Transform leaderboardTform)
    {
        if (emptyPref == null)
        {
            emptyPref = Resources.Load<GameObject>("Prefabs/UI/EmptyRecordPanel");
        }
        GameObject lb = Instantiate(emptyPref);
        lb.transform.parent = leaderboardTform;
    }

}
