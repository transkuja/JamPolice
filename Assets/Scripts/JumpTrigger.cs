using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour {
    [SerializeField] float raycastSize;
    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, raycastSize))
        {
            GetComponentInParent<PlayerController>().isJumping = false;
            GetComponentInParent<PlayerController>().animator.SetBool("jump", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponentInParent<PlayerController>() == null) // si pas le joueur
        //{
        //    GetComponentInParent<PlayerController>().isJumping = false;
        //    GetComponentInParent<PlayerController>().animator.SetBool("jump", false);
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (raycastSize * Vector3.down));
    }
}
