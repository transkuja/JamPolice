using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody rb;
    [SerializeField] float accelerationFactor;
    [SerializeField] float maxSpeed;
    [SerializeField] float pietinementThreshold;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        Jump();
        MovePlayer();

    }

    void Jump()
    {

    }

    void MovePlayer()
    {
        transform.LookAt(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));

        if (Input.GetAxisRaw("Horizontal") > 0.1f ||
                Input.GetAxisRaw("Horizontal") < -0.1f ||
                Input.GetAxisRaw("Vertical") > 0.1f ||
                Input.GetAxisRaw("Vertical") < -0.1f)
        {
            if (rb.velocity.magnitude < pietinementThreshold)
                rb.AddForce(transform.forward * accelerationFactor);

            else
                rb.velocity = transform.forward * maxSpeed;

            //Debug.Log(rb.velocity.magnitude);
            //if (rb.velocity.magnitude < pietinementThreshold)
            //{
            //    Debug.Log("lol");
            //    rb.AddForce(transform.forward * accelerationFactor);
            //}
            //else
            //{
            //    rb.velocity = transform.forward * maxSpeed;
            //}
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
