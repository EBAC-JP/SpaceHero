using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollactableBase {

    [SerializeField] int value = 1;

    protected override void Collect() {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected override void OnCollect() {
        ItemManager.Instance.AddCoins(value);
    }
}
