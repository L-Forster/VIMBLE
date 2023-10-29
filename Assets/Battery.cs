using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Building
{
    public int energy;
    public int maxEnergy; 

    void GenerateEnergy(int generatedEnergy) 
    {
        energy = energy + generatedEnergy; 
        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
            Debug.Log("Battery is full"); 
        }
    }

    bool UseEnergy(int usedEnergy)
    {
        if (energy >= usedEnergy)
        {
            energy = energy - usedEnergy;
            return true;
        }
        else
        {
            Debug.Log("Not enough energy");
            return false;
        }
    }
    
    void Start()
    {
        name = "Plant Juice Holder"; //random name and initial values
        buildTime = 15;
        maxHp = 1500;
        health = maxHp;
        isPowered = false;
        energy = 0;
        powerRequired = energy;
    }
    void Update()
    {

    }
}
