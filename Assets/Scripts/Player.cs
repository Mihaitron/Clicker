using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Player
    [Header("Player")]
    public float coinsPerClick;

    private float totalCoins = 0f;
    private Text coinsAmount;

    public void AddCoins(float coins)
    {
        this.totalCoins += coins;
        this.coinsAmount.text = this.totalCoins.ToString();
    }

    public void SubtractCoins(float coins)
    {
        this.totalCoins -= coins;
        this.coinsAmount.text = this.totalCoins.ToString();
    }

    private IEnumerator AddCoinsPerSecond()
    {
        float clicker_coins = this.numberOfClickers * this.clickerProduction;
        float total_coins_to_add = clicker_coins;

        this.AddCoins(total_coins_to_add);

        yield return new WaitForSeconds(1);

        StartCoroutine(this.AddCoinsPerSecond());
    }
    #endregion

    #region Clicker
    [Header("Clicker")]
    public float clickerProduction = 0.5f;

    private float clickerBaseCost = 10;
    private int numberOfClickers = 0;

    public void BuyClicker()
    {
        float clicker_cost = this.clickerBaseCost * (this.numberOfClickers + 1) + this.numberOfClickers;

        if (this.totalCoins >= clicker_cost)
        {
            this.SubtractCoins(clicker_cost);
            this.numberOfClickers++;

            Debug.Log("You now have " + this.numberOfClickers + " clickers");

            float new_cost = this.clickerBaseCost * (this.numberOfClickers + 1) + this.numberOfClickers;

            GameObject.Find("BuyClickers").transform.GetChild(1).gameObject.GetComponent<Text>().text = new_cost.ToString() + " coins";
        }
    }
    #endregion

    private void Start()
    {
        this.coinsAmount = GameObject.Find("Coins Amount").GetComponent<Text>();

        StartCoroutine(this.AddCoinsPerSecond());
    }

    private void OnMouseDown()
    {
        this.AddCoins(this.coinsPerClick);
    }
}
