using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager> {

    public int qtdCoins;
    void Start() {
        Reset();
    }

    void Reset() {
        qtdCoins = 0;
    }

    public void AddCoins(int amount = 1) {
        qtdCoins += amount;
    }
}
