using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {

    [SerializeField] HealthBase health;
    [SerializeField] Animator myAnim;
    [SerializeField] SOPlayer playerSetup;

    Rigidbody2D  _myRigid;

    void Awake() {
        if (health != null) health.OnKill += OnPlayerDeath;
    }

    void Start() {
        _myRigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        HandleAnimation();
        HandleJump();
        HandleMoviment();
    }

    void HandleAnimation() {
        if (_myRigid.velocity.x != 0) myAnim.SetBool(playerSetup.runVariable, true);
        else myAnim.SetBool(playerSetup.runVariable, false);
    }

    void HandleJump() {
        if (Input.GetKeyDown(playerSetup.jumpKey)) {
            _myRigid.velocity = Vector2.up * playerSetup.jumpForce;
        }
    }

    void HandleMoviment() {
        if (Input.GetKey(playerSetup.rightKey)) {
            _myRigid.velocity = new Vector2(playerSetup.speed, _myRigid.velocity.y);
            Flip(1);
        } else if(Input.GetKey(playerSetup.leftKey)) {
            _myRigid.velocity = new Vector2(-playerSetup.speed, _myRigid.velocity.y);
            Flip(-1);
        }
        HandleFriction();
    }

    void Flip(int scale) {
        transform.DOScaleX(scale, .1f);
    }

    void HandleFriction() {
        if (_myRigid.velocity.x > 0) _myRigid.velocity += playerSetup.friction;
        else if (_myRigid.velocity.x < 0) _myRigid.velocity -= playerSetup.friction;
    }

    void OnPlayerDeath() {
        health.OnKill -= OnPlayerDeath;
        myAnim.SetTrigger(playerSetup.deathTrigger);
    }

    public void DestroyMe() {
        Destroy(gameObject);
    }
}
