using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  // Singleton pattern
    public AudioClip[] audioClips;

    [Header("Audio Sources")]
    public AudioSource sfxSource;     // AudioSource for sound effects
    public AudioSource bgmSource;     // AudioSource for background music

    [Header("Global Settings")]
    [Range(0f, 1f)] public float sfxVolume = 1f;  // Volume for SFX (0 to 1)
    [Range(0f, 1f)] public float bgmVolume = 1f;  // Volume for BGM (0 to 1)

    private Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();  // Store SFX clips by name
    private Dictionary<string, AudioClip> bgmClips = new Dictionary<string, AudioClip>();  // Store BGM clips by name

    private void Awake()
    {
        // Singleton pattern to ensure only one AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep the audio manager when changing scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Set initial volumes
        sfxSource.volume = sfxVolume;
        bgmSource.volume = bgmVolume;
    }

    // Add SFX and BGM clips by name (so you can load them dynamically)
    public void AddSFXClip(string clipName, AudioClip clip)
    {
        if (!sfxClips.ContainsKey(clipName))
        {
            sfxClips.Add(clipName, clip);
        }
    }

    public void AddBGMClip(string clipName, AudioClip clip)
    {
        if (!bgmClips.ContainsKey(clipName))
        {
            bgmClips.Add(clipName, clip);
        }
    }

    // Play SFX by name, with options for volume, pitch, and looping
    public void PlaySFX(string clipName, float volume = 1f, float pitch = 1f, bool loop = false)
    {
        if (sfxClips.ContainsKey(clipName))
        {
            sfxSource.clip = sfxClips[clipName];
            sfxSource.volume = volume * sfxVolume;  // Adjust volume based on global and individual settings
            sfxSource.pitch = pitch;  // Adjust pitch
            sfxSource.loop = loop;    // Set looping
            sfxSource.Play();         // Play the clip
        }
        else
        {
            Debug.LogWarning("SFX Clip not found: " + clipName);
        }
    }

    // Play BGM by name, with options for volume and looping
    public void PlayBGM(string clipName, float volume = 1f, bool loop = true)
    {
        if (bgmClips.ContainsKey(clipName))
        {
            bgmSource.clip = bgmClips[clipName];
            bgmSource.volume = volume * bgmVolume;  // Adjust volume based on global and individual settings
            bgmSource.loop = loop;                  // Set looping
            bgmSource.Play();                       // Play the clip
        }
        else
        {
            Debug.LogWarning("BGM Clip not found: " + clipName);
        }
    }

    // Stop the currently playing SFX
    public void StopSFX()
    {
        sfxSource.Stop();
    }

    // Stop the currently playing BGM
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // Set global SFX volume
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        sfxSource.volume = sfxVolume;
    }

    // Set global BGM volume
    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume;
    }

    // Set global SFX pitch
    public void SetSFXPitch(float pitch)
    {
        sfxSource.pitch = Mathf.Clamp(pitch, -3f, 3f);  // Ensure pitch is within a reasonable range
    }

    // Set global BGM pitch
    public void SetBGMPitch(float pitch)
    {
        bgmSource.pitch = Mathf.Clamp(pitch, -3f, 3f);  // Ensure pitch is within a reasonable range
    }
}
