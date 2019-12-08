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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Bullet>() != null)
        {
            sensibleToProjectile = false;
            sensibleToHit = true;
            sensibleToJump = true;
        }
    }

   

    public void Update()
    {
      

    }

}
