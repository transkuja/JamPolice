using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    bool hasBeenActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenActivated)
        {
            GameData.currentCheckpoint = this;
            hasBeenActivated = true;
        }
    }
}
