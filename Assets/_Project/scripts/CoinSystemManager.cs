using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla;
using Soomla.Store;

public class CoinSystemManager : MonoBehaviour {

    private int currentCoin = 0;
    int temporaryCurrentCoinCount;
    public float timeBetweenCoinIncrement = 0.05f;
    public Text coinText;

    public AudioSource audioSource;
    public AudioClip clip;

    bool userHasPlayerBefore = false;
    public int initialCoinCount = 250;

    void Start()
    {
        audioSource = GetComponent<AudioSource>() as AudioSource;

        userHasPlayerBefore = PlayerPrefs.GetString("userHasPlayerBefore").ToString().ToLowerInvariant() == "yes";
        if (userHasPlayerBefore)
        {
            LoadCoins();
        }
        else
        {
            currentCoin = initialCoinCount;
            SaveCoins();
        }

        coinText.text = currentCoin.ToString();
        temporaryCurrentCoinCount = currentCoin;

        StoreEvents.OnCurrencyBalanceChanged += OnCurrencyBalanceChanged;
    }

    void Update()
    {
        coinText.text = temporaryCurrentCoinCount.ToString();

        if (temporaryCurrentCoinCount < currentCoin)
        {
            if (!IsInvoking("incrementeTemporaryCoins"))
            {
                coinText.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                InvokeRepeating("incrementeTemporaryCoins", 0, timeBetweenCoinIncrement);
            }
        }
    }

    public void AddCoin(int quantity)
    {
        currentCoin += quantity;
    }

    void incrementeTemporaryCoins()
    {
        temporaryCurrentCoinCount++;
        audioSource.PlayOneShot(clip);
        if (temporaryCurrentCoinCount >= currentCoin)
        {
            CancelInvoke();
            coinText.transform.localScale = new Vector3(1f, 1f, 1f);
            SaveCoins();
        }
    }

    void LoadCoins()
    {
        currentCoin = PlayerPrefs.GetInt("coins");
    }

    void SaveCoins()
    {
        PlayerPrefs.SetInt("coins", currentCoin);
        userHasPlayerBefore = true;
        PlayerPrefs.SetString("userHasPlayerBefore","yes");
    }

    public bool CanRemoveCoins(int quantity)
    {
        return (currentCoin - quantity > 0);
    }

    public void OnCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded )
    {
        currentCoin = balance;
    }

}
