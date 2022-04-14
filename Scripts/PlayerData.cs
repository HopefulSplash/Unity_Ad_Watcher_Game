using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    private float backgroundMusicLevel;
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
    public PlayerData (Player player)
    {
        backgroundMusicLevel = player.backgroundMusicLevel;
        backgroundMusicLevelSettings = player.backgroundMusicLevelSettings;
        SFXMusicLevel = player.SFXMusicLevel;
        SFXMusicLevelSettings = player.SFXMusicLevelSettings;

        playerCoins = player.playerCoins;
        unlockedTVS = player.unlockedTVS;
        unlockedRemotes = player.unlockedRemotes;
        unlockedBackgrounds = player.unlockedBackgrounds;
        backgroundNumber = player.backgroundNumber;
        remoteNumber = player.remoteNumber;
        TVNumber = player.TVNumber;
    }
}
