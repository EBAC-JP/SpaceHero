using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOProjectile : ScriptableObject {
    [SerializeField] public int damage;
    [SerializeField] public float timeToDestroy;
    [SerializeField] public Vector2 direction;
}
