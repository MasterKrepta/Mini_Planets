using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public  Slider HullUI;
    public  Slider EnergyUI;
    public  Slider FuelUI;
    public  Slider FoodUI;

    public static Action OnEnterOrbit = delegate { };
    public static Action OnLeaveOrbit = delegate { };


    public static StatsManager Instance = null;

    static float CurrentHull;
    static float CurrentEnergy;
    static float CurrentFuel;
    static float CurrentFood;

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
    }
}
