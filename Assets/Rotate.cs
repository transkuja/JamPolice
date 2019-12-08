using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	void Update () {
        transform.Rotate(Vector3.forward * (Time.deltaTime * 200.0f));
	}
}
