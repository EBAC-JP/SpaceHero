using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOHealth : ScriptableObject {
    [Header("Life")]
    [SerializeField] public int totalLife;
    [SerializeField] public bool destroyOnKill = false;
    [SerializeField] public float destroyDelay = 0f;
}
