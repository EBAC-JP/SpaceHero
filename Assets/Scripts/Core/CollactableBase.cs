using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollactableBase : MonoBehaviour {

    [SerializeField] string targetTag;
    protected virtual void Collect() {}
    protected virtual void OnCollect() {}

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag(targetTag)) {
            Collect();
        }
    }
}
