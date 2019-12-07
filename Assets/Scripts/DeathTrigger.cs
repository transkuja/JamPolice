using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerController>() != null ||
            collision.collider.GetComponentInParent<PlayerController>() != null ||
            collision.collider.GetComponentInChildren<PlayerController>() != null)
        {
            if (GetComponent<Enemy>() != null)
            {
                PlayerController player = FindObjectOfType<PlayerController>();
                if (player.isJumping
                    && Vector3.Dot(collision.contacts[0].normal, Vector3.up) > 0.5f
                    && GetComponent<Enemy>().sensibleToJump)
                {
                    GetComponent<Enemy>().Death();
                    return;
                }

                if (player.isAttacking && GetComponent<Enemy>().sensibleToHit)
                {
                    GetComponent<Enemy>().Death();
                    return;
                }

                if (GameData.hasImmunity)
                {
                    GameData.hasImmunity = false;
                    // TODO remove feedback
                    return;
                }
            }

            StartCoroutine(Death());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null || 
                other.GetComponentInParent<PlayerController>() != null || 
                other.GetComponentInChildren<PlayerController>() != null)
        {
            if (GetComponent<Enemy>() != null)
            {
                PlayerController player = FindObjectOfType<PlayerController>();
                if (player.isJumping && GetComponent<Enemy>().sensibleToJump)
                {
                    GetComponent<Enemy>().Death();
                    return;
                }

                if (player.isAttacking && GetComponent<Enemy>().sensibleToHit)
                {
                    GetComponent<Enemy>().Death();
                    return;
                }

                if (GameData.hasImmunity)
                {
                    GameData.hasImmunity = false;
                    // TODO remove feedback
                    return;
                }
            }

            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        // Anim death
        PlayerController player = FindObjectOfType<PlayerController>();
        player.Death();

        yield return new WaitForSeconds(1.0f);
        if (GameData.lives == 0)
        {
            GameData.lives = 3;
            Donuts.donutscount = 0;
            GameData.currentCheckpoint = null;
            SceneManager.LoadScene("Menu");
        }
        else
        {
            GameData.Respawn();
            player.Respawn();
        }
        // Fade in/out ?
        // Respawn
    }
}
