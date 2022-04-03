using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuController : MonoBehaviour {

    [Header("Title Setup")]
    [SerializeField] GameObject title;
    [SerializeField] float duration = .5f;
    [SerializeField] float delay = .5f;
    [SerializeField] Ease titleEase;

    void OnEnable() {
        ShowTitle();
    }

    void ShowTitle() {
        title.transform.DOScale(1, duration).SetDelay(delay).SetEase(titleEase);
    }
}
