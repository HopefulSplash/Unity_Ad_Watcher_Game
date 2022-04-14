using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public UnityAdManager adManager;
    public Text coinText;
    public MainMenuScript mainMenuScript;
    public Player player;
    public GameObject moneyButton;
    private GameObject[] gameObjectArray;
    private List<GameObject> gameObjectButtons;
    private GameObject[] currencyGameObj;
    private GameObject[] itemGameObj;
    private GameObject[] priceGameObj;
    public GameObject storeMenu;
    public GameObject StoreMenuConfirm;
    public GameObject SMShader;
    public GameObject UI;
    public Button leftButton;
    public Button rightButton;

    public int pageNo;

    public Sprite coinCurrency;
    public Sprite[] coinItemList;
    public int[] coinPriceList;

    public Sprite moneyCurrency;
    public Sprite[] moneyItemList;
    public int[] moneyPriceList;

    public Sprite backgroundCurrency;
    public Sprite[] backgroundItemList;
    public int[] backgroundPriceList;

    public Button cButton;
    public Button gButton;
    public Button bButton;
    public Sprite selectButtons;
    public Sprite delectedButtons;
    public void SetButtonInactive(Button button)
    {

        var buttonTransform = button.transform;
        Image img = buttonTransform.GetChild(0).GetComponent<Image>();

        Image temp = button.GetComponent<Image>();

        img.color = new Color32(255, 255, 255, 150);
    }

    public void SetButtonActive(Button button)
    {

        var buttonTransform = button.transform;
        Image img = buttonTransform.GetChild(0).GetComponent<Image>();

        Image temp = button.GetComponent<Image>();

        img.color = new Color32(255, 255, 255, 255);
    }
    public void LoadStoreSettings()
    {

        StoreMenuConfirm.SetActive(false);
        rightButton.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(false);

        GameObject temp = GameObject.FindGameObjectWithTag("CoinStore");
        cButton = temp.GetComponent<Button>();
        GameObject temp1 = GameObject.FindGameObjectWithTag("GemStore");
        gButton = temp1.GetComponent<Button>();
        GameObject temp5 = GameObject.FindGameObjectWithTag("BackgroundStore");
        bButton = temp5.GetComponent<Button>();
        SetActiveStore(1);
        PageSetup(coinCurrency);

    }

    public void itemButtonPressed(int itemPressed)
    {
        SMShader.SetActive(true);
        if (b1.gameObject.activeInHierarchy)
        {
            GameObject[] tempArray = GameObject.FindGameObjectsWithTag("BuyButton");
            gameObjectButtons = tempArray.Cast<GameObject>().ToList();
        }
        if (b2.gameObject.activeInHierarchy)
        {
            GameObject temp2 = GameObject.FindGameObjectWithTag("BuyButton2");
            gameObjectButtons.Add(temp2);
        }
        if (b3.gameObject.activeInHierarchy)
        {
            GameObject temp4 = GameObject.FindGameObjectWithTag("BuyButton3");
            gameObjectButtons.Add(temp4);
        }
        GameObject temp5 = GameObject.FindGameObjectWithTag("BackgroundStore");
        gameObjectButtons.Add(temp5);
        GameObject temp = GameObject.FindGameObjectWithTag("CoinStore");
        gameObjectButtons.Add(temp);
        GameObject temp1 = GameObject.FindGameObjectWithTag("GemStore");
        gameObjectButtons.Add(temp1);

        OnAndOffButton(gameObjectButtons.ToArray());
        StoreMenuConfirm.SetActive(true);
        GetItemDetails(itemPressed);
        CheckCredits();
    }
    public bool hasCredits;
    public void AcceptButtonPressed()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        purchase = false;

        if (hasCredits)
        {
            if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinTV")
            {
                if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[0].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[0];
                    player.unlockedTVS[0] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[1].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[1];
                    player.unlockedTVS[1] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[2].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[2];
                    player.unlockedTVS[2] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[3].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[3];
                    player.unlockedTVS[3] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[4].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[4];
                    player.unlockedTVS[4] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[5].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[5];
                    player.unlockedTVS[5] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[6].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[6];
                    player.unlockedTVS[6] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[7].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[7];
                    player.unlockedTVS[7] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[8].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[8];
                    player.unlockedTVS[8] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == coinItemList[9].name)
                {
                    player.playerCoins = player.playerCoins - coinPriceList[9];
                    player.unlockedTVS[9] = true;
                }
            }
            else if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinRemote")
            {
                if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[0].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[0];
                    player.unlockedRemotes[0] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[1].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[1];
                    player.unlockedRemotes[1] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[2].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[2];
                    player.unlockedRemotes[2] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[3].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[3];
                    player.unlockedRemotes[3] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[4].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[4];
                    player.unlockedRemotes[4] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[5].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[5];
                    player.unlockedRemotes[5] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[6].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[6];
                    player.unlockedRemotes[6] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[7].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[7];
                    player.unlockedRemotes[7] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[8].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[8];
                    player.unlockedRemotes[8] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == moneyItemList[9].name)
                {
                    player.playerCoins = player.playerCoins - moneyPriceList[9];
                    player.unlockedRemotes[9] = true;
                }
            }
            else if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinBackground")
            {
                if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[0].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[0];
                    player.unlockedBackgrounds[0] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[1].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[1];
                    player.unlockedBackgrounds[1] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[2].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[2];
                    player.unlockedBackgrounds[2] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[3].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[3];
                    player.unlockedBackgrounds[3] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[4].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[4];
                    player.unlockedBackgrounds[4] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[5].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[5];
                    player.unlockedBackgrounds[5] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[6].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[6];
                    player.unlockedBackgrounds[6] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[7].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[7];
                    player.unlockedBackgrounds[7] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[8].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[8];
                    player.unlockedBackgrounds[8] = true;
                }
                else if (confirmItemObj.GetComponent<Image>().sprite.name == backgroundItemList[9].name)
                {
                    player.playerCoins = player.playerCoins - backgroundPriceList[9];
                    player.unlockedBackgrounds[9] = true;
                }
            }

        }
        else
        {
        }
        player.SavePlayer();
        BuyMenuClosed();
    }
    public bool purchase;

    public void BuyMenuClosed()
    {
        CloseConfirm();

        GameObject temp1 = GameObject.FindGameObjectWithTag("playerCoins");
        coinText = temp1.GetComponent<Text>();
        coinText.text = player.playerCoins.ToString();

        UpdateUIForPlayer();
    }
    public void UpdateUIForPlayer()
    {
        //HERE


    }
    public void CheckCredits()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();

        if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinTV")
        {
            confirmPriceObj = GameObject.FindGameObjectWithTag("ConfirmPrice");
            int tempInt = int.Parse(confirmPriceObj.GetComponent<Text>().text);

            if (player.playerCoins >= tempInt)
            {
                GameObject tempA = GameObject.FindGameObjectWithTag("AcceptButton");
                Button button = tempA.GetComponent<Button>();
                button.interactable = true;
                Image temp2 = button.GetComponent<Image>();

                temp2.color = new Color32(255, 255, 255, 255);
                hasCredits = true;
            }
            else
            {
                GameObject tempA = GameObject.FindGameObjectWithTag("AcceptButton");
                Button button = tempA.GetComponent<Button>();
                button.interactable = false;
                Image temp1 = button.GetComponent<Image>();

                temp1.color = new Color32(255, 255, 255, 150);
                hasCredits = false;
            }

        }
        else if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinRemote")
        {
            confirmPriceObj = GameObject.FindGameObjectWithTag("ConfirmPrice");
            int tempInt = int.Parse(confirmPriceObj.GetComponent<Text>().text);

            if (player.playerCoins >= tempInt)
            {
                GameObject tempA = GameObject.FindGameObjectWithTag("AcceptButton");
                Button button = tempA.GetComponent<Button>();
                button.interactable = true;
                Image temp2 = button.GetComponent<Image>();

                temp2.color = new Color32(255, 255, 255, 255);
                hasCredits = true;
            }
            else
            {
                GameObject tempA = GameObject.FindGameObjectWithTag("AcceptButton");
                Button button = tempA.GetComponent<Button>();
                button.interactable = false;
                Image temp1 = button.GetComponent<Image>();

                temp1.color = new Color32(255, 255, 255, 150);
                hasCredits = false;
            }
        }
        else if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinBackground")
        {
            confirmPriceObj = GameObject.FindGameObjectWithTag("ConfirmPrice");
            int tempInt = int.Parse(confirmPriceObj.GetComponent<Text>().text);

            if (player.playerCoins >= tempInt)
            {
                GameObject tempA = GameObject.FindGameObjectWithTag("AcceptButton");
                Button button = tempA.GetComponent<Button>();
                button.interactable = true;
                Image temp2 = button.GetComponent<Image>();

                temp2.color = new Color32(255, 255, 255, 255);
                hasCredits = true;
            }
            else
            {
                GameObject tempA = GameObject.FindGameObjectWithTag("AcceptButton");
                Button button = tempA.GetComponent<Button>();
                button.interactable = false;
                Image temp1 = button.GetComponent<Image>();

                temp1.color = new Color32(255, 255, 255, 150);
                hasCredits = false;
            }
        }
    }
    public void CloseConfirm()
    {
        if (b1.gameObject.activeInHierarchy)
        {
            GameObject[] tempArray = GameObject.FindGameObjectsWithTag("BuyButton");
            gameObjectButtons = tempArray.Cast<GameObject>().ToList();
        }
        if (b2.gameObject.activeInHierarchy)
        {
            GameObject temp2 = GameObject.FindGameObjectWithTag("BuyButton2");
            gameObjectButtons.Add(temp2);
        }
        if (b3.gameObject.activeInHierarchy)
        {
            GameObject temp4 = GameObject.FindGameObjectWithTag("BuyButton3");
            gameObjectButtons.Add(temp4);
        }
        GameObject temp = GameObject.FindGameObjectWithTag("CoinStore");
        gameObjectButtons.Add(temp);
        GameObject temp1 = GameObject.FindGameObjectWithTag("GemStore");
        gameObjectButtons.Add(temp1);
        GameObject temp5 = GameObject.FindGameObjectWithTag("BackgroundStore");
        gameObjectButtons.Add(temp5);
        OnAndOffButton(gameObjectButtons.ToArray());
        StoreMenuConfirm.SetActive(false);
        SMShader.SetActive(false);
        PageSetup(currencyType);

    }
    public GameObject confirmItemObj;
    public GameObject confirmPriceObj;
    public GameObject confirmDescObj;
    public GameObject confirmCurrencyObj;
    public void GetItemDetails(int itemNo)
    {
        confirmItemObj = GameObject.FindGameObjectWithTag("ConfirmItem");
        confirmPriceObj = GameObject.FindGameObjectWithTag("ConfirmPrice");
        confirmCurrencyObj = GameObject.FindGameObjectWithTag("ConfirmCurrency");
        confirmDescObj = GameObject.FindGameObjectWithTag("ConfirmDesc");
        confirmDescObj.GetComponent<Text>().fontSize = 45;

        if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinTV")
        {
            confirmCurrencyObj.GetComponent<Image>().sprite = coinCurrency;
            if (pageNo == 1)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[0];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[0].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[1];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[1].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[2];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[2].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 2)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[3];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[3].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[4];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[4].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[5];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[5].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 3)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[6];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[6].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[7];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[7].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[8];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[8].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 4)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = coinItemList[9];
                    confirmPriceObj.GetComponent<Text>().text = coinPriceList[9].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
        }
        else if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinRemote")
        {

            confirmCurrencyObj.GetComponent<Image>().sprite = moneyCurrency;
            if (pageNo == 1)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[0];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[0].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[1];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[1].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[2];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[2].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 2)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[3];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[3].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[4];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[4].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[5];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[5].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 3)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[6];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[6].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[7];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[7].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[8];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[8].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 4)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = moneyItemList[9];
                    confirmPriceObj.GetComponent<Text>().text = moneyPriceList[9].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
        }
        else if (currencyGameObj[0].GetComponent<Image>().sprite.name == "CoinBackground")
        {

            confirmCurrencyObj.GetComponent<Image>().sprite = backgroundCurrency;
            if (pageNo == 1)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[0];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[0].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[1];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[1].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[2];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[2].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 2)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[3];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[3].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[4];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[4].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[5];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[5].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 3)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[6];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[6].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 2)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[7];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[7].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
                else if (itemNo == 3)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[8];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[8].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
            else if (pageNo == 4)
            {
                if (itemNo == 1)
                {
                    confirmItemObj.GetComponent<Image>().sprite = backgroundItemList[9];
                    confirmPriceObj.GetComponent<Text>().text = backgroundPriceList[9].ToString();
                    confirmDescObj.GetComponent<Text>().text = "Are You Sure You Want To Purchase This Item?";
                }
            }
        }
    }
    public void StoreButtonPressed(int shopNo)
    {
        SetActiveStore(shopNo);
    }
    public void SetActiveStore(int storeNo)
    {
        activeStore = storeNo;
        if (storeNo == 1)
        {
            SetButtonActive(cButton);
            SetButtonInactive(gButton);
            SetButtonInactive(bButton);
        }
        else if (storeNo == 2)
        {
            SetButtonActive(gButton);
            SetButtonInactive(cButton);
            SetButtonInactive(bButton);
        }
        else if (storeNo == 3)
        {
            SetButtonActive(bButton);
            SetButtonInactive(cButton);
            SetButtonInactive(gButton);
        }
    }
    public void OnAndOffButton(GameObject[] gameObject)
    {
        for (int i = 0; i <= gameObject.Length - 1; i++)
        {
            if (gameObject[i].activeInHierarchy)
            {
                Button button = gameObject[i].GetComponent<Button>();
                button.interactable = !button.interactable;
            }
        }
    }
    public void StoreMenuPressed()
    {
        SMShader.SetActive(false);
        UI.SetActive(false);
        mainMenuScript.ShaderON();
        mainMenuScript.OnAndOffButton(mainMenuScript.buttons);
        storeMenu.gameObject.SetActive(true);
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        player.LoadPlayer();
        pageNo = 1;
        GameObject temp1 = GameObject.FindGameObjectWithTag("playerCoins");
        coinText = temp1.GetComponent<Text>();
        coinText.text = player.playerCoins.ToString();
        LoadStoreSettings();
    }
    public void UpdateStoreMenu()
    {
        storeMenu.gameObject.SetActive(false);
    }
    public void CloseStoreMenu(string option)
    {
        UI.SetActive(true);
        mainMenuScript.ShaderOff();
        storeMenu.gameObject.SetActive(false);
    }
    public void SetPageNo(int pageNo)
    {
        this.pageNo = pageNo;
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(true);
    }
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject itemD1;
    public GameObject itemD2;
    public GameObject itemD3;
    public Button b1;
    public Button b2;
    public Button b3;
    public Toggle t1;
    public Toggle t2;
    public Toggle t3;

    public void SelectItems(int option, string store)
    {
        if (store == "T")
        {
            if (option == 1)
            {
                priceGameObj[0].GetComponent<Text>().text = "Selected";
                t3.interactable = false;
            }
            if (option == 2)
            {
                priceGameObj[1].GetComponent<Text>().text = "Selected";
                t2.interactable = false;
            }
            if (option == 3)
            {
                priceGameObj[2].GetComponent<Text>().text = "Selected";
                t1.interactable = false;
            }
        }
        else if (store == "R")
        {
            if (option == 1)
            {
                priceGameObj[0].GetComponent<Text>().text = "Selected";
                t3.interactable = false;
            }
            if (option == 2)
            {
                priceGameObj[1].GetComponent<Text>().text = "Selected";
                t2.interactable = false;
            }
            if (option == 3)
            {
                priceGameObj[2].GetComponent<Text>().text = "Selected";
                t1.interactable = false;
            }
        }
        else if (store == "BG")
        {
            if (option == 1)
            {
                priceGameObj[0].GetComponent<Text>().text = "Selected";
                t3.interactable = false;
            }
            if (option == 2)
            {
                priceGameObj[1].GetComponent<Text>().text = "Selected";
                t2.interactable = false;
            }
            if (option == 3)
            {
                priceGameObj[2].GetComponent<Text>().text = "Selected";
                t1.interactable = false;
            }
        }
    }
    public void ClearItems(int option, string store)
    {
        int itemRef = 0;
        if (store == "T")
        {
            if (option == 1)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 0;
                        break;
                    case 2:
                        itemRef = 3;
                        break;
                    case 3:
                        itemRef = 6;
                        break;
                    case 4:
                        itemRef = 9;
                        break;
                }

                if (player.unlockedTVS[itemRef] == false)
                {
                    priceGameObj[0].GetComponent<Text>().text = coinPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                    t3.interactable = true;
                }
            }
            if (option == 2)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 1;
                        break;
                    case 2:
                        itemRef = 4;
                        break;
                    case 3:
                        itemRef = 7;
                        break;
                }

                if (player.unlockedTVS[itemRef] == false)
                {
                    priceGameObj[1].GetComponent<Text>().text = coinPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                    t2.interactable = true;
                }
            }
            if (option == 3)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 2;
                        break;
                    case 2:
                        itemRef = 5;
                        break;
                    case 3:
                        itemRef = 8;
                        break;
                }

                if (player.unlockedTVS[itemRef] == false)
                {
                    priceGameObj[2].GetComponent<Text>().text = coinPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                    t1.interactable = true;
                }
            }
        }
        else if (store == "R")
        {
            if (option == 1)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 0;
                        break;
                    case 2:
                        itemRef = 3;
                        break;
                    case 3:
                        itemRef = 6;
                        break;
                    case 4:
                        itemRef = 9;
                        break;
                }

                if (player.unlockedRemotes[itemRef] == false)
                {
                    priceGameObj[0].GetComponent<Text>().text = moneyPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                    t3.interactable = true;
                }
            }
            if (option == 2)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 1;
                        break;
                    case 2:
                        itemRef = 4;
                        break;
                    case 3:
                        itemRef = 7;
                        break;
                }

                if (player.unlockedRemotes[itemRef] == false)
                {
                    priceGameObj[1].GetComponent<Text>().text = moneyPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                    t2.interactable = true;
                }
            }
            if (option == 3)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 2;
                        break;
                    case 2:
                        itemRef = 5;
                        break;
                    case 3:
                        itemRef = 8;
                        break;
                }

                if (player.unlockedRemotes[itemRef] == false)
                {
                    priceGameObj[2].GetComponent<Text>().text = moneyPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                    t1.interactable = true;
                }
            }
        }
        else if (store == "BG")
        {
            if (option == 1)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 0;
                        break;
                    case 2:
                        itemRef = 3;
                        break;
                    case 3:
                        itemRef = 6;
                        break;
                    case 4:
                        itemRef = 9;
                        break;
                }

                if (player.unlockedBackgrounds[itemRef] == false)
                {
                    priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                    t3.interactable = true;
                }
            }
            if (option == 2)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 1;
                        break;
                    case 2:
                        itemRef = 4;
                        break;
                    case 3:
                        itemRef = 7;
                        break;
                }

                if (player.unlockedBackgrounds[itemRef] == false)
                {
                    priceGameObj[1].GetComponent<Text>().text = backgroundPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                    t2.interactable = true;
                }
            }
            if (option == 3)
            {
                switch (pageNo)
                {
                    case 1:
                        itemRef = 2;
                        break;
                    case 2:
                        itemRef = 5;
                        break;
                    case 3:
                        itemRef = 8;
                        break;
                }

                if (player.unlockedBackgrounds[itemRef] == false)
                {
                    priceGameObj[2].GetComponent<Text>().text = backgroundPriceList[itemRef].ToString();
                }
                else
                {
                    priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                    t1.interactable = true;
                }
            }
        }
    }
    string storeType;
    public void Storetype()
    {
        if (currencyType.name == "CoinTV")
        {
            storeType = "T";
        }
        else if (currencyType.name == "CoinRemote")
        {
            storeType = "R";
        }
        else if (currencyType.name == "CoinBackground")
        {
            storeType = "BG";
        }
    }

    public void SelectItemInStore(int toggle)
    {
        if (storeType == "T")
        {
            if (toggle == 1)
            {
                if (pageNo == 1)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 0;
                        player.SavePlayer();

                        if (player.unlockedTVS[1] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = coinPriceList[1].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedTVS[2] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = coinPriceList[2].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 3;
                        player.SavePlayer();


                        if (player.unlockedTVS[4] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = coinPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedTVS[5] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = coinPriceList[5].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 6;
                        player.SavePlayer();

                        if (player.unlockedTVS[7] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = coinPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedTVS[8] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = coinPriceList[8].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 9;
                        player.SavePlayer();
                    }
                }


                t3.interactable = false;
                t2.interactable = true;
                t1.interactable = true;
            }
            else if (toggle == 2)
            {
                if (pageNo == 1)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedTVS[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = coinPriceList[0].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 1;
                        player.SavePlayer();

                        if (player.unlockedTVS[2] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = coinPriceList[2].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedTVS[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = coinPriceList[3].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 4;
                        player.SavePlayer();

                        if (player.unlockedTVS[4] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = coinPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedTVS[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = coinPriceList[6].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 7;
                        player.SavePlayer();

                        if (player.unlockedTVS[7] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = coinPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedTVS[9] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = coinPriceList[9].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }

                t2.interactable = false;
                t3.interactable = true;
                t1.interactable = true;
            }
            else if (toggle == 3)
            {
                if (pageNo == 1)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedTVS[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = coinPriceList[0].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedTVS[1] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = coinPriceList[1].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 2;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedTVS[3] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = coinPriceList[3].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedTVS[4] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = coinPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 5;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedTVS[6] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = coinPriceList[6].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedTVS[7] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = coinPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.TVNumber = 8;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedTVS[9] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = coinPriceList[9].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }

                t1.interactable = false;
                t3.interactable = true;
                t2.interactable = true;
            }
            
        }
        else if (storeType == "R")
        {
            if (toggle == 1)
            {
                if (pageNo == 1)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 0;
                        player.SavePlayer();

                        if (player.unlockedRemotes[1] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = moneyPriceList[1].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedRemotes[2] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = moneyPriceList[2].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 3;
                        player.SavePlayer();


                        if (player.unlockedRemotes[4] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = moneyPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedRemotes[5] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = moneyPriceList[5].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 6;
                        player.SavePlayer();

                        if (player.unlockedRemotes[7] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = moneyPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedRemotes[8] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = moneyPriceList[8].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 9;
                        player.SavePlayer();
                    }
                }


                t3.interactable = false;
                t2.interactable = true;
                t1.interactable = true;
            }
            else if (toggle == 2)
            {
                if (pageNo == 1)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedRemotes[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = moneyPriceList[0].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 1;
                        player.SavePlayer();

                        if (player.unlockedRemotes[2] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = moneyPriceList[2].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedRemotes[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = moneyPriceList[3].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 4;
                        player.SavePlayer();

                        if (player.unlockedRemotes[4] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = moneyPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedRemotes[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = moneyPriceList[6].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 7;
                        player.SavePlayer();

                        if (player.unlockedRemotes[7] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = moneyPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedRemotes[9] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = moneyPriceList[9].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }

                t2.interactable = false;
                t3.interactable = true;
                t1.interactable = true;
            }
            else if (toggle == 3)
            {
                if (pageNo == 1)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedRemotes[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = moneyPriceList[0].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedRemotes[1] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = moneyPriceList[1].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 2;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedRemotes[3] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = moneyPriceList[3].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedRemotes[4] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = moneyPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 5;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedRemotes[6] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = moneyPriceList[6].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedRemotes[7] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = moneyPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.remoteNumber = 8;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedRemotes[9] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = moneyPriceList[9].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }

                t1.interactable = false;
                t3.interactable = true;
                t2.interactable = true;
            }
        }
        else if (storeType == "BG")
        {
            if (toggle == 1)
            {
                if (pageNo == 1)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 0;
                        player.SavePlayer();

                        if (player.unlockedBackgrounds[1] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = backgroundPriceList[1].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedBackgrounds[2] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = backgroundPriceList[2].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 3;
                        player.SavePlayer();


                        if (player.unlockedBackgrounds[4] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = backgroundPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedBackgrounds[5] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = backgroundPriceList[5].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 6;
                        player.SavePlayer();

                        if (player.unlockedBackgrounds[7] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = backgroundPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        if (player.unlockedBackgrounds[8] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = backgroundPriceList[8].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 1)
                    {
                        priceGameObj[0].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 9;
                        player.SavePlayer();
                    }
                }


                t3.interactable = false;
                t2.interactable = true;
                t1.interactable = true;
            }
            else if (toggle == 2)
            {
                if (pageNo == 1)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedBackgrounds[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[0].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 1;
                        player.SavePlayer();

                        if (player.unlockedBackgrounds[2] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = backgroundPriceList[2].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedBackgrounds[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[3].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 4;
                        player.SavePlayer();

                        if (player.unlockedBackgrounds[4] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = backgroundPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedBackgrounds[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[6].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[1].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 7;
                        player.SavePlayer();

                        if (player.unlockedBackgrounds[7] == false)
                        {
                            priceGameObj[2].GetComponent<Text>().text = backgroundPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[2].GetComponent<Text>().text = "Unlocked";
                        }

                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 2)
                    {

                        if (player.unlockedBackgrounds[9] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[9].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }

                t2.interactable = false;
                t3.interactable = true;
                t1.interactable = true;
            }
            else if (toggle == 3)
            {
                if (pageNo == 1)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedBackgrounds[0] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[0].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedBackgrounds[1] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = backgroundPriceList[1].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 2;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 2)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedBackgrounds[3] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[3].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedBackgrounds[4] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = backgroundPriceList[4].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 5;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 3)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedBackgrounds[6] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[6].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                        if (player.unlockedBackgrounds[7] == false)
                        {
                            priceGameObj[1].GetComponent<Text>().text = backgroundPriceList[7].ToString();
                        }
                        else
                        {
                            priceGameObj[1].GetComponent<Text>().text = "Unlocked";
                        }

                        priceGameObj[2].GetComponent<Text>().text = "Selected";
                        player.backgroundNumber = 8;
                        player.SavePlayer();
                    }
                }
                else if (pageNo == 4)
                {
                    if (toggle == 3)
                    {

                        if (player.unlockedBackgrounds[9] == false)
                        {
                            priceGameObj[0].GetComponent<Text>().text = backgroundPriceList[9].ToString();
                        }
                        else
                        {
                            priceGameObj[0].GetComponent<Text>().text = "Unlocked";
                        }
                    }
                }

                t1.interactable = false;
                t3.interactable = true;
                t2.interactable = true;
            }

        }
    }

    public Sprite currencyType;
    public void PageSetup(Sprite currency)
    {
        player.LoadPlayer();
        currencyType = currency;
        Storetype();
        int startingNo = 0;
        if (currencyGameObj == null)
        {
            currencyGameObj = GameObject.FindGameObjectsWithTag("Currency");
            itemGameObj = GameObject.FindGameObjectsWithTag("Item");
            priceGameObj = GameObject.FindGameObjectsWithTag("Price");
        }

            item2.gameObject.SetActive(true);
            itemD2.gameObject.SetActive(true);
            b2.gameObject.SetActive(true);
            item3.GetComponent<Image>().gameObject.SetActive(true);
            itemD3.gameObject.SetActive(true);
            b3.gameObject.SetActive(true);

        if (currency.name == "CoinTV")
        {
            if (pageNo == 1)
            {
                startingNo = 0;
            }
            else if (pageNo == 2)
            {
                startingNo = 3;
            }
            else if (pageNo == 3)
            {
                startingNo = 6;
            }
            else if (pageNo == 4)
            {
                startingNo = 9;
            }
            for (int i = 0; i < currencyGameObj.Length; i++)
            {
                currencyGameObj[i].GetComponent<Image>().sprite = coinCurrency;
            }
            for (int i = 0; i < priceGameObj.Length; i++)
            {
                if (player.unlockedTVS[startingNo] == true)
                {
                    if (startingNo <= 9)
                    {
                        if (startingNo != 9)
                        {

                            itemGameObj[i].GetComponent<Image>().sprite = coinItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = "Unlocked";
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 0);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                        else
                        {
                            itemGameObj[i].GetComponent<Image>().sprite = coinItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = "Unlocked";
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 0);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                    }
                    else
                    {
                        priceGameObj[i].GetComponent<Text>().text = "";
                        priceGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b2.gameObject.SetActive(false);
                        Image temp = currencyGameObj[i].GetComponent<Image>();
                        temp.color = new Color32(255, 255, 255, 0);
                        currencyGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b3.gameObject.SetActive(false);
                        Image temp1 = itemGameObj[i].GetComponent<Image>();
                        temp1.color = new Color32(255, 255, 255, 0);

                    }
                    if (i == 0)
                    {
                        b1.interactable = false;
                        t3.gameObject.SetActive(true);
                        if (player.TVNumber == startingNo)
                        {
                            SelectItems(1, "T");
                        }
                        else
                        {
                            ClearItems(1, "T");
                        }
                    }
                    else if (i == 1)
                    {
                        b2.interactable = false;
                        t2.gameObject.SetActive(true);
                        if (player.TVNumber == startingNo)
                        {
                            print(player.TVNumber);
                            SelectItems(2, "T");
                        }
                        else
                        {
                            ClearItems(2, "T");
                        }

                    }
                    else if (i == 2)
                    {
                        b3.interactable = false;
                        t1.gameObject.SetActive(true);
                        if (player.TVNumber == startingNo)
                        {
                            print(player.TVNumber);
                            SelectItems(3, "T");
                        }
                        else
                        {
                            ClearItems(3, "T");
                        }
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        b1.interactable = true;
                        t3.gameObject.SetActive(false);
                    }
                    else if (i == 1)
                    {
                        b2.interactable = true;
                        t2.gameObject.SetActive(false);
                    }
                    else if (i == 2)
                    {
                        b3.interactable = true;
                        t1.gameObject.SetActive(false);
                    }

                    if (startingNo <= 9)
                    {
                        if (startingNo != 9)
                        {

                            itemGameObj[i].GetComponent<Image>().sprite = coinItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = coinPriceList[startingNo].ToString();
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 255);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                        else
                        {
                            itemGameObj[i].GetComponent<Image>().sprite = coinItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = coinPriceList[startingNo].ToString();
                        }
                    }
                    else
                    {
                        priceGameObj[i].GetComponent<Text>().text = "";
                        priceGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b2.gameObject.SetActive(false);
                        Image temp = currencyGameObj[i].GetComponent<Image>();
                        temp.color = new Color32(255, 255, 255, 0);
                        currencyGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b3.gameObject.SetActive(false);
                        Image temp1 = itemGameObj[i].GetComponent<Image>();
                        temp1.color = new Color32(255, 255, 255, 0);

                    }
                }
                startingNo++;


            }

        }
        //HERERE
        else if (currency.name == "CoinRemote")
        {
            if (pageNo == 1)
            {
                startingNo = 0;
            }
            else if (pageNo == 2)
            {
                startingNo = 3;
            }
            else if (pageNo == 3)
            {
                startingNo = 6;
            }
            else if (pageNo == 4)
            {
                startingNo = 9;
            }
            for (int i = 0; i < currencyGameObj.Length; i++)
            {
                currencyGameObj[i].GetComponent<Image>().sprite = moneyCurrency;
            }
            for (int i = 0; i < priceGameObj.Length; i++)
            {
                if (player.unlockedRemotes[startingNo] == true)
                {
                    if (startingNo <= 9)
                    {
                        if (startingNo != 9)
                        {

                            itemGameObj[i].GetComponent<Image>().sprite = moneyItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = "Unlocked";
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 0);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                        else
                        {
                            itemGameObj[i].GetComponent<Image>().sprite = moneyItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = "Unlocked";
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 0);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                    }
                    else
                    {
                        priceGameObj[i].GetComponent<Text>().text = "";
                        priceGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b2.gameObject.SetActive(false);
                        Image temp = currencyGameObj[i].GetComponent<Image>();
                        temp.color = new Color32(255, 255, 255, 0);
                        currencyGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b3.gameObject.SetActive(false);
                        Image temp1 = itemGameObj[i].GetComponent<Image>();
                        temp1.color = new Color32(255, 255, 255, 0);

                    }
                    if (i == 0)
                    {
                        b1.interactable = false;
                        t3.gameObject.SetActive(true);
                        if (player.remoteNumber == startingNo)
                        {
                            SelectItems(1, "R");
                        }
                        else
                        {
                            ClearItems(1, "R");
                        }
                    }
                    else if (i == 1)
                    {
                        b2.interactable = false;
                        t2.gameObject.SetActive(true);
                        if (player.remoteNumber == startingNo)
                        {
                            SelectItems(2, "R");
                        }
                        else
                        {
                            ClearItems(2, "R");
                        }

                    }
                    else if (i == 2)
                    {
                        b3.interactable = false;
                        t1.gameObject.SetActive(true);
                        if (player.remoteNumber == startingNo)
                        {
                            SelectItems(3, "R");
                        }
                        else
                        {
                            ClearItems(3, "R");
                        }
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        b1.interactable = true;
                        t3.gameObject.SetActive(false);
                    }
                    else if (i == 1)
                    {
                        b2.interactable = true;
                        t2.gameObject.SetActive(false);
                    }
                    else if (i == 2)
                    {
                        b3.interactable = true;
                        t1.gameObject.SetActive(false);
                    }

                    if (startingNo <= 9)
                    {
                        if (startingNo != 9)
                        {

                            itemGameObj[i].GetComponent<Image>().sprite = moneyItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = moneyPriceList[startingNo].ToString();
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 255);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                        else
                        {
                            itemGameObj[i].GetComponent<Image>().sprite = moneyItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = moneyPriceList[startingNo].ToString();
                        }
                    }
                    else
                    {
                        priceGameObj[i].GetComponent<Text>().text = "";
                        priceGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b2.gameObject.SetActive(false);
                        Image temp = currencyGameObj[i].GetComponent<Image>();
                        temp.color = new Color32(255, 255, 255, 0);
                        currencyGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b3.gameObject.SetActive(false);
                        Image temp1 = itemGameObj[i].GetComponent<Image>();
                        temp1.color = new Color32(255, 255, 255, 0);

                    }
                }
                startingNo++;


            }

        }
        else if (currency.name == "CoinBackground")
        {
            if (pageNo == 1)
            {
                startingNo = 0;
            }
            else if (pageNo == 2)
            {
                startingNo = 3;
            }
            else if (pageNo == 3)
            {
                startingNo = 6;
            }
            else if (pageNo == 4)
            {
                startingNo = 9;
            }
            for (int i = 0; i < currencyGameObj.Length; i++)
            {
                currencyGameObj[i].GetComponent<Image>().sprite = backgroundCurrency;
            }
            for (int i = 0; i < priceGameObj.Length; i++)
            {
                if (player.unlockedBackgrounds[startingNo] == true)
                {
                    if (startingNo <= 9)
                    {
                        if (startingNo != 9)
                        {

                            itemGameObj[i].GetComponent<Image>().sprite = backgroundItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = "Unlocked";
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 0);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                        else
                        {
                            itemGameObj[i].GetComponent<Image>().sprite = backgroundItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = "Unlocked";
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 0);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                    }
                    else
                    {
                        priceGameObj[i].GetComponent<Text>().text = "";
                        priceGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b2.gameObject.SetActive(false);
                        Image temp = currencyGameObj[i].GetComponent<Image>();
                        temp.color = new Color32(255, 255, 255, 0);
                        currencyGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b3.gameObject.SetActive(false);
                        Image temp1 = itemGameObj[i].GetComponent<Image>();
                        temp1.color = new Color32(255, 255, 255, 0);
                    }

                    if (i == 0)
                    {
                        b1.interactable = false;
                        t3.gameObject.SetActive(true);
                        if (player.backgroundNumber == startingNo)
                        {
                            SelectItems(1, "BG");
                        }
                        else
                        {
                            ClearItems(1, "BG");
                        }
                    }
                    else if (i == 1)
                    {
                        b2.interactable = false;
                        t2.gameObject.SetActive(true);
                        if (player.backgroundNumber == startingNo)
                        {
                            SelectItems(2, "BG");
                        }
                        else
                        {
                            ClearItems(2, "BG");
                        }

                    }
                    else if (i == 2)
                    {
                        b3.interactable = false;
                        t1.gameObject.SetActive(true);
                        if (player.backgroundNumber == startingNo)
                        {
                            SelectItems(3, "BG");
                        }
                        else
                        {
                            ClearItems(3, "BG");
                        }
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        b1.interactable = true;
                        t3.gameObject.SetActive(false);
                    }
                    else if (i == 1)
                    {
                        b2.interactable = true;
                        t2.gameObject.SetActive(false);
                    }
                    else if (i == 2)
                    {
                        b3.interactable = true;
                        t1.gameObject.SetActive(false);
                    }

                    if (startingNo <= 9)
                    {
                        if (startingNo != 9)
                        {

                            itemGameObj[i].GetComponent<Image>().sprite = backgroundItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = backgroundPriceList[startingNo].ToString();
                            Image temp = currencyGameObj[i].GetComponent<Image>();
                            temp.color = new Color32(255, 255, 255, 255);
                            Image temp1 = itemGameObj[i].GetComponent<Image>();
                            temp1.color = new Color32(255, 255, 255, 255);
                        }
                        else
                        {
                            itemGameObj[i].GetComponent<Image>().sprite = backgroundItemList[startingNo];
                            priceGameObj[i].GetComponent<Text>().text = backgroundPriceList[startingNo].ToString();
                        }
                    }
                    else
                    {
                        priceGameObj[i].GetComponent<Text>().text = "";
                        priceGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b2.gameObject.SetActive(false);
                        Image temp = currencyGameObj[i].GetComponent<Image>();
                        temp.color = new Color32(255, 255, 255, 0);
                        currencyGameObj[i].GetComponentInParent<Image>().gameObject.SetActive(false);
                        b3.gameObject.SetActive(false);
                        Image temp1 = itemGameObj[i].GetComponent<Image>();
                        temp1.color = new Color32(255, 255, 255, 0);

                    }
                }
                startingNo++;
            }
        }
    }
    int activeStore =1;
    public void RightButtonPressed()
    {
        pageNo = pageNo + 1;
        
        if (activeStore == 1)
        {
            if (pageNo == 2)
            {
                leftButton.gameObject.SetActive(true);
                PageSetup(coinCurrency);

            }
            else if (pageNo == 3)
            {
                PageSetup(coinCurrency);
            }
            else if (pageNo == 4)
            {
                PageSetup(coinCurrency);
                rightButton.gameObject.SetActive(false);
            }
        }
        else if (activeStore == 2)
        {

            if (pageNo == 2)
            {
                leftButton.gameObject.SetActive(true);
                PageSetup(moneyCurrency);

            }
            else if (pageNo == 3)
            {
                PageSetup(moneyCurrency);
            }
            else if (pageNo == 4)
            {
                PageSetup(moneyCurrency);
                rightButton.gameObject.SetActive(false);
            }
        }
        else if (activeStore == 3)
        {

            if (pageNo == 2)
            {
                leftButton.gameObject.SetActive(true);
                PageSetup(backgroundCurrency);

            }
            else if (pageNo == 3)
            {
                PageSetup(backgroundCurrency);
            }
            else if (pageNo == 4)
            {
                PageSetup(backgroundCurrency);
                rightButton.gameObject.SetActive(false);
            }
        }
        
    }
    public void LeftButtonPressed()
    {

        pageNo = pageNo - 1;

        if (activeStore == 1)
        {
            if (pageNo == 1)
            {
                leftButton.gameObject.SetActive(false);
                PageSetup(coinCurrency);
            }
            else if (pageNo == 2)
            {
                rightButton.gameObject.SetActive(true);
                PageSetup(coinCurrency);
            }
            else if (pageNo == 3)
            {
                rightButton.gameObject.SetActive(true);
                PageSetup(coinCurrency);
            }
        }
        else if (activeStore == 2)
        {
            if (pageNo == 1)
            {
                leftButton.gameObject.SetActive(false);
                PageSetup(moneyCurrency);
            }
            else if (pageNo == 2)
            {
                rightButton.gameObject.SetActive(true);
                PageSetup(moneyCurrency);
            }
             else if (pageNo == 3)
             {
                rightButton.gameObject.SetActive(true);
                PageSetup(moneyCurrency);
             }
 
        }

        else if (activeStore == 3)
        {
            if (pageNo == 1)
            {
                leftButton.gameObject.SetActive(false);
                PageSetup(backgroundCurrency);
            }
            else if (pageNo == 2)
            {
                rightButton.gameObject.SetActive(true);
                PageSetup(backgroundCurrency);
            }
            else if (pageNo == 3)
            {
                rightButton.gameObject.SetActive(true);
                PageSetup(backgroundCurrency);
            }

        }
    }
}
