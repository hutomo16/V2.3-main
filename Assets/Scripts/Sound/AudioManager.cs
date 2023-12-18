using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public const string MusicMuteKey = "MusicMute";
    public const string SFXMuteKey = "SFXMute";
    public const string MusicVolumeKey = "MusicVolume";
    public const string SFXVolumeKey = "SFXVolume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.mute = PlayerPrefs.GetInt(MusicMuteKey, 0) == 1;
        sfxSource.mute = PlayerPrefs.GetInt(SFXMuteKey, 0) == 1;
        musicSource.volume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        sfxSource.volume = PlayerPrefs.GetFloat(SFXVolumeKey, 1f);
        if (!musicSource.isPlaying)
        {
            PlayMusic("Theme");
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogError("Music Sound not Found: " + name);
            return;
        }

        if (musicSource != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        else
        {
            Debug.LogError("Music AudioSource is null!");
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogError("SFX Sound not Found: " + name);
            return;
        }

        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
        else
        {
            Debug.LogError("SFX AudioSource is null!");
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        SaveSoundSettings(); // Segera simpan setiap kali mute berubah
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        SaveSoundSettings(); // Segera simpan setiap kali mute berubah
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetInt(MusicMuteKey, musicSource.mute ? 1 : 0);
        PlayerPrefs.SetInt(SFXMuteKey, sfxSource.mute ? 1 : 0);
        PlayerPrefs.SetFloat(MusicVolumeKey, musicSource.volume);
        PlayerPrefs.SetFloat(SFXVolumeKey, sfxSource.volume);
        PlayerPrefs.Save();
    }
}






/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public  AudioSource musicSource,sfxSource;


    private void Awake()
    {
        if(instance== null)
        {
            instance= this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s != null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            musicSource.clip=s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s != null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
*/