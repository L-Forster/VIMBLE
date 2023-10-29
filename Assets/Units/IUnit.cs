using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitNamespace;
namespace IUnitNamespace{
    public interface IUnit
    {
        //att
        int health { get; set; }
        int speed { get; set; }
        int damage { get; set; }
        bool alive { get; set; }

        Unit target { get; set; }

        //methods
        void DoDamage(Unit target);

    }
}