using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IUnitNamespace{
    public interface IUnit
    {
        //att
        int health { get; set; }
        int speed { get; set; }
        int damage { get; set; }
        Vector2 position { get; set; }


        //methods
        void updatePos();

    }
}