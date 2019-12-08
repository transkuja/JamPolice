using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKey : MonoBehaviour {
    public GameObject taser;
    public GameObject matraque;
    public GameObject bulletPrefab;

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

    void SpawnBullet()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, GetComponentInParent<PlayerController>().socket.transform);
        bulletInstance.transform.localPosition = Vector3.zero;
        bulletInstance.transform.localEulerAngles = Vector3.zero;
        Destroy(bulletInstance, 2.0f);
    }

}
