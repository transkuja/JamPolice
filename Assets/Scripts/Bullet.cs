using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody rb;
    public float bulletSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update () {
        rb.velocity = transform.forward * bulletSpeed;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Enemy>() == null && other.GetComponentInParent<PlayerController>() == null)
            Destroy(gameObject);
    }
}
