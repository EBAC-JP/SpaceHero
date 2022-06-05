using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour {

    [SerializeField] SOProjectile projectile;
    [SerializeField] public float side;
    [SerializeField] AudioSource shootSound;

    void Awake() {
        if (shootSound != null) shootSound.Play();
        Destroy(gameObject, projectile.timeToDestroy);
    }

    void Update() {
        transform.Translate(projectile.direction * Time.deltaTime * side);
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        var enemy = collider2D.gameObject.GetComponent<EnemyBase>();
        if (enemy != null) {
            enemy.Damage(projectile.damage);
            Destroy(gameObject);
        }
    }
}
