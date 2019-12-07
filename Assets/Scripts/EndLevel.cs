using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    [SerializeField]
    private GameObject Recap;

    [SerializeField]
    private GameObject Player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        { 
            other.GetComponent<PlayerController>().controlsLocked = true;

            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            Recap.SetActive(true);
        }
    }
}