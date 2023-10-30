using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

public string buildingType;

public bool isPowered;

public int powerRequired;

public int buildTime;

public int health;

public int maxHp;

public int metal_cost;

void TakeDamage(int damage){
    health =- damage;
}

void Repair(int heal){
   health =+ heal;
   if(health > maxHp) health = maxHp;
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(health <= 0){
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
