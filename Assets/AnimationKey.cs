using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKey : MonoBehaviour {
    public GameObject taser;
    public GameObject matraque;

    void EnableRaycast()
    {
        GetComponentInChildren<JumpTrigger>().enabled = true;
    }

    void EnableGun()
    {
        taser.SetActive(true);
    }

    void EnableMatraque()
    {
        matraque.SetActive(true);
    }

    void ReleasePlayer()
    {
        GetComponentInParent<PlayerController>().isFiring = false;
        GetComponentInParent<PlayerController>().controlsLocked = false;
        taser.SetActive(false);
    }

    void DisableMatraque()
    {
        GetComponentInParent<PlayerController>().isGiraing = false;
        matraque.SetActive(false);
    }

}
