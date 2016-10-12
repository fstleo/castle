using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

    public static GameMenu Instance
    {
        get;
        private set;
    }

    public Text finishScoresLabel;

    Animator anim;


    [SerializeField]
    Toggle musicToggle;
    [SerializeField]
    Toggle soundToggle;

    void Awake ()
    {
        Time.timeScale = 1;
        Instance = this;
        anim = GetComponent<Animator>();
        Castle.Instance.GameOverEvent += GameOver;
        musicToggle.isOn = !MusicPlayer.Enabled;
        soundToggle.isOn = !SoundPlayer.Enabled;
    }

    public void GameOver()
    {
        anim.SetTrigger("GameOver");
        finishScoresLabel.text = Counter.Instance.lclscrs.ToString();        
        Time.timeScale = 0;        
    }

    public void On_ResumeButton_Click()
    {        
        anim.SetTrigger("Game");
        SoundPlayer.PlaySound("paper");
        Time.timeScale = 1;
    }

    public void On_PauseButton_Click()
    {
        anim.SetTrigger("Pause");
        SoundPlayer.PlaySound("paper");
        Time.timeScale = 0;
    }

    public void On_MenuButton_Click()
    {
        SoundPlayer.PlaySound("paper");
        Application.LoadLevel(1);
    }

    public void On_RestartButton_Click()
    {
        SoundPlayer.PlaySound("paper");
        Application.LoadLevel(Application.loadedLevel);
    }

    public void On_SoundToggle_Click(bool state)
    {
        SoundPlayer.Enabled = !state;
    }

    public void On_MusicToggle_Click(bool state)
    {
        MusicPlayer.Enabled = !state;
    }

    void OnDestroy()
    {
        Castle.Instance.GameOverEvent -= GameOver;
    }
}
