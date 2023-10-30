using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitNamespace;
using System.Linq;
public class Enemy : Unit
{
    public Vector2 target_pos;
    private Vector2 position;
    private bool isAttacking;


    private void Start()
    {
	    isMoving = false;
        target_pos = transform.position; // Initialize target_pos to the current position
        position = transform.position; // Initialize position to the current position
    }

    public int TargetClosest()
    {
	    Friendly[] unitsTemp = FindObjectsOfType<Friendly>();
	    Building[] buildingsTemp = FindObjectsOfType<Building>();
	    List<Friendly> units = unitsTemp.ToList();
	    List<Building> buildings = buildingsTemp.ToList();
	    //Debug.Log("BUILDINGS" + buildings);
	    //Debug.Log("UNITS" + units);
// Your list of objects
// Reference position (for example, the position of the current object)
	    Vector3 referencePosition = transform.position; // Use your actual reference position

// Sort the list by absolute distance
	    units = units.OrderBy(unt =>
		    Vector3.Distance(unt.position, referencePosition)).ToList();
	    buildings = buildings.OrderBy(bld =>
		    Vector3.Distance(bld.transform.position, referencePosition)).ToList();
	    if (units.Count == 0)
	    {
		    if (buildings.Count == 0)
		    {
			    //Debug.Log("NONE");

			    return -1;
		    }
		    else
		    {
			   // Debug.Log("Going to building");

			    target_pos = buildings[0].transform.position;
		    }
	    }
	    else
	    {
		    if (buildings.Count == 0)
		    {
			   // Debug.Log("Going to Unit");

			    target_pos = units[0].position;
		    }

		    else if (Vector3.Distance(units[0].position, referencePosition) <
		             Vector3.Distance(buildings[0].transform.position, referencePosition))
		    {
			   // Debug.Log("Going to Unit");

			    target_pos = units[0].position;
		    }

		    else
		    {
			    //Debug.Log("Going to building");

			    target_pos = buildings[0].transform.position;
		    }
	    }

	    isMoving = true;
	    return 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
	    isMoving = false;
	    // Check if the collision involves a GameObject you're interested i
		    // Handle the collision with the "Enemy" GameObject
	    target = collision.gameObject;

		    
	    if (!isAttacking)
	    {
		    StartCoroutine(AttackCoroutine());
	    }
	    
    }

    private IEnumerator AttackCoroutine()
    {
	    isAttacking = true;

	    while (target != null && !isMoving )
	    {

		    // Perform the attack here (you can call DoDamage or any other attack logic)
		    if (target != null)
		    {
			    if (target.CompareTag("Building"))
			    {
				    Building buildingComponent = target.GetComponent<Building>();
				    if (buildingComponent != null && buildingComponent.health >= 0)
				    {
					    DoDamage(buildingComponent, damage);
				    }
			    }
			    else if (target.CompareTag("Friendly"))
			    {
				    UnitNamespace.Unit friendlyComponent = target.GetComponent<UnitNamespace.Unit>();
				    if (friendlyComponent != null && friendlyComponent.alive)
				    {
					    DoDamage(friendlyComponent, damage);
				    }
			    }
		    }

		    // Wait for the cooldown period before the next attack
		
		    yield return new WaitForSeconds(damage_cooldown);
	    }

	    // Reset the attack state after the target is defeated
	    isAttacking = false;
    }

    public void Move()
    {
        if (float.IsNaN(target_pos.x) || float.IsNaN(target_pos.y) || float.IsInfinity(target_pos.x) || float.IsInfinity(target_pos.y))
        {
            Debug.LogError("Invalid target_pos: " + target_pos);
            return;
        }

        Vector2 tempPos = target_pos - (Vector2)transform.position;
        float magnitude = tempPos.magnitude;

        if (magnitude > 0)
        {
            tempPos.Normalize();
        }

        Vector2 newPosition = (Vector2)transform.position + tempPos * speed * Time.deltaTime;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

	private void Update()
	{
        // Move towards the target
        if(health<=0){gameObject.SetActive(false);Destroy(this);}

        if (!isMoving)
        {
	        TargetClosest();

        }
		if (isMoving)
        {
         	Move();

            // Check if the distance to the target is below a small threshold
           	float distanceToTarget = Vector2.Distance((Vector2)transform.position, target_pos);
           	if (distanceToTarget < 0.1f)
           	{
               // Stop moving when close enough to the target
               	isMoving = false;
               //	Debug.Log("Reached the target");
	               //DoDamage();
            	}
       	}
		if (target != null  && (!target.CompareTag("Friendly") && !target.CompareTag("Building"))){
			if (isMoving || ((target.CompareTag("Friendly")||!target.CompareTag("Building")) && target.GetComponent<UnitNamespace.Unit>().isMoving))
			{
				isAttacking = false;
				target = null;
			}
		}
   	}
	
}



