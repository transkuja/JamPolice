using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [SerializeField] Text lives;
    [SerializeField] Text donuts;

    public void RefreshUI()
    {
        UpdateLives(GameData.Lives);
        UpdateDonuts(GameData.Donutscount);
    }

    public void UpdateLives(int _newAmount)
    {
        lives.text = _newAmount.ToString();
    }

    public void UpdateDonuts(int _newAmount)
    {
        donuts.text = _newAmount.ToString();
    }
}
