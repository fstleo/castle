using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : State {

    [SerializeField]
    Toggle musicToggle;
    [SerializeField]
    Toggle soundToggle;
    [SerializeField]
    Toggle flipToggle;

    void Start()
    {
        musicToggle.isOn = !MusicPlayer.Enabled;
        soundToggle.isOn = !SoundPlayer.Enabled;
        flipToggle.isOn = GameCamera.NeedFlip;
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

    public void On_FlipTrigger_Click(bool state)
    {
        GameCamera.NeedFlip = state;
    }

    public void On_ExitButton_Click()
    {
        SoundPlayer.PlaySound("paper");
        Application.Quit();
    }

}
