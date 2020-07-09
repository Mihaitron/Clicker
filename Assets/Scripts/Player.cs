using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Player
    [Header("Player")]
    public double coinsPerClick;

    private double totalCoins = 0;
    private Text coinsAmount;

    public void AddCoins(double coins)
    {
        this.totalCoins += coins;
        this.SetCoinsText();
    }

    public void SubtractCoins(double coins)
    {
        this.totalCoins -= coins;
        this.SetCoinsText();
    }

    private void SetCoinsText()
    {
        if (this.totalCoins < Math.Pow(10, 3))
            this.coinsAmount.text = this.totalCoins.ToString("F1");
        else if (this.totalCoins < Math.Pow(10, 6))
            this.coinsAmount.text = string.Format("{0:#.00}K", this.totalCoins / Math.Pow(10, 3));
        else if (this.totalCoins < Math.Pow(10, 9))
            this.coinsAmount.text = string.Format("{0:#.00}M", this.totalCoins / Math.Pow(10, 6));
        else if (this.totalCoins < Math.Pow(10, 12))
            this.coinsAmount.text = string.Format("{0:#.00}B", this.totalCoins / Math.Pow(10, 9));
        else if (this.totalCoins < Math.Pow(10, 15))
            this.coinsAmount.text = string.Format("{0:#.00}T", this.totalCoins / Math.Pow(10, 12));
        else if (this.totalCoins < Math.Pow(10, 18))
            this.coinsAmount.text = string.Format("{0:#.00}Qa", this.totalCoins / Math.Pow(10, 15));
        else if (this.totalCoins < Math.Pow(10, 21))
            this.coinsAmount.text = string.Format("{0:#.00}Qt", this.totalCoins / Math.Pow(10, 18));
        else if (this.totalCoins < Math.Pow(10, 24))
            this.coinsAmount.text = string.Format("{0:#.00}Sx", this.totalCoins / Math.Pow(10, 21));
        else if (this.totalCoins < Math.Pow(10, 27))
            this.coinsAmount.text = string.Format("{0:#.00}Sp", this.totalCoins / Math.Pow(10, 24));
        else if (this.totalCoins < Math.Pow(10, 30))
            this.coinsAmount.text = string.Format("{0:#.00}Oc", this.totalCoins / Math.Pow(10, 27));
        else if (this.totalCoins < Math.Pow(10, 33))
            this.coinsAmount.text = string.Format("{0:#.00}No", this.totalCoins / Math.Pow(10, 30));
        else if (this.totalCoins < Math.Pow(10, 34))
            this.coinsAmount.text = string.Format("{0:#.00}Dc", this.totalCoins / Math.Pow(10, 33));
        else
        {
            int power = 34;
            double coins = this.totalCoins / Math.Pow(10, power);

            while (((int)coins) / 10 != 0)
            {
                coins /= 10.0;
                power++;
            }

            this.coinsAmount.text = string.Format("{0:#.00}e{1}", coins, power);
        }
    }

    private IEnumerator AddCoinsPerSecond()
    {
        double clicker_coins = this.numberOfClickers * this.clickerProduction;
        double fast_clicker_coins = this.numberOfFastClickers * this.fastClickerProduction;
        double total_coins_to_add = clicker_coins + fast_clicker_coins;

        this.AddCoins(total_coins_to_add);

        yield return new WaitForSeconds(1);

        StartCoroutine(this.AddCoinsPerSecond());
    }
    #endregion

    #region Clicker
    [Header("Clicker")]
    public double clickerProduction = 0.1f;

    private long clickerBaseCost = 15;
    private int numberOfClickers = 0;

    public void BuyClicker()
    {
        long clicker_cost = this.calculateCost(this.clickerBaseCost, this.numberOfClickers);

        if (this.totalCoins >= clicker_cost)
        {
            this.SubtractCoins(clicker_cost);
            this.numberOfClickers++;

            Debug.Log("You now have " + this.numberOfClickers + " clickers for " + clicker_cost);

            long new_cost = this.calculateCost(this.clickerBaseCost, this.numberOfClickers);

            GameObject.Find("BuyClickers").transform.GetChild(1).gameObject.GetComponent<Text>().text = new_cost.ToString() + " coins";
        }
    }
    #endregion

    #region Fast Clicker
    [Header("FastClicker")]
    public double fastClickerProduction = 1f;


    private long fastClickerBaseCost = 100;
    private int numberOfFastClickers = 0;

    public void BuyFastClicker()
    {
        long fast_clicker_cost = this.calculateCost(this.fastClickerBaseCost, this.numberOfFastClickers);

        if (this.totalCoins >= fast_clicker_cost)
        {
            this.SubtractCoins(fast_clicker_cost);
            this.numberOfFastClickers++;

            Debug.Log("You now have " + this.numberOfFastClickers + " fast clickers for " + fast_clicker_cost);

            long new_cost = this.calculateCost(this.fastClickerBaseCost, this.numberOfFastClickers);

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

    private long calculateCost(long base_cost, int number)
    {
        return (long)(base_cost * Math.Pow(1.15f, number));
    }
}
