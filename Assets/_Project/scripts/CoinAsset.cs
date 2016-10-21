using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;
using Soomla.Singletons;
using System;

public class CoinAsset : IStoreAssets
{
    public const string COINS_CURRENCY_ITEM_ID = "currency_coins";

    public const string COINS_100_ID = "xxx SITE GOOGLA PLAY xxx";
    public const string COINS_350_ID = "xxx SITE GOOGLA PLAY xxx";

    public int GetVersion()
    {
        return 0;
    }

    public VirtualCurrency COIN_CURRENCY = new VirtualCurrency(
        "Coins",
        "coins to use the game",
        COINS_CURRENCY_ITEM_ID);

    public static VirtualCurrencyPack COINS_100_PACK = new VirtualCurrencyPack(
        "100 coins",
        "get 100 coins",
        COINS_100_ID,
        100,
        COINS_100_ID,
        new PurchaseWithMarket(COINS_100_ID, 0.99));


    public static VirtualCurrencyPack COINS_350_PACK = new VirtualCurrencyPack(
        "350 coins",
        "get 350 coins",
        COINS_350_ID,
        350,
        COINS_350_ID,
        new PurchaseWithMarket(COINS_350_ID, 1.99));

    public VirtualCurrencyPack[] GetCurrencyPacks()
    {
        return new VirtualCurrencyPack[] { COINS_100_PACK, COINS_350_PACK }; 
    }

    public VirtualCurrency[] GetCurrencies()
    {
        return new VirtualCurrency[] { COIN_CURRENCY };
    }  

    public VirtualGood[] GetGoods()
    {
        return new VirtualGood[] { };
    }

    public VirtualCategory[] GetCategories()
    {
        return new VirtualCategory[] { };
    }
    
}
