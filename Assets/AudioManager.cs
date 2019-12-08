using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource fx;
    [SerializeField] AudioSource fx2;

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

    public void PlayFootstepsSound()
    {
        fx2.PlayOneShot(footsteps);
    }
}
