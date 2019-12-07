using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() == null) // si pas le joueur
        {
            GetComponentInParent<PlayerController>().isJumping = false;
            GetComponentInParent<PlayerController>().animator.SetBool("jump", false);
        }
    }
}
