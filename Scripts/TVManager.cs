using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVManager : MonoBehaviour
{
    public Sprite[] TVImages;
    public Sprite[] TVScreenImages;
    public Player player;
    public Image TVImage;
    public Image TVScreenImage;
    public int TVIndexSelected;
    public int TVScreenIndexSelected;
    public void SetupTV()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        TVIndexSelected = player.TVNumber;
        TVImage.sprite = TVImages[TVIndexSelected];

    }
    public void ChangeTV(int indexBackground)
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        TVImage.sprite = TVImages[indexBackground];
        TVIndexSelected = indexBackground;
        player.TVNumber = indexBackground;
        player.SavePlayer();

    }
    public void ChangeTVScreen(int indexBackground)
    {
        TVScreenImage.sprite = TVScreenImages[indexBackground];
        TVScreenIndexSelected = indexBackground;
    }

    public void AddTVIndex()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        TVIndexSelected++;
        if (TVIndexSelected > TVImages.Length - 1)
        {
            TVIndexSelected = TVIndexSelected - 1;
        }
        ChangeTV(TVIndexSelected);
        player.TVNumber = TVIndexSelected;
        player.SavePlayer();
    }

    public void MinusTVIndex()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        TVIndexSelected--;
        if (TVIndexSelected < 0)
        {
            TVIndexSelected = TVIndexSelected + 1;
        }
        ChangeTV(TVIndexSelected);
        player.TVNumber = TVIndexSelected;
        player.SavePlayer();
    }
}
