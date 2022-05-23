using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
    [SerializeField] HealthBase health;
    [SerializeField] int damage;
    [Header("Animations")]
    [SerializeField] string attackTrigger = "Attack";
    [SerializeField] string deathTrigger = "Death";
    [SerializeField] Animator enemyAnimator;

    void Awake() {
        if (health != null) health.OnKill += OnEnemyDeath;
    }

    void OnEnemyDeath() {
        health.OnKill -= OnEnemyDeath;
        PlayDeathAnimation();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        var health = collider.GetComponent<HealthBase>();
        if (health != null) {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    void PlayAttackAnimation() {
        enemyAnimator.SetTrigger(attackTrigger);
    }

    void PlayDeathAnimation() {
        enemyAnimator.SetTrigger(deathTrigger);
    }

    public void Damage(int amount) {
        health.Damage(amount);
    }
}
