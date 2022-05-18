using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour {
    [Header("Life")]
    [SerializeField] int totalLife;
    [SerializeField] bool destroyOnKill = false;
    [Header("Visual")]
    [SerializeField] FlashColor flashColor;

    int _currentLife;
    bool _isDead;

    void Awake() {
        _currentLife = totalLife;
        _isDead = false;
    }

    void Kill() {
        _isDead = true;
        if (destroyOnKill) Destroy(gameObject);
    }

    public void Damage(int damage) {
        if (_isDead) return;
        _currentLife -= damage;
        if (_currentLife <= 0) Kill();
        if (flashColor != null) flashColor.Flash();
    }
}
