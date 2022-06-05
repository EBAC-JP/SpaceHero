using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour {

    [SerializeField] Player player;

    public void Kill() {
        if (player != null) player.DestroyMe();
    }

}