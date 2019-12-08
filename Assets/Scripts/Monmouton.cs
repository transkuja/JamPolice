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
            FxTaserHit.Play();
            FxTaserLesMoutonsCRigolo.Play();
            sensibleToProjectile = false;
            sensibleToHit = true;
            sensibleToJump = true;
        }
    }


    public void Update()
    {
      if(sensibleToProjectile == false)
        {
           transform.position = (transform.position + ( Random.insideUnitSphere * 0.05f));
        }
    }

    protected override void PlayDeathSound()
    {
        FxTaserLesMoutonsCRigolo.Stop();
        AudioManager audio = FindObjectOfType<AudioManager>();
        audio.PlayOneShot(audio.meeeeeeeeeeh);
    }
}
