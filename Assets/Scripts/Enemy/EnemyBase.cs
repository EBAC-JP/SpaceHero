using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
    [SerializeField] int damage;

    void OnTriggerEnter2D(Collider2D collider) {
        var health = collider.GetComponent<HealthBase>();
        if (health != null) health.Damage(damage);
    }
}
