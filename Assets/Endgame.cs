using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour {

    public GameObject endgameMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>())
        {
            PlayerController playerController = FindObjectOfType<PlayerController>();
            playerController.controlsLocked = true;
            endgameMenu.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }
    }

}
