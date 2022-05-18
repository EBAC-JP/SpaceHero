using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour {

    [SerializeField] List<SpriteRenderer> spriteRenderers;
    [SerializeField] Color flashColor;
    [SerializeField] float duration = .3f;

    Tween _currentTween;

    void OnValidate() {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>()) {
            spriteRenderers.Add(child);
        }    
    }

    public void Flash() {
        if (_currentTween != null) {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }
        foreach(var sprite in spriteRenderers) {
            _currentTween = sprite.DOColor(flashColor, duration).SetLoops(2, LoopType.Yoyo);
        }
    }

}
