using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager> {

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI coinsText;

    public static void UpdateCoinsTexts(int qtd) {
        Instance.coinsText.text = "x " + qtd.ToString();
    }

}
