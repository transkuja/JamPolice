using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donuts : MonoBehaviour {
    public static int donutscount = 0;

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
        if(collected)
        {
            CollectedUpdate();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        collected = true;
    }

    void CollectedUpdate()
    {
        GetComponent<SphereCollider>().enabled = false;
   

        if (!isInit)
        {
            distance = Vector3.Distance(transform.position, GameObject.Find("p").transform.position);
            startTime = Time.time;
            isInit = true;
        }

        float DistanceParcouru = ((Time.time - startTime) * speed) * Time.deltaTime;
        float time = (DistanceParcouru / distance);
        transform.position = Vector3.Lerp(transform.position, GameObject.Find("p").transform.position, time);


        if (Vector3.Distance(transform.position, GameObject.Find("p").transform.position) < 0.5f)
        {
            donutscount++;

            if (donutscount >= 100)
            {
                GameData.lives += 1;
                donutscount -= 100;
            }

            gameObject.SetActive(false);
        }

      
    }
}
