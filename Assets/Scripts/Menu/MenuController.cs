using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuController : MonoBehaviour {

    [Header("Animations")]
    [SerializeField] List<GameObject> objects;
    [SerializeField] float duration = .5f;
    [SerializeField] float delay = .1f;
    [SerializeField] Ease animationEase;

    void OnEnable() {
        HideObjects();
        ShowObjects();
    }

    void HideObjects() {
        foreach(var obj in objects) {
            obj.transform.localScale = Vector3.zero;
            obj.SetActive(false);
        }
    }

    void ShowObjects() {
        for (int i = 0; i < objects.Count; i++) {
            var obj = objects[i];
            obj.SetActive(true);
            Debug.Log("Ativei");
            obj.transform.DOScale(1, duration).SetDelay(i * delay).SetEase(animationEase);
        }
    }
}
