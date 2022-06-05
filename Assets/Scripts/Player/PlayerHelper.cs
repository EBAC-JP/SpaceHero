using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour {

    [SerializeField] Player player;
    [Header("Audio")]
    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] List<AudioSource> audioSources;

    enum SoundActions {
        Walk,
        Jump,
        Shoot
    }

    public void Kill() {
        if (player != null) player.DestroyMe();
    }

    public void WalkSFX() {
        int index = (int)SoundActions.Walk;
        audioSources[index].clip = audioClips[index];
        if (player.IsGrounded()) audioSources[index].Play();
    }

    public void JumpSFX() {
        int index = (int)SoundActions.Jump;
        audioSources[index].clip = audioClips[index];
        audioSources[index].Play();
    }

}