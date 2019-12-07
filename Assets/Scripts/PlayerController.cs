﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    Rigidbody rb;
    public Animator animator;
    [SerializeField] float accelerationFactor;
    [SerializeField] float maxSpeed;
    [SerializeField] float pietinementThreshold;
    [SerializeField] float jumpForce;
    public bool isJumping = false;
    public bool isAttacking = false;

    public bool controlsLocked = false;
    public GameObject visual;

    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        GameData.Reset();
    }
	
	void Update () {
        if (!isJumping && !controlsLocked)
        {
            Jump();
            MovePlayer();
            animator.SetFloat("velocity", rb.velocity.magnitude);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
            isJumping = true;
            GetComponentInChildren<JumpTrigger>().enabled = false;
        }
    }


    void MovePlayer()
    {
        transform.LookAt(transform.position 
            + Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * Input.GetAxisRaw("Vertical")
            + Camera.main.transform.right * Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") > 0.1f ||
                Input.GetAxisRaw("Horizontal") < -0.1f ||
                Input.GetAxisRaw("Vertical") > 0.1f ||
                Input.GetAxisRaw("Vertical") < -0.1f)
        {
            if (rb.velocity.magnitude < pietinementThreshold)
                rb.AddForce(transform.forward * accelerationFactor);
            else
                rb.velocity = transform.forward * maxSpeed;
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    public void Respawn()
    {
        StartCoroutine(RespawnProcess());
    }

    IEnumerator RespawnProcess()
    {
        visual.SetActive(false);
        rb.isKinematic = true;
        rb.useGravity = false;
        yield return new WaitForSeconds(1.0f);
        if (GameData.currentCheckpoint == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            transform.position = GameData.currentCheckpoint.transform.position;
            visual.SetActive(true);
            rb.isKinematic = false;
            rb.useGravity = true;
            controlsLocked = false;
        }
    }
}
