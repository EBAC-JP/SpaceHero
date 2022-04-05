using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Moviments")]
    [SerializeField] float speed;
    [SerializeField] float speedRun;
    [SerializeField] Vector2 friction = new Vector2(-.1f, 0);
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode runningKey;
    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKey;

    Rigidbody2D  _myRigid;
    bool _isRunning = false;

    void Start() {
        _myRigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        HandleJump();
        HandleMoviment();
    }

    void HandleJump() {
        if (Input.GetKeyDown(jumpKey)) {
            _myRigid.velocity = Vector2.up * jumpForce;
        }
    }

    void HandleMoviment() {
        _isRunning = Input.GetKey(runningKey);
        if (Input.GetKey(rightKey)) {
            _myRigid.velocity = new Vector2(!_isRunning ? speed : speedRun, _myRigid.velocity.y);
        } else if(Input.GetKey(leftKey)) {
            _myRigid.velocity = new Vector2(!_isRunning ? -speed : -speedRun, _myRigid.velocity.y);
        }
        HandleFriction();
    }

    void HandleFriction() {
        if (_myRigid.velocity.x > 0) _myRigid.velocity += friction;
        else if (_myRigid.velocity.x < 0) _myRigid.velocity -= friction;
    }
}
