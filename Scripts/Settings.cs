using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Player player;
    public GameObject settingsMenu;
    private Button settingsButton;
    public MainMenuScript mainMenu;
    public GameObject musicMute;
    public GameObject sfxMute;
    public GameObject sfx;
    public GameObject music;
    public SoundManager soundManager;
    public GameObject UI;
    

    private void Awake()
    {
     
    }
    void Start()
    {
    }

    void Update()
    {
        
    }
    public float restMVol = 0;
    public float tempMusicVol;
    public float tempSFXvol;
    public void LoadSettings()
    {
        
        tempMusicVol = soundManager.backgroundMusic.volume;
        tempSFXvol = soundManager.SFX[0].volume;
        restMVol = tempMusicVol;
        UpdateUI("SFX", tempSFXvol);
        UpdateUI("Music", tempMusicVol);

    }
    public void UpdateUI(string option, float vol)
    {

        if (option == "Music")
        {
            music = GameObject.FindGameObjectWithTag("MusicVolSlider");
            music.GetComponent<Slider>().value = vol*100;

            if (vol > 0)
            {
                musicMute = GameObject.FindGameObjectWithTag("MusicSlider");
                musicMute.GetComponent<Slider>().value = 1;

            }
            else if (vol <= 0)
            {
                musicMute = GameObject.FindGameObjectWithTag("MusicSlider");
                musicMute.GetComponent<Slider>().value = 0;
            }
        }
        else if (option == "SFX")
        {
            sfx = GameObject.FindGameObjectWithTag("SFXVolSlider");
            sfx.GetComponent<Slider>().value = vol * 100;

            if (vol > 0)
            {

                sfxMute = GameObject.FindGameObjectWithTag("MusicSlider");
                sfxMute.GetComponent<Slider>().value = 1;
            }
            else if (vol <= 0)
            {

                sfxMute = GameObject.FindGameObjectWithTag("MusicSlider");
                sfxMute.GetComponent<Slider>().value = 0;
            }
        }
    }

    public void SettingMenuPressed()
    {
        UI.SetActive(false);
        mainMenu.ShaderON();
        mainMenu.OnAndOffButton(mainMenu.buttons);

        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();

        settingsMenu.gameObject.SetActive(true);
        LoadSettings();



    }

    public void UpdateSettingsMenu()
    {
        settingsMenu.gameObject.SetActive(false);
    }
    public void CloseSettingsMenu(string option)
    {
        if (option == "Cross")
        {
            CloseButtonPressed();
            mainMenu.OnAndOffButton(mainMenu.buttons);
            settingsMenu.gameObject.SetActive(false);
            UI.SetActive(true);
        }
        else if (option == "Okay")
        {

            OkayButtonPressed();
            mainMenu.OnAndOffButton(mainMenu.buttons);
            settingsMenu.gameObject.SetActive(false);
            UI.SetActive(true);

        }
        mainMenu.ShaderOff();
    }
    public void MuteToggleFlipped(string option)
    {
        musicMute = GameObject.FindGameObjectWithTag("MusicSlider");
        float music_Temp = musicMute.GetComponent<Slider>().value;

        sfxMute = GameObject.FindGameObjectWithTag("SFXSlider");
        float music_Sfx = sfxMute.GetComponent<Slider>().value;
        if (option == "Music")
        {
            if (music_Temp == 0)
            {
                music = GameObject.FindGameObjectWithTag("MusicVolSlider");
                music.GetComponent<Slider>().value = 0;
            }
            else if (music_Temp == 1)
            {
                music = GameObject.FindGameObjectWithTag("MusicVolSlider");
                    
                if (music.GetComponent<Slider>().value == 0)
                {
                    music.GetComponent<Slider>().value = 10;
                }
                    
                
            }
        }
        else if (option == "SFX")
        {
            if (music_Sfx == 0)
            {
                sfx = GameObject.FindGameObjectWithTag("SFXVolSlider");
                sfx.GetComponent<Slider>().value = 0;
            }
            else if (music_Sfx == 1)
            {
                sfx = GameObject.FindGameObjectWithTag("SFXVolSlider");
                if (sfx.GetComponent<Slider>().value == 0)
                {
                    sfx.GetComponent<Slider>().value = 10;
                }
            }
        }
    }

    public void SetMusicVolume(string option, float vol)
    {
        if (option == "SFX")
        {
            soundManager.UpdateSFXSound(vol, "Update");
        }
        else if (option == "Music")
        {
            soundManager.UpdateSound(vol);
        }
    }

    public void VolumeToggleMoved(string option)
    {
        music = GameObject.FindGameObjectWithTag("MusicVolSlider");
        float music_Temp = music.GetComponent<Slider>().value;

        sfx = GameObject.FindGameObjectWithTag("SFXVolSlider");
        float music_Sfx = sfx.GetComponent<Slider>().value;
        if (option == "Music")
        {
            musicMute = GameObject.FindGameObjectWithTag("MusicSlider");
            if (music_Temp == 0)
            {

                musicMute.GetComponent<Slider>().value = 0;
            }
            else
            {
                musicMute.GetComponent<Slider>().value = 1;
            }
            SetMusicVolume(option, music_Temp);
        }
        else if (option == "SFX")
        {
            sfxMute = GameObject.FindGameObjectWithTag("SFXSlider");
            if (music_Sfx == 0)
            {

                sfxMute.GetComponent<Slider>().value = 0;
            }
            else
            {
                sfxMute.GetComponent<Slider>().value = 1;
            }
            SetMusicVolume(option, music_Sfx);
        }
    }
    public void OkayButtonPressed()
    {
        music = GameObject.FindGameObjectWithTag("MusicVolSlider");
        player.backgroundMusicLevelSettings = music.GetComponent<Slider>().value/100;

        sfx = GameObject.FindGameObjectWithTag("SFXVolSlider");
        player.SFXMusicLevelSettings = sfx.GetComponent<Slider>().value/100;

        SaveSystem.SavePlayer(player);
    }

    public void CloseButtonPressed()
    {   
        if (soundManager.muted != true)
        {
            soundManager.UpdateSound(player.backgroundMusicLevelSettings * 100);
            soundManager.UpdateSFXSound(player.SFXMusicLevelSettings * 100, "Update");
        }
        else
        {
            music = GameObject.FindGameObjectWithTag("MusicVolSlider");
            music.GetComponent<Slider>().value = 0;

            sfx = GameObject.FindGameObjectWithTag("SFXVolSlider");
            sfx.GetComponent<Slider>().value = 0;

        }

    }
}
