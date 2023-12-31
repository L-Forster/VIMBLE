using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitNamespace;

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

    public void TargetClosest(Building[] buildings, Friendly[] friendlies)
    {
	    // calculate the distance between itself and the thing.
	    // compares against previous
		// finds the cloest building / friendly and attacks them
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
					    DoDamage(buildingComponent);
				    }
			    }
			    else if (target.CompareTag("Friendly"))
			    {
				    UnitNamespace.Unit friendlyComponent = target.GetComponent<UnitNamespace.Unit>();
				    if (friendlyComponent != null && friendlyComponent.alive)
				    {
					    DoDamage(friendlyComponent);
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

		if (isMoving)
        {
         	Move();

            // Check if the distance to the target is below a small threshold
           	float distanceToTarget = Vector2.Distance((Vector2)transform.position, target_pos);
           	if (distanceToTarget < 0.1f)
           	{
               // Stop moving when close enough to the target
               	isMoving = false;
               	Debug.Log("Reached the target");
	               //DoDamage();
            	}
       	}
		if (target != null){
			if (isMoving || (target.CompareTag("Friendly") && target.GetComponent<UnitNamespace.Unit>().isMoving))
			{
				isAttacking = false;
				target = null;
			}
		}
   	}
	
}



