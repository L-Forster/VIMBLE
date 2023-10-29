using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitNamespace;

public class Friendly : Unit
{
	
    // Start is called before the first frame update
	private Vector2 position;
	public void Move(Vector2 target_pos){
		position.x = position.x - target_pos.x;
		position.y = position.y - target_pos.y;
		Vector2 tempPos = new Vector2(position.x, position.y);
		tempPos = tempPos.normalized;
		tempPos = tempPos * 5;
		transform.position = tempPos;
	}

	bool selected
	{
		get {
			return selected;
	}
    	set {
			selected = value;
		}
    }

    Vector2 onMouseDown()
    {
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;
        // Convert the mouse position from screen space to world space
        mousePos.z = -Camera.main.transform.position.z; // Set the z-coordinate to match the camera's position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
     
		// if right click move the unit
		if (selected)
		{
			if(Input.GetMouseButtonDown(1)){
				Move(mousePosition);
			}
			selected = false;
			// Remove highlight
		}
		
	// check if you have selected it
		Select();

        // if the target is on a unit, highlight them
        return mousePosition;
    }
	
    void Select()
    {
		float difference = Vector2.Distance(onMouseDown(), position);
		difference = Mathf.Abs(difference);
        if (difference < 5){
			selected = true;
		}
        // insert code to highlight the thing


    }
	void HighlightSelection(){
		

	}

    void Start()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {


	
	}	
}

