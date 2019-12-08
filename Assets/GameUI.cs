using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    [SerializeField] Text donuts;
    [SerializeField] GameObject pauseMenu;

    public bool activePause = false;

    public void RefreshUI()
    {
        UpdateDonuts(GameData.Donutscount);
    }

    public void UpdateDonuts(int _newAmount)
    {
        donuts.text = _newAmount.ToString();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!activePause)
            {
                Time.timeScale = 0.0f;
                GameObject.Find("NewPlayer").GetComponent<PlayerController>().enabled = false;
                pauseMenu.SetActive(true);
                activePause = true;
            }
            else
            {
                Time.timeScale = 1.0f;
                GameObject.Find("NewPlayer").GetComponent<PlayerController>().enabled = true;
                pauseMenu.SetActive(false);
                activePause = false;

            }
        }
    }

    public void ButtonResume()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("NewPlayer").GetComponent<PlayerController>().enabled = true;
        pauseMenu.SetActive(false);
        activePause = false;
    }

    public void ButtonMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

}
