using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donuts : MonoBehaviour {
    static int donutscount = 0;

	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(Vector3.up * 2.0f);
	}

    private void OnTriggerEnter(Collider other)
    {
        donutscount++;
        gameObject.SetActive(false);
    }
}
