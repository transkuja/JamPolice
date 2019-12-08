using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour {
    [SerializeField] float raycastSize;
    PlayerController player;
    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }
    RaycastHit hit;

    private void Update()
    {
        if (player.isJumping)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastSize))
            {
                player.isJumping = false;
                player.animator.SetTrigger("stopjump");
                player.rb.drag = 5.0f;
            }
        }
        //else
        //{
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, raycastSize))
        {
            player.rb.AddForce(Vector3.down * 10.0f, ForceMode.Impulse);
            player.audio.PlayOneShot(player.audio.fall);
        }
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponentInParent<Enemy>() == null)
        //{
        //    if (other.GetComponentInParent<Enemy>().sensibleToJump)
        //        other.GetComponentInParent<Enemy>().Death();
        //}

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
