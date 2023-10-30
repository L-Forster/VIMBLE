using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public bool alive;
    public TextMesh health_text;

    void Start()
    
    {
        health_text = GetComponentInChildren<TextMesh>(); // Assuming the Text component is a child of the unit's GameObject		isMoving = false;
   
    }

    // Update is called once per frame
    void Update()
    {
        health_text.text = health.ToString() ;

        if (!alive)
        {
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
