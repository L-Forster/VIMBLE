using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    public Building generatorPrefab;
    public Building batteryPrefab;
    public Building factoryPrefab;
    
    void BuyBuilding(string buildingType, int xBuyPosition, int yBuyPosition)
    {
        switch (buildingType)
        {
            case "Generator": 
                Instantiate(generatorPrefab, new Vector3(xBuyPosition, yBuyPosition, 0), Quaternion.identity);
                break;
            case "Battery": 
                Instantiate(batteryPrefab, new Vector3(xBuyPosition, yBuyPosition, 0), Quaternion.identity);
                break;
            case "Factory": 
                Instantiate(factoryPrefab, new Vector3(xBuyPosition, yBuyPosition, 0), Quaternion.identity);
                break;
        }
     
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}