using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {

    [Header("Setup")]
    [SerializeField] HealthBase health;
    [SerializeField] Animator myAnim;
    [SerializeField] SOPlayer playerSetup;
    [Header("Particles")]
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField] ParticleSystem walkVFX;

    float _distToGround;
    Rigidbody2D  _myRigid;
    Collider2D _myCollider;

    void Awake() {
        if (health != null) health.OnKill += OnPlayerDeath;
    }

    void Start() {
        _myRigid = GetComponent<Rigidbody2D>();
        _myCollider = GetComponent<Collider2D>();
        _distToGround = _myCollider.bounds.extents.y;
    }

    void Update() {
        HandleAnimation();
        HandleParticles();
        HandleJump();
        HandleMoviment();
    }

    void HandleParticles() {
        if (IsGrounded() && walkVFX.isPaused) {
            walkVFX.Play();
        }
    }

    void HandleAnimation() {
        myAnim.SetBool(playerSetup.groundVariable, IsGrounded());
        if (_myRigid.velocity.x != 0) myAnim.SetBool(playerSetup.runVariable, true);
        else myAnim.SetBool(playerSetup.runVariable, false);
    }

    void HandleJump() {
        if (Input.GetKeyDown(playerSetup.jumpKey) && IsGrounded()) {
            _myRigid.velocity = Vector2.up * playerSetup.jumpForce;
            myAnim.SetTrigger(playerSetup.jumpTrigger);
            if (jumpVFX != null) jumpVFX.Play();
            Invoke(nameof(StopWalkParticle), 0.2f);
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

    void StopWalkParticle() {
        walkVFX.Pause();
    }

    void OnPlayerDeath() {
        health.OnKill -= OnPlayerDeath;
        myAnim.SetTrigger(playerSetup.deathTrigger);
    }

    public bool IsGrounded() {
        return Physics2D.Raycast(transform.position, -Vector2.up, _distToGround + playerSetup.spaceToJump);
    }

    public void DestroyMe() {
        Destroy(gameObject);
    }
}
