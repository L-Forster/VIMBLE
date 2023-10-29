using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitNamespace;

public class Friendly : Unit
{
    public bool selected;
    public Vector2 mousePos;
    public Vector2 target_pos;
    private Vector2 position;

    private void Start()
    {
        target_pos = transform.position; // Initialize target_pos to the current position
        position = transform.position; // Initialize position to the current position
        selected = false;
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

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);

        if (selected)
        {
            if (Input.GetMouseButtonDown(1))
            {
                target_pos = mousePosition;
                Move();
                Debug.Log("Moving");
            }
        }

        Select();
        mousePos = mousePosition;
    }

    private void Select()
    {
        float difference = Vector2.Distance(mousePos, position);
        difference = Mathf.Abs(difference);
		
        if (Input.GetMouseButtonDown(0))
        {	
			selected = !selected;
            
            Transform triangleChild = transform.Find("Triangle");

            if (triangleChild != null)
            {
                SpriteRenderer spriteRenderer = triangleChild.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Debug.Log("SpriteRenderer exists.");
					if (selected){spriteRenderer.color = Color.red;}
					else {spriteRenderer.color = Color.white;}
                    Debug.Log("Sprite color changed to red.");
                }
                else
                {
                    Debug.LogError("No SpriteRenderer found on the 'Triangle' child GameObject.");
                }
            }
            else
            {
                Debug.LogError("Child GameObject 'Triangle' not found.");
            }
        }
    }

private bool isMoving = false;

	private void Update()
	{
    	if (selected)
    	{
        // Right-click to set a new target position
        	if (Input.GetMouseButtonDown(1))
        	{
            	Vector3 mousePos = Input.mousePosition;
            	mousePos.z = -Camera.main.transform.position.z;
            	Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);

            	target_pos = mousePosition;
            	isMoving = true; // Start moving
            	Debug.Log("Moving to new target");
        	}
			if (Input.GetMouseButtonDown(0)){Debug.Log("CRICK");}


        // Move towards the target
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
            	}
        	}
    	}
	
}

}

