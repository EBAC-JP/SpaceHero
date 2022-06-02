using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject {

    [Header("Moviments")]
    [SerializeField] public float speed;
    [SerializeField] public Vector2 friction = new Vector2(-.1f, 0);
    [Header("Jump")]
    [SerializeField] public float jumpForce;
    [SerializeField] public float spaceToJump;
    [SerializeField] public ParticleSystem jumpVFX;
    [Header("Keys Setup")]
    [SerializeField] public KeyCode leftKey;
    [SerializeField] public KeyCode rightKey;
    [SerializeField] public KeyCode jumpKey;
    [Header("Animations Trigger")]
    [SerializeField] public string runVariable = "Run";
    [SerializeField] public string deathTrigger = "Death";
}
