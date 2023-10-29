using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Building
{
    public int energy;
    public int maxEnergy; 

    void Start()
    {
        energy = 0;
    }

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

    void Update()
    {

    }
}
