using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollactableBase {

    protected override void Collect() {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected override void OnCollect() {
        ItemManager.Instance.AddCoins();
    }
}
