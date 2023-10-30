using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ShopController : MonoBehaviour
{
    public Building[] catalogue;
    public ShopItem shopItemPreFab;
    public ShopUI shopUI;

    public void BuyItem(Building building)
    {
        Debug.Log("Buying!");
    }

    void RefreshCatalogue()
    {
        int offset = 0;
        foreach (var building in catalogue)
        {
            var t = shopUI.GetComponent<RectTransform>();
            ShopItem newShopItem = Instantiate(shopItemPreFab, t.transform);
            newShopItem.GetComponent<RectTransform>().Translate(new Vector3(40 * offset,0));
            offset += 1;
            newShopItem.building = building;
            Debug.Log("making a: ");
            Debug.Log(building.buildingType);
            newShopItem.BuildingIcon = building.Image;
            newShopItem.shopIAmIn = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
      RefreshCatalogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
