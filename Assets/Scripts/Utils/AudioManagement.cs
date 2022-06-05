using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagement : MonoBehaviour {

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] string groupName;

    public void ChangeVolume(float volume) {
        audioMixer.SetFloat(groupName, volume);
    }

}
