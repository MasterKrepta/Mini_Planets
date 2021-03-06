﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseResources : MonoBehaviour
{
    [SerializeField] float foodUseRate = 5f;

    private void Start() {
        InvokeRepeating("UseFood", foodUseRate, foodUseRate);
        StatsManager.OnEnterOrbit += TakeResourcesOnOrbit;
        StatsManager.OnLeaveOrbit += UseFuel;
        
    }
    void LoseHull() {
        Resource r = new Resource();
        r.Type = Resource.Types.HULL;
        StatsManager.DecreaseResources(r);
        StatsManager.Instance.UpdateUI();
    }
    void UseFood() {
        Resource r = new Resource();
        r.Type = Resource.Types.FOOD;
        StatsManager.DecreaseResources(r);
        StatsManager.Instance.UpdateUI();
    }

    void UseFuel() {
        Resource r = new Resource();
        r.Type = Resource.Types.FUEL;
        StatsManager.DecreaseResources(r);
        StatsManager.Instance.UpdateUI();
    }

    void UseEnergy() {
        Resource r = new Resource();
        r.Type = Resource.Types.ENERGY;
        StatsManager.DecreaseResources(r);
        StatsManager.Instance.UpdateUI();
    }
    public void TakeResourcesOnOrbit() {
        StatsManager.Instance.UpdateUI(); // HACK
        if (StatsManager.Instance.EnergyUI.value > 0) {
            UseEnergy();
        }
        else {
            LoseHull();
        }
        Orbit o = this.gameObject.GetComponent<Orbit>();
        StatsManager.IncreaseResource(o.BodyToOrbit.resource);

    }

    private void OnDisable() {
        StatsManager.OnEnterOrbit -= TakeResourcesOnOrbit;
    }
}
