using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public Animator animator;
    [SerializeField] float accelerationFactor;
    [SerializeField] float maxSpeed;
    [SerializeField] float pietinementThreshold;
    [SerializeField] float jumpForce;
    public bool isJumping = false;
    public bool isFiring = false;
    public bool isGiraing = false;

    public bool controlsLocked = false;
    public GameObject visual;
    public GameObject ragdoll;
    public GameUI uiRef;
    public BulletSocket socket;
    public AudioManager audio;

    public ParticleSystem FxFoxoQueGira;
    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        if (uiRef == null)
            uiRef = FindObjectOfType<GameUI>();
        if (audio == null)
            audio = FindObjectOfType<AudioManager>();

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

            if (!isFiring && !isGiraing && !isJumping)
            {
                Taser();
            }

            if (!isGiraing)
            {
                ElFoxoQueGira();
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
            audio.PlayOneShot(audio.jump);
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

    public void Death(bool _fromTaser = false)
    {
        controlsLocked = true;
        RefreshUI();
        visual.SetActive(false);
        ragdollInstance = GameObject.Instantiate(ragdoll);
        ragdollInstance.transform.position = transform.position;
        ragdollInstance.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
        if (_fromTaser)
            ragdollInstance.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        Destroy(ragdollInstance, 10.0f);

        audio.PlayOneShot(audio.gameover);
    }

    GameObject ragdollInstance = null;

    public void RefreshUI()
    {
        uiRef.RefreshUI();
    }

    void Taser()
    {
        if (Input.GetButtonDown("Fire2"))
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
            FxFoxoQueGira.Play();
            isGiraing = true;
            audio.PlayOneShot(audio.matraqueSwift);
            animator.SetTrigger("giracomoeltopo");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null && other.GetComponentInParent<PlayerController>() == null)
        {
            Death(true);
            StartCoroutine(DeathCotourine());
        }
    }

    IEnumerator DeathCotourine()
    {
        yield return new WaitForSeconds(1.0f);
        GameData.Donutscount = 0;
        GameData.currentCheckpoint = null;

        GameData.Respawn();
        Respawn();
    }

}
