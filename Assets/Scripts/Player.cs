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
    private Text coinsPerSecond;

    public void AddCoins(double coins)
    {
        this.totalCoins += coins;
        this.coinsAmount.text = this.FormatCoinsText(this.totalCoins);
    }

    public void SubtractCoins(double coins)
    {
        this.totalCoins -= coins;
        this.coinsAmount.text = this.FormatCoinsText(this.totalCoins);
    }

    private IEnumerator AddCoinsPerSecond()
    {
        double clicker_coins = this.numberOfClickers * this.clickerProduction;
        double fast_clicker_coins = this.numberOfFastClickers * this.fastClickerProduction;
        double clicker_assembly_coins = this.numberOfClickerAssemblies * this.clickerAssemblyProduction;
        double clicker_factory_coins = this.numberOfClickerFactories * this.clickerFactoryProduction;
        double clicker_university_coins = this.numberOfClickerUniversities * this.clickerUniversityProduction;
        double total_coins_to_add = clicker_coins + 
                                     fast_clicker_coins + 
                                     clicker_assembly_coins + 
                                     clicker_factory_coins + 
                                     clicker_university_coins;

        this.coinsPerSecond.text = this.FormatCoinsText(total_coins_to_add) + " clicks/s";
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

            GameObject.Find("BuyClicker").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
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

            GameObject.Find("BuyFastClicker").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    #region Clicker Assembly
    [Header("ClickerAssembly")]
    public double clickerAssemblyProduction = 8f;


    private long clickerAssemblyBaseCost = 1100;
    private int numberOfClickerAssemblies = 0;

    public void BuyClickerAssembly()
    {
        long clicker_assembly_cost = this.calculateCost(this.clickerAssemblyBaseCost, this.numberOfClickerAssemblies);

        if (this.totalCoins >= clicker_assembly_cost)
        {
            this.SubtractCoins(clicker_assembly_cost);
            this.numberOfClickerAssemblies++;

            Debug.Log("You now have " + this.numberOfClickerAssemblies + " clicker assemblies for " + clicker_assembly_cost);

            long new_cost = this.calculateCost(this.clickerAssemblyBaseCost, this.numberOfClickerAssemblies);

            GameObject.Find("BuyClickerAssembly").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    #region Clicker Factory
    [Header("ClickerFactory")]
    public double clickerFactoryProduction = 47f;


    private long clickerFactoryBaseCost = 12000;
    private int numberOfClickerFactories = 0;

    public void BuyClickerFactory()
    {
        long clicker_factory_cost = this.calculateCost(this.clickerFactoryBaseCost, this.numberOfClickerFactories);

        if (this.totalCoins >= clicker_factory_cost)
        {
            this.SubtractCoins(clicker_factory_cost);
            this.numberOfClickerFactories++;

            Debug.Log("You now have " + this.numberOfClickerFactories + " clicker factories for " + clicker_factory_cost);

            long new_cost = this.calculateCost(this.clickerFactoryBaseCost, this.numberOfClickerFactories);

            GameObject.Find("BuyClickerFactory").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    #region Clicker University
    [Header("ClickerUniversity")]
    public double clickerUniversityProduction = 260f;


    private long clickerUniversityBaseCost = 130000;
    private int numberOfClickerUniversities = 0;

    public void BuyClickerUniversity()
    {
        long clicker_university_cost = this.calculateCost(this.clickerUniversityBaseCost, this.numberOfClickerUniversities);

        if (this.totalCoins >= clicker_university_cost)
        {
            this.SubtractCoins(clicker_university_cost);
            this.numberOfClickerUniversities++;

            Debug.Log("You now have " + this.numberOfClickerUniversities + " clicker universities for " + clicker_university_cost);

            long new_cost = this.calculateCost(this.clickerUniversityBaseCost, this.numberOfClickerUniversities);

            GameObject.Find("BuyClickerUniversity").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    private void Start()
    {
        this.coinsAmount = GameObject.Find("CoinsAmount").GetComponent<Text>();
        this.coinsPerSecond = GameObject.Find("CoinsPerSecond").GetComponent<Text>();

        GameObject.Find("BuyClicker").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerBaseCost) + " clicks";
        GameObject.Find("BuyFastClicker").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.fastClickerBaseCost) + " clicks";
        GameObject.Find("BuyClickerAssembly").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerAssemblyBaseCost) + " clicks";
        GameObject.Find("BuyClickerFactory").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerFactoryBaseCost) + " clicks";
        GameObject.Find("BuyClickerUniversity").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerUniversityBaseCost) + " clicks";

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

    private string FormatCoinsText(double number)
    {
        string text = "";

        if (number < Math.Pow(10, 3))
            text = number.ToString("F1");
        else if (number < Math.Pow(10, 6))
            text = string.Format("{0:#.00}K", number / Math.Pow(10, 3));
        else if (number < Math.Pow(10, 9))
            text = string.Format("{0:#.00}M", number / Math.Pow(10, 6));
        else if (number < Math.Pow(10, 12))
            text = string.Format("{0:#.00}B", number / Math.Pow(10, 9));
        else if (number < Math.Pow(10, 15))
            text = string.Format("{0:#.00}T", number / Math.Pow(10, 12));
        else if (number < Math.Pow(10, 18))
            text = string.Format("{0:#.00}Qa", number / Math.Pow(10, 15));
        else if (number < Math.Pow(10, 21))
            text = string.Format("{0:#.00}Qt", number / Math.Pow(10, 18));
        else if (number < Math.Pow(10, 24))
            text = string.Format("{0:#.00}Sx", number / Math.Pow(10, 21));
        else if (number < Math.Pow(10, 27))
            text = string.Format("{0:#.00}Sp", number / Math.Pow(10, 24));
        else if (number < Math.Pow(10, 30))
            text = string.Format("{0:#.00}Oc", number / Math.Pow(10, 27));
        else if (number < Math.Pow(10, 33))
            text = string.Format("{0:#.00}No", number / Math.Pow(10, 30));
        else if (number < Math.Pow(10, 34))
            text = string.Format("{0:#.00}Dc", number / Math.Pow(10, 33));
        else
        {
            int power = 34;
            double coins = number / Math.Pow(10, power);

            while (((int)coins) / 10 != 0)
            {
                coins /= 10.0;
                power++;
            }

            text = string.Format("{0:#.00}e{1}", coins, power);
        }

        return text;
    }
}
