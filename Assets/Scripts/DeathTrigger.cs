using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null || 
                other.GetComponentInParent<PlayerController>() != null || 
                other.GetComponentInChildren<PlayerController>() != null)
        {
            if (GetComponent<Enemy>() != null)
            {
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
        player.controlsLocked = true;
        player.GetComponentInChildren<Animator>().SetTrigger("death");
        yield return new WaitForSeconds(1.0f);
        GameData.Respawn();
        player.Respawn();
        // Fade in/out ?
        // Respawn
    }
}
