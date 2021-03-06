﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private bool playAudio;
    private AudioSource audioSource;
    public AudioClip audioClip;
    private string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponentInParent<AudioSource>();
        if (audioClip != null)
        {
            audioClip.LoadAudioData();
            playAudio = true;
        }
        else
        {
            playAudio = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene(string scene)
    {
        sceneToLoad = scene;

        if (playAudio)
        {
            audioSource.PlayOneShot(audioClip);
            Invoke("changeScene", audioClip.length);
        }
        else
        {
            changeScene();
        }
        
    }

    private void changeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
