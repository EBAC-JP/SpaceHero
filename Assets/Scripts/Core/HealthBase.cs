using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour {
    
    [SerializeField] SOHealth health;
    [SerializeField] FlashColor flashColor;
    [SerializeField] AudioSource damageSource;
    [SerializeField] public Action OnKill;

    int _currentLife;
    bool _isDead;

    void Awake() {
        _currentLife = health.totalLife;
        _isDead = false;
    }

    void Kill() {
        _isDead = true;
        OnKill?.Invoke();
        if (health.destroyOnKill) Destroy(gameObject, health.destroyDelay);
    }

    public void Damage(int damage) {
        if (_isDead) return;
        _currentLife -= damage;
        if (damageSource != null) damageSource.Play();
        if (_currentLife <= 0) Kill();
        if (flashColor != null) flashColor.Flash();
    }
}
