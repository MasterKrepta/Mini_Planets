using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homeworld : Planet
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") || collision.CompareTag("Obstacle")) {
            collision.GetComponent<Orbit>().BodyToOrbit = this; // begin orbit
            GiveResources();
        }
    }
    void  GiveResources() {
        StatsManager.OnEnterOrbit();
        Debug.Log("Give Resources to planet");
        float foodToGive = StatsManager.CurrentFood / 2;
        StatsManager.CurrentFood -= foodToGive;
        StatsManager.PlanetFood += foodToGive;

        float energyToGive = StatsManager.CurrentEnergy / 2;
        StatsManager.CurrentEnergy -= energyToGive;
        StatsManager.PlanetFood += energyToGive;

        StatsManager.Instance.UpdateUI();
        StatsManager.Instance.UpdatePlanetUI();

    }

    
}
