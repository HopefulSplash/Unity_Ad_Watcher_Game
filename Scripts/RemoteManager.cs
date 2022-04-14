using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoteManager : MonoBehaviour
{
    public Sprite[] remoteImages;
    public Player player;
    public Image remoteImage;
    public int remoteIndexSelected;

    public void SetupRemote()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        remoteIndexSelected = player.remoteNumber;
        remoteImage.sprite = remoteImages[remoteIndexSelected];

    }
    public void ChangeRemote(int indexBackground)
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        remoteImage.sprite = remoteImages[indexBackground];
        remoteIndexSelected = indexBackground;
        player.remoteNumber = indexBackground;
        player.SavePlayer();

    }

    public void AddRemoteIndex()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        remoteIndexSelected++;
        if (remoteIndexSelected > remoteImages.Length - 1)
        {
            remoteIndexSelected = remoteIndexSelected - 1;
        }
        ChangeRemote(remoteIndexSelected);
        player.remoteNumber = remoteIndexSelected;
        player.SavePlayer();
    }

    public void MinusRemoteIndex()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        remoteIndexSelected--;
        if (remoteIndexSelected < 0)
        {
            remoteIndexSelected = remoteIndexSelected + 1;
        }
        ChangeRemote(remoteIndexSelected);
        player.remoteNumber = remoteIndexSelected;
        player.SavePlayer();
    }
}

