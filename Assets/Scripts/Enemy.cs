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

    public void Death()
    {
        if (ragdollInstance == null)
        {
            //StartCoroutine(EnemyDeath());
            GetComponent<DeathTrigger>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            visual.SetActive(false);
            ragdollInstance = GameObject.Instantiate(ragdoll);
            ragdollInstance.transform.position = transform.position;

            ragdollInstance.GetComponent<Rigidbody>().AddForce(FindObjectOfType<PlayerController>().transform.forward, ForceMode.Impulse);
            Destroy(ragdollInstance, 10.0f);
        }
    }

    //IEnumerator EnemyDeath()
    //{
    //    // fx
    //    // disappear
    //}
}
