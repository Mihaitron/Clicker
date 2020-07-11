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

    private double totalCoins = Math.Pow(10, 20);
    private int softResetNumber = 0;
    private Text coinsAmount;
    private Text coinsPerSecond;

    private IEnumerator AddClicksPerSecond()
    {
        double clicker_coins = this.numberOfClickers * this.clickerProduction;
        double fast_clicker_coins = this.numberOfFastClickers * this.fastClickerProduction;
        double clicker_assembly_coins = this.numberOfClickerAssemblies * this.clickerAssemblyProduction;
        double clicker_factory_coins = this.numberOfClickerFactories * this.clickerFactoryProduction;
        double clicker_university_coins = this.numberOfClickerUniversities * this.clickerUniversityProduction;
        double clicker_city_coins = this.numberOfClickerCities * this.clickerCityProduction;
        double clicker_country_coins = this.numberOfClickerCountries * this.clickerCountryProduction;
        double clicker_rocket_coins = this.numberOfClickerRockets * this.clickerRocketProduction;
        double clicker_planet_coins = this.numberOfClickerPlanets * this.clickerPlanetProduction;
        double clicker_galaxy_coins = this.numberOfClickerGalaxies * this.clickerGalaxyProduction;
        double clicker_universe_coins = this.numberOfClickerUniverses * this.clickerUniverseProduction;
        double total_coins_to_add = clicker_coins + 
                                     fast_clicker_coins + 
                                     clicker_assembly_coins + 
                                     clicker_factory_coins + 
                                     clicker_university_coins +
                                     clicker_city_coins +
                                     clicker_country_coins +
                                     clicker_rocket_coins + 
                                     clicker_planet_coins +
                                     clicker_galaxy_coins +
                                     clicker_universe_coins;

        total_coins_to_add += total_coins_to_add * 0.1 * this.softResetNumber;

        this.coinsPerSecond.text = this.FormatCoinsText(total_coins_to_add) + " clicks/s";
        this.AddCoins(total_coins_to_add);

        yield return new WaitForSeconds(1);

        StartCoroutine(this.AddClicksPerSecond());
    }

    private void AddCoins(double coins)
    {
        this.totalCoins += coins;
        this.coinsAmount.text = this.FormatCoinsText(this.totalCoins);
    }

    private void SubtractCoins(double coins)
    {
        this.totalCoins -= coins;
        this.coinsAmount.text = this.FormatCoinsText(this.totalCoins);
    }

    public void SoftReset()
    {
        if (this.totalCoins >= Math.Pow(10, 5 + this.softResetNumber))
        {
            this.softResetNumber++;

            this.totalCoins = 0;
            this.numberOfClickers = 0;
            this.numberOfFastClickers = 0;
            this.numberOfClickerAssemblies = 0;
            this.numberOfClickerFactories = 0;
            this.numberOfClickerUniversities = 0;
            this.numberOfClickerCities = 0;
            this.numberOfClickerCountries = 0;
            this.numberOfClickerRockets = 0;
            this.numberOfClickerPlanets = 0;
            this.numberOfClickerGalaxies = 0;
            this.numberOfClickerUniverses = 0;
        }
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

    #region Clicker City
    [Header("ClickerCity")]
    public double clickerCityProduction = 1400f;


    private long clickerCityBaseCost = 1400000;
    private int numberOfClickerCities = 0;

    public void BuyClickerCity()
    {
        long clicker_city_cost = this.calculateCost(this.clickerCityBaseCost, this.numberOfClickerCities);

        if (this.totalCoins >= clicker_city_cost)
        {
            this.SubtractCoins(clicker_city_cost);
            this.numberOfClickerCities++;

            Debug.Log("You now have " + this.numberOfClickerCities + " clicker cities for " + clicker_city_cost);

            long new_cost = this.calculateCost(this.clickerCityBaseCost, this.numberOfClickerCities);

            GameObject.Find("BuyClickerCity").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    #region Clicker Country
    [Header("ClickerCountry")]
    public double clickerCountryProduction = 7800f;


    private long clickerCountryBaseCost = 20000000;
    private int numberOfClickerCountries = 0;

    public void BuyClickerCountry()
    {
        long clicker_country_cost = this.calculateCost(this.clickerCountryBaseCost, this.numberOfClickerCountries);

        if (this.totalCoins >= clicker_country_cost)
        {
            this.SubtractCoins(clicker_country_cost);
            this.numberOfClickerCountries++;

            Debug.Log("You now have " + this.numberOfClickerCountries + " clicker countries for " + clicker_country_cost);

            long new_cost = this.calculateCost(this.clickerCountryBaseCost, this.numberOfClickerCountries);

            GameObject.Find("BuyClickerCountry").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    #region Clicker Rocket
    [Header("ClickerRocket")]
    public double clickerRocketProduction = 44000f;


    private long clickerRocketBaseCost = 330000000;
    private int numberOfClickerRockets = 0;

    public void BuyClickerRocket()
    {
        long clicker_rocket_cost = this.calculateCost(this.clickerRocketBaseCost, this.numberOfClickerRockets);

        if (this.totalCoins >= clicker_rocket_cost)
        {
            this.SubtractCoins(clicker_rocket_cost);
            this.numberOfClickerRockets++;

            Debug.Log("You now have " + this.numberOfClickerRockets + " clicker rockets for " + clicker_rocket_cost);

            long new_cost = this.calculateCost(this.clickerRocketBaseCost, this.numberOfClickerRockets);

            GameObject.Find("BuyClickerRocket").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    #region Clicker Planet
    [Header("ClickerPlanet")]
    public double clickerPlanetProduction = 260000f;


    private long clickerPlanetBaseCost = 5100000000;
    private int numberOfClickerPlanets = 0;

    public void BuyClickerPlanet()
    {
        long clicker_planet_cost = this.calculateCost(this.clickerPlanetBaseCost, this.numberOfClickerPlanets);

        if (this.totalCoins >= clicker_planet_cost)
        {
            this.SubtractCoins(clicker_planet_cost);
            this.numberOfClickerPlanets++;

            Debug.Log("You now have " + this.numberOfClickerPlanets + " clicker planets for " + clicker_planet_cost);

            long new_cost = this.calculateCost(this.clickerPlanetBaseCost, this.numberOfClickerPlanets);

            GameObject.Find("BuyClickerPlanet").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    #region Clicker Galaxy
    [Header("ClickerGalaxy")]
    public double clickerGalaxyProduction = 1600000f;


    private long clickerGalaxyBaseCost = 75000000000;
    private int numberOfClickerGalaxies = 0;

    public void BuyClickerGalaxy()
    {
        long clicker_galaxy_cost = this.calculateCost(this.clickerGalaxyBaseCost, this.numberOfClickerGalaxies);

        if (this.totalCoins >= clicker_galaxy_cost)
        {
            this.SubtractCoins(clicker_galaxy_cost);
            this.numberOfClickerGalaxies++;

            Debug.Log("You now have " + this.numberOfClickerGalaxies + " clicker galaxies for " + clicker_galaxy_cost);

            long new_cost = this.calculateCost(this.clickerGalaxyBaseCost, this.numberOfClickerGalaxies);

            GameObject.Find("BuyClickerGalaxy").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
        }
    }
    #endregion

    #region Clicker Universe
    [Header("ClickerUniverse")]
    public double clickerUniverseProduction = 10000000f;


    private long clickerUniverseBaseCost = 1000000000000;
    private int numberOfClickerUniverses = 0;

    public void BuyClickerUniverse()
    {
        long clicker_universe_cost = this.calculateCost(this.clickerUniverseBaseCost, this.numberOfClickerUniverses);

        if (this.totalCoins >= clicker_universe_cost)
        {
            this.SubtractCoins(clicker_universe_cost);
            this.numberOfClickerUniverses++;

            Debug.Log("You now have " + this.numberOfClickerUniverses + " clicker universes for " + clicker_universe_cost);

            long new_cost = this.calculateCost(this.clickerUniverseBaseCost, this.numberOfClickerUniverses);

            GameObject.Find("BuyClickerUniverse").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(new_cost) + " clicks";
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
        GameObject.Find("BuyClickerCity").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerCityBaseCost) + " clicks";
        GameObject.Find("BuyClickerCountry").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerCountryBaseCost) + " clicks";
        GameObject.Find("BuyClickerRocket").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerRocketBaseCost) + " clicks";
        GameObject.Find("BuyClickerPlanet").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerPlanetBaseCost) + " clicks";
        GameObject.Find("BuyClickerGalaxy").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerGalaxyBaseCost) + " clicks";
        GameObject.Find("BuyClickerUniverse").transform.GetChild(1).gameObject.GetComponent<Text>().text = this.FormatCoinsText(this.clickerUniverseBaseCost) + " clicks";

        StartCoroutine(this.AddClicksPerSecond());
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

    public void AddCoinsFromButton()
    {
        this.AddCoins(this.coinsPerClick);
    }
}
