using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
   

    private void Start()
    {
        if (musicSlider != null && sfxSlider != null)
        {
            // Mendapatkan status mute dan mengatur UI sesuai dengan status tersebut
           

            float savedMusicVolume = PlayerPrefs.GetFloat(AudioManager.MusicVolumeKey, 1f);
            float savedSFXVolume = PlayerPrefs.GetFloat(AudioManager.SFXVolumeKey, 1f);

            musicSlider.value = savedMusicVolume;
            sfxSlider.value = savedSFXVolume;

            AudioManager.instance.MusicVolume(savedMusicVolume);
            AudioManager.instance.SFXVolume(savedSFXVolume);
        }
        else
        {
            Debug.LogError("One or more UI elements is not assigned in UIController.");
        }
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
     
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
       
    }

    public void MusicVolume()
    {
        float musicVolume = musicSlider.value;
        AudioManager.instance.MusicVolume(musicVolume);
        AudioManager.instance.SaveSoundSettings();
    }

    public void SFXVolume()
    {
        float sfxVolume = sfxSlider.value;
        AudioManager.instance.SFXVolume(sfxVolume);
        AudioManager.instance.SaveSoundSettings();
    }

    
}















/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }
    
    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(_sfxSlider.value);
    }

}
*/