using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : Singleton<ItemManager> {

    [SerializeField] TMP_Text coinsText;
    [SerializeField] public int qtdCoins;
    void Start() {
        Reset();
    }

    void Update() {
        coinsText.text = "x " + qtdCoins.ToString();
    }

    void Reset() {
        qtdCoins = 0;
    }

    public void AddCoins(int amount = 1) {
        qtdCoins += amount;
    }
}
