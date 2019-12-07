using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool sensibleToJump;
    public bool sensibleToHit;
    public bool sensibleToProjectile;

    public void Death()
    {
        //StartCoroutine(EnemyDeath());
        gameObject.SetActive(false);
    }

    //IEnumerator EnemyDeath()
    //{
    //    // fx
    //    // disappear
    //}
}
