using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
    [SerializeField] int damage;
    [SerializeField] string attackTrigger = "Attack";

    [SerializeField] Animator enemyAnimator;

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
}
