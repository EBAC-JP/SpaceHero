using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Moviments")]
    [SerializeField] float speed;
    [SerializeField] Vector2 friction = new Vector2(-.1f, 0);
    [SerializeField] KeyCode leftMoviment;
    [SerializeField] KeyCode rigthMoviment;
    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKey;

    Rigidbody2D  _myRigid;

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
        if (Input.GetKey(rigthMoviment)) {
            _myRigid.velocity = new Vector2(speed, _myRigid.velocity.y);
        } else if(Input.GetKey(leftMoviment)) {
            _myRigid.velocity = new Vector2(-speed, _myRigid.velocity.y);
        }
        HandleFriction();
    }

    void HandleFriction() {
        if (_myRigid.velocity.x > 0) _myRigid.velocity += friction;
        else if (_myRigid.velocity.x < 0) _myRigid.velocity -= friction;
    }
}
