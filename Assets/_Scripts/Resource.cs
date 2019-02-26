using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public enum Types
    {
        FUEL, HULL, ENERGY, FOOD
    }

    public Types Type = Types.FUEL;
    public float Value = 5f;

    public void Init() {
        switch (Type) {
            case Types.FUEL:
                Value = 25f;
                break;
            case Types.HULL:
                Value = 10f;
                break;
            case Types.ENERGY:
                Value = 20f;
                break;
            case Types.FOOD:
                Value = 5f;
                break;
            default:
                break;
        }
    }

    public void GiveResource() {
 
        StatsManager.IncreaseResource(this);
    }
}
