using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donutsCount : MonoBehaviour {

    public List<GameObject> list;

	// Use this for initialization
	void Start () {
		foreach(Transform go in transform)
        {
            list.Add(go.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
