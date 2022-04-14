using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float backgroundMusicLevel;
    public float backgroundMusicLevelSettings;
    public float SFXMusicLevel;
    public float SFXMusicLevelSettings;
    public int playerCoins;
    public bool[] unlockedTVS;
    public bool[] unlockedRemotes;
    public bool[] unlockedBackgrounds;
    public int backgroundNumber;
    public int remoteNumber;
    public int TVNumber;
    public void SavePlayer()
    {
       
        SaveSystem.SavePlayer(this);
      
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        backgroundMusicLevel = data.backgroundMusicLevelSettings;
        backgroundMusicLevelSettings = data.backgroundMusicLevelSettings;
        SFXMusicLevel = data.SFXMusicLevel;
        SFXMusicLevelSettings = data.SFXMusicLevelSettings;

        playerCoins = data.playerCoins;
        unlockedTVS = data.unlockedTVS;
        unlockedRemotes = data.unlockedRemotes;
        unlockedBackgrounds = data.unlockedBackgrounds;
        backgroundNumber = data.backgroundNumber;
        remoteNumber = data.remoteNumber;
        TVNumber = data.TVNumber;
    }


}
