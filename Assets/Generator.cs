using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Building
{
    public int genratedEnergy = 0;
    public int radius = 20; //just a random radius for powering adjacent buildings
  

  void Generate(int resourcePower){
    genratedEnergy = resourcePower; //generates higher power depending on the resource
  }

  void PowerAdjacent(int x,int y, Building[] buildings){  
   foreach (Building building in buildings)
   {
    //run every time a building is added?
      //power on depending on the x y coordinates (may need to change it to unitiy location)
   }  
  }

    // Start is called before the first frame update
    void Start()
    {
        buildingType = "NATURE EATING Generator"; //random name and initial values
        genratedEnergy = 0;
        buildTime = 25;
        health = maxHp;
        maxHp = 3100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
