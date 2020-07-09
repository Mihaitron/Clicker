using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Player
    [Header("Player")]
    public float coinsPerClick;

    private float totalCoins = 0;
    private Text coinsAmount;

    public void AddCoins(float coins)
    {
        this.totalCoins += coins;
        this.coinsAmount.text = this.totalCoins.ToString("F1");
    }

    public void SubtractCoins(float coins)
    {
        this.totalCoins -= coins;
        this.coinsAmount.text = this.totalCoins.ToString("F1");
    }

    private IEnumerator AddCoinsPerSecond()
    {
        float clicker_coins = this.numberOfClickers * this.clickerProduction;
        float fast_clicker_coins = this.numberOfFastClickers * this.fastClickerProduction;
        float total_coins_to_add = clicker_coins + fast_clicker_coins;

        this.AddCoins(total_coins_to_add);

        yield return new WaitForSeconds(1);

        StartCoroutine(this.AddCoinsPerSecond());
    }
    #endregion

    #region Clicker
    [Header("Clicker")]
    public float clickerProduction = 0.1f;

    private float clickerBaseCost = 15;
    private int numberOfClickers = 0;

    public void BuyClicker()
    {
        int clicker_cost = this.calculateCost(this.clickerBaseCost, this.numberOfClickers);

        if (this.totalCoins >= clicker_cost)
        {
            this.SubtractCoins(clicker_cost);
            this.numberOfClickers++;

            Debug.Log("You now have " + this.numberOfClickers + " clickers for " + clicker_cost);

            float new_cost = this.calculateCost(this.clickerBaseCost, this.numberOfClickers);

            GameObject.Find("BuyClickers").transform.GetChild(1).gameObject.GetComponent<Text>().text = new_cost.ToString() + " coins";
        }
    }
    #endregion

    #region Fast Clicker
    [Header("FastClicker")]
    public float fastClickerProduction = 1f;


    private float fastClickerBaseCost = 100;
    private int numberOfFastClickers = 0;

    public void BuyFastClicker()
    {
        int fast_clicker_cost = this.calculateCost(this.fastClickerBaseCost, this.numberOfFastClickers);

        if (this.totalCoins >= fast_clicker_cost)
        {
            this.SubtractCoins(fast_clicker_cost);
            this.numberOfFastClickers++;

            Debug.Log("You now have " + this.numberOfFastClickers + " fast clickers for " + fast_clicker_cost);

            float new_cost = this.calculateCost(this.fastClickerBaseCost, this.numberOfFastClickers);

            GameObject.Find("BuyFastClickers").transform.GetChild(1).gameObject.GetComponent<Text>().text = new_cost.ToString() + " coins";
        }
    }
    #endregion

    private void Start()
    {
        this.coinsAmount = GameObject.Find("Coins Amount").GetComponent<Text>();

        GameObject.Find("BuyClickers").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.clickerBaseCost.ToString() + " coins";
        GameObject.Find("BuyFastClickers").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.fastClickerBaseCost.ToString() + " coins";

        StartCoroutine(this.AddCoinsPerSecond());
    }

    private void OnMouseDown()
    {
        this.AddCoins(this.coinsPerClick);
    }

    private int calculateCost(float base_cost, float number)
    {
        return (int)(base_cost * Mathf.Pow(1.15f, number));
    }
}
