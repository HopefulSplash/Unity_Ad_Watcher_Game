using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Sprite[] backgroundImages;
    public Player player;
    public Image backgroundImage;
    public int backgroundIndexSelected;
   
    public void SetupBackGround()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        backgroundIndexSelected = player.backgroundNumber;

        backgroundImage.sprite = backgroundImages[backgroundIndexSelected];

    }
    public void ChangeBackground(int indexBackground)
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        backgroundImage.sprite = backgroundImages[indexBackground];
        backgroundIndexSelected = indexBackground;
        player.backgroundNumber = indexBackground;
        player.SavePlayer();

    }

    public void AddBackgroundIndex()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        backgroundIndexSelected++;
        if (backgroundIndexSelected > backgroundImages.Length-1)
        {
            backgroundIndexSelected = backgroundIndexSelected - 1;
        }
        ChangeBackground(backgroundIndexSelected);
        player.backgroundNumber = backgroundIndexSelected;
        player.SavePlayer();
    }

    public void MinusBackgroundIndex()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        backgroundIndexSelected--;
        if (backgroundIndexSelected < 0)
        {
            backgroundIndexSelected = backgroundIndexSelected + 1;
        }
        ChangeBackground(backgroundIndexSelected);
        player.backgroundNumber = backgroundIndexSelected;
        player.SavePlayer();
    }
}
