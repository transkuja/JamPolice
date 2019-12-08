﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobTaser : Enemy {
    Animator animator;
    PlayerController player;
    public BulletSocket socket;

    private void Awake()
    {
        sensibleToJump = false;
        sensibleToHit = true;
        sensibleToProjectile = false;
    }

    IEnumerator Start()
    {
        animator = GetComponentInChildren<Animator>();
        player = FindObjectOfType<PlayerController>();
        yield return new WaitForSeconds(Random.Range(0.0f, 2.0f));

        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            Shoot();
        }
    }

    void Update()
    {
        transform.LookAt(player.transform);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    void Shoot()
    {
        animator.SetTrigger("taser");
    }

}
