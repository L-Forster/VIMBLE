using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
    int unit;
    string unitType;
    // Start is called before the first frame update
    void Start()
    {
        buildingType= "Factory";
        maxHp = 20;
        buildTime = 10;
        health = maxHp;
        isPowered = false;
        powerRequired = 10;
        unit = 0;
    }
    void CreateUnit(int energy, int resources, string type)
    {
        int RequiredEnergy = 0;
        int RequiredResources = 0;
        switch (type)
        {
            case "soldier":
                RequiredEnergy = 10;
                RequiredResources = 10;
                break;
            case "worker":
                RequiredEnergy = 20;
                RequiredResources = 20;
                break;
            case "scout":
                RequiredEnergy = 30;
                RequiredResources = 30;
                break;
        }
        if (energy >= RequiredEnergy && resources >= RequiredResources)
        {
            unit += 1;
            energy -= RequiredEnergy;
            resources -= RequiredResources;
            
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
