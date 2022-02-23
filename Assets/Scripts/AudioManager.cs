using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

//Mini-library
using UnityUtils;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static AudioManager Instance { get; private set; }

    public Sound[] sounds;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;   
        }   
    }


    /// <summary>
    /// Play a sound
    /// </summary>
    /// <param name="name">the name of the sound to play</param>
    public void Play(string name, bool checkPlaying=false)
    {   
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return;
        }
        if (checkPlaying && s.source.isPlaying) return;
        s.source.Play();
    }

    /// <summary>
    /// Pause a sound
    /// </summary>
    /// <param name="name">the name of the sound to pause</param>
    public void Pause(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return;
        }
        if (!s.source.isPlaying)
        {
            Debug.LogWarning($"Sound with name {name} is not playing!");
            return;
        }
        s.source.Pause();
    }

    /// <summary>
    /// Resume a paused sound
    /// </summary>
    /// <param name="name">the name of the sound to play</param>
    public void Resume(string name) 
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return;
        }

        s.source.UnPause();
    }

    public AudioClip GetClip(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return null;
        }

        return s.clip;
    }

    public AudioSource GetSource(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return null;
        }

        return s.source;
    }
}
