using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitNamespace;


public class Destroyer : Friendly
{

    void Start()
    {

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
