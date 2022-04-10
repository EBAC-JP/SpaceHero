using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {

    [Header("Moviments")]
    [SerializeField] float speed;
    [SerializeField] float speedRun;
    [SerializeField] Vector2 friction = new Vector2(-.1f, 0);
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;
    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKey;
    [Header("Animations")]
    [SerializeField] Animator myAnim;
    [SerializeField] string runVariable = "Run";

    Rigidbody2D  _myRigid;

    void Start() {
        _myRigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        HandleAnimation();
        HandleJump();
        HandleMoviment();
    }

    void HandleAnimation() {
        if (_myRigid.velocity.x != 0) myAnim.SetBool(runVariable, true);
        else myAnim.SetBool(runVariable, false);
    }

    void HandleJump() {
        if (Input.GetKeyDown(jumpKey)) {
            _myRigid.velocity = Vector2.up * jumpForce;
        }
    }

    void HandleMoviment() {
        if (Input.GetKey(rightKey)) {
            _myRigid.velocity = new Vector2(speed, _myRigid.velocity.y);
            Flip(1);
        } else if(Input.GetKey(leftKey)) {
            _myRigid.velocity = new Vector2(-speed, _myRigid.velocity.y);
            Flip(-1);
        }
        HandleFriction();
    }

    void Flip(int scale) {
        transform.DOScaleX(scale, .1f);
    }

    void HandleFriction() {
        if (_myRigid.velocity.x > 0) _myRigid.velocity += friction;
        else if (_myRigid.velocity.x < 0) _myRigid.velocity -= friction;
    }
}
