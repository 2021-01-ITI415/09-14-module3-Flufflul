﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager      manager;
    private void Awake() {
        manager = this;
    }

    public AudioSource              mainMusic,
                                    auxMusic,
                                    ambSound,
                                    eventMusic;
    
    public AudioMixerSnapshot       eventSnap,
                                    idleSnap;

    public IEnumerator PlayEventMusic() {
        eventSnap.TransitionTo(0.25f);
        yield return new WaitForSeconds(0.3f);

        eventMusic.Play();
        while (eventMusic.isPlaying) {
            yield return null;
        }
        idleSnap.TransitionTo(0.5f); 
        yield break;
    }
}
