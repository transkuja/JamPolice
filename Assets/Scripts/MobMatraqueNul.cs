using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobMatraqueNul : Enemy {
    NavMeshAgent agent;
    Animator animator;

    private void Awake()
    {
        sensibleToJump = true;
        sensibleToHit = true;
        sensibleToProjectile = true;
    }
    Vector3 initPosition;

    IEnumerator Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        initPosition = transform.position;

        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            if (agent.isActiveAndEnabled)
                agent.SetDestination(initPosition + Random.insideUnitSphere * 5);
        }
    }

    void Update()
    {
        if (agent != null && animator != null)
            animator.SetFloat("velocity", agent.velocity.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        animator.SetTrigger("giracomoeltopo");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null && other.GetComponentInParent<Enemy>() == null)
        {
            Death();
        }
    }
}
