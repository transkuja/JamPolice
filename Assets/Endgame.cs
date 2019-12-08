using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour {
    public List<GameObject> toSpawn;
    public GameObject felicitations;
    public List<Transform> spawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>())
        {
            PlayerController playerController = FindObjectOfType<PlayerController>();
            playerController.controlsLocked = true;
            GetComponent<Collider>().enabled = false;
            felicitations.SetActive(true);

            if (GameData.Donutscount == 100)
            {
                felicitations.GetComponentInChildren<Text>().text = "Vous avez arrete tous les bandits et reuni tous les donuts !";
                StartCoroutine(EndgameCoroutine());
            }
            else
            {
                felicitations.GetComponentInChildren<Text>().text = "Vous avez arrete tous les bandits !";
                Invoke("BackToMenu", 5.0f);
            }
        }
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator EndgameCoroutine()
    {
        yield return new WaitForSeconds(5.0f);

        while (true)
        {
            foreach (var spawnpoint in spawnPoints)
            {
                GameObject newInstance = Instantiate(toSpawn[Random.Range(0, toSpawn.Count)], spawnpoint);
                newInstance.transform.localPosition = Vector3.zero;
                newInstance.transform.localEulerAngles = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
                Destroy(newInstance, 5.0f);
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
