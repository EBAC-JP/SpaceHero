using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour {

    [SerializeField] public float side;
    [SerializeField] Vector2 direction;
    [SerializeField] int damage;
    [SerializeField] float timeToDestroy = 2f;

    void Awake() {
        Destroy(gameObject, timeToDestroy);
    }

    void Update() {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        var enemy = collider2D.gameObject.GetComponent<EnemyBase>();
        if (enemy != null) {
            enemy.Damage(damage);
            Destroy(gameObject);
        }
    }
}
