using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager> {

    [SerializeField] SOInteger coins;

    void Start() {
        Reset();
    }

    void Reset() {
        coins.value = 0;
        UIManager.UpdateCoinsTexts(coins.value);
    }

    public void AddCoins(int amount = 1) {
        coins.value += amount;
        UIManager.UpdateCoinsTexts(coins.value);
    }
}
