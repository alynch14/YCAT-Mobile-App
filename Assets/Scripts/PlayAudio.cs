using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponentInParent<AudioSource>();
        audioClip.LoadAudioData();
    }

    public void PlayAudioNow()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
