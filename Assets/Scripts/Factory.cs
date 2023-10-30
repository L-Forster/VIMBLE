using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : Building
{
    int unit;
    string unitType;
    public TextMesh health_text;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHp;
        health_text = GetComponentInChildren<TextMesh>(); // Assuming the Text component is a child of the unit's GameObject		isMoving = false;

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
        health_text.text = health.ToString() ;

        if(health <= 0){
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}