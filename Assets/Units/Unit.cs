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
        private bool alive;
        private Unit target;
        
        int IUnit.health
            {
                get { return health; }
                set { health = value; }
            }
        Unit IUnit.target
        {
            get {
                return target;
            }
            set {
                target = value;
            }
        }

        int IUnit.speed
        {
            get {
                return speed;
            }
            set {
                speed = value;
            }
        }

        int IUnit.damage
        {
            get {
                return damage;
            }
            set {
                damage = value;
            }
        }

        Vector2 IUnit.position
        {
            get {
                return position;
            }
            set {
                position = value;
            }
        }

        bool IUnit.alive
        {
            get {
                return alive;
            }
            set {
                alive = value;
            }
        }

        public void DoDamage(Unit target)
        {
            if ((target.health - damage) <= 0)
            {
                target.alive = false;
                target.health = 0;
            }

            else
            {
                target.health = (target.health - damage);
            }
        }
        
        void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            if (!alive)
            {
                // RUN DEATH ANIMATION

                // REMOVE THE UNIT:
                Destroy(gameObject);
            }
        }
    }
}

