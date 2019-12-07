using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Button buttonPlay;

    [SerializeField]
    private Button buttonCredit;

    [SerializeField]
    private Button buttonQuit;

    [SerializeField]
    private GameObject goCredit;

    private void Start()
    {
        buttonPlay.onClick.AddListener(Play);
        buttonCredit.onClick.AddListener(Credit);
        buttonQuit.onClick.AddListener(Quitter);
    }

    public void Play()
    {
       SceneManager.LoadScene(0);
    }

    public void Credit()
    {
        goCredit.SetActive(true);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
