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

    public AudioClip menuButton;

    private void Start()
    {
        buttonPlay.onClick.AddListener(Play);
        buttonCredit.onClick.AddListener(Credit);
        buttonQuit.onClick.AddListener(Quitter);
    }

    public void Play()
    {
        GetComponent<AudioSource>().PlayOneShot(menuButton);
        SceneManager.LoadScene(1);
    }

    public void Credit()
    {
        GetComponent<AudioSource>().PlayOneShot(menuButton);
        goCredit.SetActive(true);
    }

    public void Quitter()
    {
        GetComponent<AudioSource>().PlayOneShot(menuButton);
        Application.Quit();
    }
}
