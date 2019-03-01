using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public static float PlanetEnergy;
    public static float PlanetFood;
    public static float PlanetPopulation;
    
    public Slider PlanetEnergyUI;
    public Slider PlanetFoodUI;
    public Slider PopulationUI;


    public  Slider HullUI;
    public  Slider EnergyUI;
    public  Slider FuelUI;
    public  Slider FoodUI;

    public float DecreasePlanetTimer = 10f;
    [SerializeField] float thresholdToIncreasePop = 50f;

    public static Action OnEnterOrbit = delegate { };
    public static Action OnLeaveOrbit = delegate { };
    public static Action OnGameOver = delegate { };


    public static StatsManager Instance = null;

    public static float CurrentHull;
    public static float CurrentEnergy;
    public static float CurrentFuel;
    public static float CurrentFood;

    [SerializeField] static float hullDamageAmount = 5f;
    [SerializeField] static float fuelUsageAmount = 10f;
    [SerializeField] static float energyUsageAmount = 5f;
    [SerializeField] static float foodUsageAmount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) {
            Instance = this;
        }

        CurrentHull = 100f;
        CurrentFood = 100f;
        CurrentFuel = 100f;
        CurrentEnergy = 100f;

        PlanetEnergy = 50;
        PlanetFood = 50;
        PlanetPopulation = 300;

        UpdatePlanetUI();
        InvokeRepeating("DecreasePlanetResources", 1, DecreasePlanetTimer);
}


    public static void DecreaseResources(Resource resource) {

        switch (resource.Type) {
            case Resource.Types.FUEL:
                CurrentFuel -= fuelUsageAmount;
                break;
            case Resource.Types.HULL:
                CurrentHull -= hullDamageAmount;
                break;
            case Resource.Types.ENERGY:
                CurrentEnergy -= energyUsageAmount;
                break;
            case Resource.Types.FOOD:
                CurrentFood -= foodUsageAmount;
                break;
        }
        Instance.UpdateUI();

    }

    public static void IncreaseResource(Resource resource) {

        switch (resource.Type) {
            case Resource.Types.FUEL:
                print("FuelGiven");
                CurrentFuel += resource.Value;
                if (CurrentFuel > 100) {
                    CurrentFuel = 100;
                }
                break;
            case Resource.Types.HULL:
                print("Hull Increased");
                CurrentHull += resource.Value;
                if (CurrentHull > 100) {
                    CurrentHull = 100;
                }
                break;
            case Resource.Types.ENERGY:
                print("EnergyIncreased");
                CurrentEnergy += resource.Value;
                if (CurrentEnergy > 100) {
                    CurrentEnergy = 100;
                }
                break;
            case Resource.Types.FOOD:
                print("Food Increased");
                if (CurrentFood > 100) {
                    CurrentFood = 100;
                }
                CurrentFood += resource.Value;
                break;
        }
        Instance.UpdateUI();

    }

    public  void UpdateUI() {
        HullUI.value = CurrentHull / 100;
        EnergyUI.value = CurrentEnergy / 100;
        FuelUI.value = CurrentFuel / 100;
        FoodUI.value = CurrentFood / 100;
        CheckGameOver();
    }

    public void UpdatePlanetUI() {
        PlanetEnergyUI.value = PlanetEnergy / 100;
        PlanetFoodUI.value = PlanetFood / 100;
        PopulationUI.value = PlanetPopulation / 1000;
        CheckWinCondition();
    }

    void DecreasePlanetResources() {
        PlanetEnergy -= 10f;
        PlanetFood -= 10f;
        if (PlanetFood < thresholdToIncreasePop) {
            PlanetPopulation -= 25;
        }
        else {
            PlanetPopulation += 50;
        }
        

        UpdatePlanetUI();
    }

    private void CheckWinCondition() {
        if (PlanetPopulation >= 50000) {
            //TODO call GAmeoverscene
            Debug.Log("!!!!!!! YOU WIN!!!!!! ");
        }
    }

    private void CheckGameOver() {
        if (CurrentHull == 0|| CurrentFuel == 0|| CurrentFood == 0) {
            Debug.Log(" !!!!!!!!! -- GAME OVER -- !!!!!!! ");
            OnGameOver();
        }
    }
}
