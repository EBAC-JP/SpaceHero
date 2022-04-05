using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Moviments")]
    [SerializeField] float speed;
    [SerializeField] KeyCode leftMoviment;
    [SerializeField] KeyCode rigthMoviment;

    Rigidbody2D  _myRigid;

    void Start() {
        _myRigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKey(rigthMoviment)) {
            _myRigid.velocity = new Vector2(speed, _myRigid.velocity.y);
        } else if(Input.GetKey(leftMoviment)) {
            _myRigid.velocity = new Vector2(-speed, _myRigid.velocity.y);
        }
    }
}
