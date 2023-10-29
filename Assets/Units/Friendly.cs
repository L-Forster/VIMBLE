using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitNamespace;

public class Friendly : Unit
{
    // Start is called before the first frame update

	void Move(value){
		setPosistion(value)
	}

	void Attack(target){
		if (target.type == "placeable"){
			pass;
		}
		else if (target.type == "unit"){
			pass;
		}
		
	}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



	
}

