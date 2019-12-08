using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public bool sensibleToJump;
    public bool sensibleToHit;
    public bool sensibleToProjectile;
    public GameObject ragdoll;
    public GameObject visual;
    GameObject ragdollInstance;
    public ParticleSystem FxHit;
    public ParticleSystem FxTaserHit;
    public ParticleSystem FxTaserLesMoutonsCRigolo;
    public void Death()
    {
        GetComponent<DeathTrigger>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;
        if (ragdollInstance == null)
        {
            PlayDeathSound();

            //StartCoroutine(EnemyDeath());
            visual.SetActive(false);
            ragdollInstance = GameObject.Instantiate(ragdoll);
            ragdollInstance.transform.position = transform.position;

            ragdollInstance.GetComponent<Rigidbody>().AddForce(FindObjectOfType<PlayerController>().transform.forward, ForceMode.Impulse);
            Destroy(ragdollInstance, 10.0f);
        }
    }

    protected virtual void PlayDeathSound()
    {
        AudioManager audio = FindObjectOfType<AudioManager>();
        audio.PlayOneShot(audio.enemyDeath);
    }
    //IEnumerator EnemyDeath()
    //{
    //    // fx
    //    // disappear
    //}
}
