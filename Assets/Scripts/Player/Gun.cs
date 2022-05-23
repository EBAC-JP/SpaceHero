using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField] ProjectileBase projectilePrefab;
    [SerializeField] Transform spawnPosition;
    [SerializeField] Transform playerReference;
    [SerializeField] float shootCooldown;

    Coroutine _currentCoroutine;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _currentCoroutine = StartCoroutine(StartShoot());
        } else if(Input.GetMouseButtonUp(0)) {
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot() {
        while(true) {
            Shoot();
            yield return new WaitForSeconds(shootCooldown);
        }
    }

    void Shoot() {
        var projectile = Instantiate(projectilePrefab);
        projectile.transform.position = spawnPosition.position;
        projectile.side = playerReference.localScale.x;
    }
}
