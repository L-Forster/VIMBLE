using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Generator : Building
{
    public int genratedEnergy = 0;
    public int radius = 20; //just a random radius for powering adjacent buildings
  

  void Generate(int resourcePower){
    genratedEnergy = resourcePower; //generates higher power depending on the resource oil wood etc
  }

  void PowerAdjacent(Building[] buildings){  
   foreach (Building building in buildings)
   {
   float bX = building.transform.position.x;
   float bY = building.transform.position.y;
    if(Math.Abs(bX - this.transform.position.x) <= radius && Math.Abs(bY- this.transform.position.y) <= radius){
            if(building.powerRequired < genratedEnergy && !building.isPowered){
                genratedEnergy =- building.powerRequired;
                building.isPowered = true;
            }
    }
   }  
  }

    // Start is called before the first frame update
    void Start()
    {
        buildingType = "NATURE EATING Generator"; //random name and initial values
        genratedEnergy = 0;
        buildTime = 25;
        maxHp = 3100;
        health = maxHp;
        powerRequired = int.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
