using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public Animator animator;
    [SerializeField] float accelerationFactor;
    [SerializeField] float maxSpeed;
    [SerializeField] float pietinementThreshold;
    [SerializeField] float jumpForce;
    public bool isJumping = false;
    public bool isAttacking = false;
    public bool isFiring = false;
    public bool isGiraing = false;

    public bool controlsLocked = false;
    public GameObject visual;
    public GameObject ragdoll;
    public GameUI uiRef;

    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        if (uiRef == null)
            uiRef = FindObjectOfType<GameUI>();

        GameData.Reset();
        RefreshUI();
    }

    void Update () {
        if (!controlsLocked)
        {
            if (!isJumping)
            {
                Jump();
                animator.SetFloat("velocity", rb.velocity.magnitude);
            }

            if (!isFiring)
            {
                Taser();
            }
            MovePlayer();
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
            isJumping = true;
            GetComponentInChildren<JumpTrigger>().enabled = false;
            rb.drag = 0.0f;
        }
    }


    void MovePlayer()
    {
        transform.GetChild(0).LookAt(transform.GetChild(0).position 
            + Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * Input.GetAxisRaw("Vertical")
            + Camera.main.transform.right * Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") > 0.1f ||
                Input.GetAxisRaw("Horizontal") < -0.1f ||
                Input.GetAxisRaw("Vertical") > 0.1f ||
                Input.GetAxisRaw("Vertical") < -0.1f)
        {
            if (rb.velocity.magnitude < pietinementThreshold)
                rb.AddForce(transform.GetChild(0).forward * accelerationFactor / ((isJumping) ? 1.2f : 1));
            else
                rb.velocity = transform.GetChild(0).forward * maxSpeed / ((isJumping) ? 1.2f : 1);
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed / ((isJumping) ? 1.2f : 1));
    }

    public void Respawn()
    {
        StartCoroutine(RespawnProcess());
    }

    IEnumerator RespawnProcess()
    {
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

    public void Death()
    {
        controlsLocked = true;
        GameData.Lives--;
        RefreshUI();
        visual.SetActive(false);
        ragdollInstance = GameObject.Instantiate(ragdoll);
        ragdollInstance.transform.position = transform.position;
        ragdollInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 100.0f, ForceMode.Impulse);
        Destroy(ragdollInstance, 10.0f);
    }

    GameObject ragdollInstance = null;

    public void RefreshUI()
    {
        uiRef.RefreshUI();
    }

    void Taser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            controlsLocked = true;
            animator.SetTrigger("taser");
            isFiring = true;
        }
    }

    void ElFoxoQueGira()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isGiraing = true;
        }
    }

}
