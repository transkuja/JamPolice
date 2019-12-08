using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donuts : MonoBehaviour {

    private bool collected = false;
    private bool isInit;
    private float temp = 6.8f;
    private float speed = 500.0F;
    private float startTime;
    private float distance;
    
    void Start () {
        collected = false;
    }
	
	void Update () {
        transform.Rotate(Vector3.forward * 2.0f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() != null && !collected)
        {
            collected = true;
            StartCoroutine(CollectedUpdate(other.GetComponentInParent<PlayerController>()));
        }
    }

    IEnumerator CollectedUpdate(PlayerController _playerRef)
    {
        GetComponent<SphereCollider>().enabled = false;
   
        while (Vector3.Distance(transform.position, GameObject.Find("p").transform.position) > 0.5f)
        {
            if (!isInit)
            {
                distance = Vector3.Distance(transform.position, GameObject.Find("p").transform.position);
                startTime = Time.time;
                isInit = true;
            }

            float DistanceParcouru = ((Time.time - startTime) * speed) * Time.deltaTime;
            float time = (DistanceParcouru / distance);
            transform.position = Vector3.Lerp(transform.position, GameObject.Find("p").transform.position, time);

            yield return new WaitForEndOfFrame();
        }

        GameData.Donutscount++;
            

        gameObject.SetActive(false);

        _playerRef.RefreshUI();
    }
}
