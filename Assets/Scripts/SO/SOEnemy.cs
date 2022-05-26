using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOEnemy : ScriptableObject {

    [Header("Damage")]
    [SerializeField] public int damage;
    [Header("Animations Trigger")]
    [SerializeField] public string attackTrigger = "Attack";
    [SerializeField] public string deathTrigger = "Death";
}
