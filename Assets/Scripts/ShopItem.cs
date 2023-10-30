using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class ShopItem : MonoBehaviour
{
    public Building building;
    public ShopController shopIAmIn;
    public Image BuildingIcon;

    void Awake()
    {
        Debug.Log("Setting Image to: ");
        Debug.Log(building.Image.image);
        
        transform.GetChild(0).gameObject.GetComponent<Image>().image = building.Image.image;
    }
    private void OnMouseUpAsButton()
    {
        shopIAmIn.BuyItem(this.building);
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
