using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Settings settings;
    public AudioSource backgroundMusic;
    public AudioSource[] SFX;
    public Player player;
    void Awake()
    {      
    }
    public bool muted = false;
    public void PlayBGMusic()
    {
        backgroundMusic.Play();
    }
    public void StopBGMusic()
    {
        backgroundMusic.Pause();
    }
    public void MuteBackgroundMusic(int option)
    {
        if (backgroundMusic.volume != 0)
        {
            muted = true;
            backgroundMusic.volume = 0;
            player.backgroundMusicLevel = 0;
            UpdateSFXSound(0, "Update");
            player.SFXMusicLevel = 0;
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            player = temp.GetComponent<Player>();
            SaveSystem.SavePlayer(player);

        }
        else if (backgroundMusic.volume == 0 && player.backgroundMusicLevelSettings != 0)
        {
            muted = false;
            backgroundMusic.volume = player.backgroundMusicLevelSettings;
            player.backgroundMusicLevel = backgroundMusic.volume;
            UpdateSFXSound(player.SFXMusicLevelSettings, "Load");
            player.SFXMusicLevel = player.SFXMusicLevelSettings;
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            player = temp.GetComponent<Player>();
            SaveSystem.SavePlayer(player);
        }
    }
    public void UpdateSound(float vol)
    {
        float temp = vol / 100;
        backgroundMusic.volume = temp;
    }
       public void UpdateSFXSound(float vol, string option)
    {
        if (option == "Load")
        {
            float temp = vol;
            for (int i = 0; i < SFX.Length; i++)
            {
                SFX[i].volume = temp;
            }
        }
        else if (option == "Update")
        {
            float temp = vol / 100;
            for (int i = 0; i < SFX.Length; i++)
            {
                SFX[i].volume = temp;
            }
        }
    }
    public void ButtonClickSFX()
    {
        SFX[0].Play();

        StartCoroutine(PlaySound(SFX[0]));
   
    }
    public void SliderMoveSFX()
    {
        SFX[1].Play();

    }
    IEnumerator PlaySound(AudioSource source)
    {
        while (source.isPlaying)
        {
            yield return null;
        }
    }
    public void PlayGoSFX()
    {
        SFX[2].Play();
    }
    public void PlaySwordSFX()
    {
        SFX[3].Play();
    }
    public void PlayPotionSFX()
    {
        SFX[4].Play();
    }

    public void PlayGameBackgroundMusic(float volume)
    {
       backgroundMusic.volume = volume;
       backgroundMusic.Play();
    }
    public void StopGameBackgroundMusic()
    {
        backgroundMusic.Pause();
    }

    public void PlayButtonErrorSFX()
    {
        SFX[5].Play();
    }
}