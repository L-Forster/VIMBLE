using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abandonedhouse : building
{
    public bool broke = false;
    int Timeremaining = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (broke && Timeremaining > 0)
        {
            Timeremaining -= 1
        }else if (Timeremaining == 0 && broke){
            destroy(this.building);
        }
    }
}
