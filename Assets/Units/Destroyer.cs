using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitNamespace;


public class Destroyer : Friendly
{
    private bool alive;
    private int health;
    private int damage;
    private int speed;
    private Unit target;
    private Vector2 position;
    void Start()
    {
        alive = true;
        health = 100;
        damage = 10;
        speed = 5;
        target = null;
    }



    // Update is called once per frame
    void Update()
    {
        // if the unit is selected

        // if the unit has a target
        if (target != null)
        {
            DoDamage(target);
        }
    }
}
