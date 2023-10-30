using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IUnitNamespace;

namespace UnitNamespace
{

    public class Unit : MonoBehaviour, IUnit
    {
        public int health;
        public int speed;
        public int damage;
        private float lastDamageTime;
        public float damage_cooldown;
        // Start is called before the first frame update
        public bool alive;
        public GameObject target;
        public bool isMoving;
        
        int IUnit.health
            {
                get { return health; }
                set { health = value; }
            }
        GameObject IUnit.target
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
        

        bool IUnit.alive
        {
            get {
                return alive;
            }
            set {
                alive = value;
            }
        }

        public void DoDamage(GameObject target)
        {
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

        public void DoDamage(Tree target)
        {
            if (Time.time - lastDamageTime >= damage_cooldown)
            {
                target.health = (target.health - damage);
                lastDamageTime = Time.time;

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
        }
        
        public void DoDamage(Building target)
        {
            if (Time.time - lastDamageTime >= damage_cooldown)
            {
                target.health = (target.health - damage);
                lastDamageTime = Time.time;
            }
        }

        void Start()
        {
            lastDamageTime = 0.0f;
        }

        // Update is called once per frame
        public void Update()
        {
            if (!alive)
            {
                // RUN DEATH ANIMATION
                
                // REMOVE THE UNIT:
                Destroy(this);
            }
        }
    }
}

