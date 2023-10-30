using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : Building
{
    public int energy;
    public int maxEnergy; 
    public TextMesh health_text;

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
        health_text = GetComponentInChildren<TextMesh>(); // Assuming the Text component is a child of the unit's GameObject		isMoving = false;

        
    }
    void Update()
    {
        health_text.text = health.ToString() ;

        if(health <= 0){
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
