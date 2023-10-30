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
        public void DoDamage(Unit target, int damage_val)
        {
            if ((target.health - damage_val) <= 0)
            {
                target.alive = false;
                target.health = 0;
            }

            else
            {
                target.health = (target.health - damage_val);
            }
        }

        public void DoDamage(Tree target, int damage_val)
        {
            if (Time.time - lastDamageTime >= damage_cooldown)
            {
                target.health = (target.health - damage_val);
                lastDamageTime = Time.time;

                if ((target.health - damage_val) <= 0)
                {
                    target.alive = false;
                    target.health = 0;
                }

                else
                {
                    target.health = (target.health - damage_val);
                }
            }
        }
        
        public void DoDamage(Building target, int damage_val)
        {
            if (Time.time - lastDamageTime >= damage_cooldown)
            {
                target.health = (target.health - damage_val);
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

