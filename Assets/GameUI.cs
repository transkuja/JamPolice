using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [SerializeField] Text donuts;

    public void RefreshUI()
    {
        UpdateDonuts(GameData.Donutscount);
    }

    public void UpdateDonuts(int _newAmount)
    {
        donuts.text = _newAmount.ToString();
    }
}
