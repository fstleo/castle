using UnityEngine;
using System.Collections.Generic;

public class SoundPlayer : MonoBehaviour {

    static SoundPlayer Instance;
    Dictionary<string, AudioClip> sounds;
    AudioSource [] sources;
    int currentChannel = 0;

    public static bool Enabled;
	
	void Awake () {
    
        DontDestroyOnLoad(this);
        Instance = this;
        sounds = new Dictionary<string, AudioClip>();
        sources = GetComponentsInChildren<AudioSource>();
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds");
        foreach(AudioClip clip in clips)
        {
            sounds.Add(clip.name, clip);
        }
        Enabled = true;
    }

    void OnLevelWasLoaded(int lvl)
    {
        //Debug.Log(Enabled);
    }

    void Play(string name)
    {
        if (Enabled)
        {
            sources[currentChannel].clip = sounds[GetRandomSound(name)];
            sources[currentChannel].pitch = 1 + Random.Range(-0.3f, 0.3f);
            sources[currentChannel].Play();
            currentChannel = (currentChannel + 1) % sources.Length;
        }
            
    }

    public static void PlaySound(string name)
    {
        Instance.Play(name);
    }

    string GetRandomSound(string name)
    {
        List<string> clips = new List<string>();
        foreach (KeyValuePair<string, AudioClip> pair in sounds)
        {
            if (pair.Key.Contains(name))
            {
                clips.Add(pair.Key);
            }
        }
        return clips[(int)(UnityEngine.Random.value * clips.Count)];
    }

}
