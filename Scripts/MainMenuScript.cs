using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript control;
    public Player player;
    public Text playerTokens;
    public AudioSource backgroundMusic;
    public SoundManager keepAudio;
    public GameObject MMShader;
    public BackgroundManager backgroundManager;
    public RemoteManager remoteManager;
    public UnityAdManager adManager;
    public TVManager tVManager;
    public GameObject[] buttons;
    public Settings settings;
    public Store store;
    private void Awake()

    {     
        control = this;
        GameObject temp = GameObject.FindGameObjectWithTag("MMShade");
        MMShader = temp;
        temp.SetActive(false);
        SaveSystem.checkIfSystemFile();
        player.LoadPlayer();
        backgroundManager.SetupBackGround();
        remoteManager.SetupRemote();
        ChangePlayerTokens(player.playerCoins);
        tVManager.ChangeTV(player.TVNumber);
        tVManager.ChangeTVScreen(6);
         backgroundMusic.volume = player.backgroundMusicLevelSettings;
        keepAudio.PlayBGMusic();
        StartCoroutine(WaitAD());
        settings.UpdateSettingsMenu();
        keepAudio.UpdateSFXSound(player.SFXMusicLevelSettings, "Load");
        settings.tempMusicVol = player.backgroundMusicLevelSettings;
        settings.tempSFXvol = player.SFXMusicLevelSettings;

        store.UpdateStoreMenu();
      
    }
    public void updateUI()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();

        ChangePlayerTokens(player.playerCoins);
        tVManager.ChangeTV(player.TVNumber);
        remoteManager.ChangeRemote(player.remoteNumber);
        tVManager.ChangeTVScreen(6);
        backgroundManager.ChangeBackground(player.backgroundNumber);

        StartCoroutine(WaitAD());
    }
    IEnumerator WaitAD()
    {
        buttons[2].GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(1f);

        buttons[2].GetComponent<Button>().interactable = true;
    }
        public void OnAndOffButton(GameObject[] gameObject)
    {
        for (int i = 0; i <= gameObject.Length - 1; i++)
        {
            Button button = gameObject[i].GetComponent<Button>();
            button.interactable = !button.interactable;
        }
    }

    public void RewardPlayer()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        pressed = false;
        if (adManager.status == "Finished")
        {
            player.playerCoins = player.playerCoins + 1000;
            player.SavePlayer();
            ChangePlayerTokens(player.playerCoins);
        }
        else if (adManager.status == "Skipped")
        {
            player.playerCoins = player.playerCoins + 200;
            player.SavePlayer();
            ChangePlayerTokens(player.playerCoins);
        }
        else if (adManager.status == "Failed")
        {
        }
        else
        {
        }
        tVManager.ChangeTVScreen(6);
        OnAndOffButton(buttons);
        keepAudio.PlayBGMusic();
    }
    public bool pressed = false;
    public void PlayButtonPressed()
    {
        if (!pressed)
        {
            OnAndOffButton(buttons);
            StartCoroutine(PlayTVStatic());
        }
    }
    IEnumerator PlayTVStatic()
    {
        tVManager.ChangeTVScreen(0);
        pressed = true;
        keepAudio.StopBGMusic();
        keepAudio.SliderMoveSFX();

        yield return new WaitForSeconds(0.6f);
        while (keepAudio.SFX[1].isPlaying)
        {
            tVManager.ChangeTVScreen(Random.Range(1, 4));
            yield return new WaitForSeconds(0.04f);
        }
        adManager.PlayRewardedAD(RewardPlayer);
    }

    public void StorePressed()
    {
        OnAndOffButton(buttons);
        store.StoreMenuPressed();
    }

        public void StopButtonFocus()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ChangePlayerTokens(int value)
    {
        GameObject temp1 = GameObject.FindGameObjectWithTag("PlayerCoinsMM");
        playerTokens = temp1.GetComponent<Text>();
        playerTokens.text = value.ToString();
    }
    public void ShaderON()
    {
        MMShader.SetActive(true);
    }
    public void ShaderOff()
    {
        MMShader.SetActive(false);
    }
}
