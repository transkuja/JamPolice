using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKey : MonoBehaviour {

    void EnableRaycast()
    {
        GetComponentInChildren<JumpTrigger>().enabled = true;
    }
}
