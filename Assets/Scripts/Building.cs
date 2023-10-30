using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Building : MonoBehaviour
{
    public Image Image;
    public int cost;
    
    public string buildingType;

public bool isPlaced;

public bool isPowered;

public int powerRequired;

public int buildTime;

public int health;

public int maxHp;

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
            Destroy(this);
        }
    }
}
