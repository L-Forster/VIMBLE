using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool gameOver; //has the player lost?
    private bool playerWon; //has the player won?
    private int metal;
    private int money;
    public int getMoney()
    {
        return money;
    }
    
    public int getMetal()
    {
        return metal;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        playerWon = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }
}
