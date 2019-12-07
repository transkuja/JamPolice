using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    static int count = 0;

	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(Vector3.up * 2.0f);
	}

    private void OnTriggerEnter(Collider other)
    {
        count++;
        gameObject.SetActive(false);
    }
}
