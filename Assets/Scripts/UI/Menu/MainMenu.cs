using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    GameObject menuObject;
    [SerializeField]
    Toggle musicToggle;
    [SerializeField]
    Toggle soundToggle;

    void Start()
    {
        musicToggle.isOn = !MusicPlayer.Enabled;
        soundToggle.isOn = !SoundPlayer.Enabled;        
    }

    public void On_PlayButton_Click()
    {
        Application.LoadLevel(2);
        SoundPlayer.PlaySound("paper");
    }   

    public void On_SoundTrigger_Click(bool state)
    {
        SoundPlayer.Enabled = !state;
    }

    public void On_MusicTrigger_Click(bool state)
    {      
        MusicPlayer.Enabled = !state;
    }

    public void On_ShowMenu_Click()
    {
        menuObject.SetActive(true);
        SoundPlayer.PlaySound("paper");
    }

    public void On_HideMenu_Click()
    {
        menuObject.SetActive(false);
        SoundPlayer.PlaySound("paper");
    }

    public void On_ExitButton_Click()
    {
        SoundPlayer.PlaySound("paper");
        Application.Quit();
    }

}
