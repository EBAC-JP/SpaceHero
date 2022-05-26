using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
    [SerializeField] HealthBase health;
    [SerializeField] SOEnemy enemy;
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
            health.Damage(enemy.damage);
            PlayAttackAnimation();
        }
    }

    void PlayAttackAnimation() {
        enemyAnimator.SetTrigger(enemy.attackTrigger);
    }

    void PlayDeathAnimation() {
        enemyAnimator.SetTrigger(enemy.deathTrigger);
    }

    public void Damage(int amount) {
        health.Damage(amount);
    }
}
