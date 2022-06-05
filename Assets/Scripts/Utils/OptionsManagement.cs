using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManagement : MonoBehaviour {

    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject title;
    [SerializeField] AudioSource selectSource;

    public void ShowOptions() {
        if (title != null) title.SetActive(false);
        if (selectSource != null) selectSource.Play();
        OptionsMenu.SetActive(true);
        GameManager.ChangeTimeScale(0);
    }

    public void Back() {
        if (title != null) title.SetActive(true);
        if (selectSource != null) selectSource.Play();
        OptionsMenu.SetActive(false);
        GameManager.ChangeTimeScale(1);
    }
}
