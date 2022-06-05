using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManagement : MonoBehaviour {

    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject title;

    public void ShowOptions() {
        if (title != null) title.SetActive(false);
        OptionsMenu.SetActive(true);
        GameManager.ChangeTimeScale(0);
    }

    public void Back() {
        if (title != null) title.SetActive(true);
        OptionsMenu.SetActive(false);
        GameManager.ChangeTimeScale(1);
    }
}
