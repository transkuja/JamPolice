using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    public Monmouton mymouton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            print("Coucou");
            mymouton.myAnimator.SetBool("Run", true);
            other.GetComponent<PlayerController>().audio.PlayOneShot(other.GetComponent<PlayerController>().audio.meeeeeeeeeeh);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        print("Yolooo");
        if (mymouton.agent.enabled)
            mymouton.agent.SetDestination(other.transform.position);

    }
    private void OnTriggerExit(Collider other)
    {
        mymouton.myAnimator.SetBool("Run", false);
        print("Au revoir");
    }
}
