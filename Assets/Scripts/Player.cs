using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int coinsPerClick;

    private int totalCoins = 0;
    private Text coinsAmount;

    private void Start()
    {
        this.coinsAmount = GameObject.Find("Coins Amount").GetComponent<Text>();
    }

    private void OnMouseDown()
    {
        this.AddCoins(this.coinsPerClick);
    }

    public void AddCoins(int coins)
    {
        this.totalCoins += coins;
        this.coinsAmount.text = this.totalCoins.ToString();
    }
}
