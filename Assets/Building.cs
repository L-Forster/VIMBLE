using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

public struct Location{
    int x;
    int y;
}

public string buildingType;

public int buildTime;

public int health;

public int maxHp;

void TakeDamage(int damage){
    health = health - damage;
}

void Repair(int heal){
   health = heal + health;
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
            Destroy(this);
        }
    }
}
