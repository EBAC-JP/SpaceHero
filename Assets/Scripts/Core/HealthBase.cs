using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour {
    [Header("Life")]
    [SerializeField] int totalLife;
    [SerializeField] bool destroyOnKill = false;
    [SerializeField] float destroyDelay = 0f;
    [Header("Visual")]
    [SerializeField] FlashColor flashColor;
    [SerializeField] public Action OnKill;

    int _currentLife;
    bool _isDead;

    void Awake() {
        _currentLife = totalLife;
        _isDead = false;
    }

    void Kill() {
        _isDead = true;
        OnKill?.Invoke();
        if (destroyOnKill) Destroy(gameObject, destroyDelay);
    }

    public void Damage(int damage) {
        if (_isDead) return;
        _currentLife -= damage;
        if (_currentLife <= 0) Kill();
        if (flashColor != null) flashColor.Flash();
    }
}
