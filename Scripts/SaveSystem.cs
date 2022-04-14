using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/2.dvo";
        
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void checkIfSystemFile()
    {
        string path = Application.persistentDataPath + "/2.dvo";

        if (File.Exists(path))
        {
        }
        else
        {
            Player newPlayer = new Player();
            int[] newPlayerTemplate = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            newPlayer.SFXMusicLevel = 1;
            newPlayer.SFXMusicLevel = 1;
            newPlayer.backgroundMusicLevel = 0.3f;
            newPlayer.backgroundMusicLevelSettings = 0.3f;

            newPlayer.playerCoins = 0;
            newPlayer.unlockedTVS = new bool[] {true, false,  false,  false , false , false, false , false,  false, false,  false,  false };
            newPlayer.unlockedRemotes = new bool[] { true, false, false, false, false, false, false, false, false, false, false, false };
            newPlayer.unlockedBackgrounds = new bool[] { true, false, false, false, false, false, false, false, false, false, false, false };
            newPlayer.backgroundNumber = 0;
            newPlayer.remoteNumber = 0;
            newPlayer.TVNumber = 0;

            SaveSystem.SavePlayer(newPlayer);
        }
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/2.dvo";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
