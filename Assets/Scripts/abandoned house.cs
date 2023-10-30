using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abandonedhouse : Building
{
    public bool broke = false;
    public TextMesh health_text;

    int Timeremaining = 10;
    // Start is called before the first frame update
    void Start()
    {
        health_text = GetComponentInChildren<TextMesh>(); // Assuming the Text component is a child of the unit's GameObject		isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        health_text.text = health.ToString() ;

        if (broke && Timeremaining > 0)
        {
            Timeremaining -= 1;
        }
        else if (Timeremaining == 0 && broke)
        {
            gameObject.SetActive(false);

            Destroy(this);
        }
    }
}
