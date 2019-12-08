using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    public Monmouton mymouton;
    public bool paralizeInit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            mymouton.myAnimator.SetBool("Run", true);
            other.GetComponent<PlayerController>().audio.PlayOneShot(other.GetComponent<PlayerController>().audio.meeeeeeeeeeh);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (mymouton.sensibleToProjectile != false)
        {
            if (mymouton.agent.enabled)
                mymouton.agent.SetDestination(other.transform.position);
            mymouton.myAnimator.SetBool("Run", true);
        }
        else
        {
            if (!paralizeInit)
            {
                mymouton.agent.isStopped = true;
                mymouton.agent.velocity = Vector3.zero;
                paralizeInit = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        mymouton.myAnimator.SetBool("Run", false);

    }
}
