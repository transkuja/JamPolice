using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monmouton : Enemy {

    public NavMeshAgent agent;
    public Animator myAnimator;
   
	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponentInChildren<Animator>();
        sensibleToProjectile = true;
        sensibleToHit = false;
        sensibleToJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            sensibleToProjectile = false;
            sensibleToHit = true;
            sensibleToJump = true;
        }
    }


    public void Update()
    {
      

    }

    protected override void PlayDeathSound()
    {
        AudioManager audio = FindObjectOfType<AudioManager>();
        audio.PlayOneShot(audio.meeeeeeeeeeh);
    }
}
