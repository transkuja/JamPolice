using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource fx;

    public AudioClip matraqueHit; // ok
    public AudioClip matraqueSwift; // ok
    public AudioClip enemyDeath; // ok
    public AudioClip collect; // ok
    public AudioClip fall; // ok
    public AudioClip footsteps;
    public AudioClip gameover; // ok
    public AudioClip taserHit; // ok
    public AudioClip jump; // ok
    public AudioClip menuButton;
    public AudioClip meeeeeeeeeeh; // ok

    public void PlayOneShot(AudioClip clip)
    {
        fx.PlayOneShot(clip);
    }
}
