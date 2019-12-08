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

}
