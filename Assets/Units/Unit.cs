using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IUnitNamespace;

namespace UnitNamespace
{

    public class Unit : MonoBehaviour, IUnit
    {
        private int health;
        private int speed;
        private int damage;
        private Vector2 position;
        // Start is called before the first frame update

        int IUnit.health
        {
            get { return health; }
            set { health = value; }
        }
        int IUnit.speed
        {
            get { return speed; }
            set { speed = value; }
        }

        int IUnit.damage
        {
            get { return damage; }
            set { damage = value; }
        }
        Vector2 IUnit.position
        {
            get { return position; }
            set { position = value; }
        }

        

        void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            
        }




    }
}