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
        health = maxHp;
        
    }
    void Update()
    {
        if(health <= 0){
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
