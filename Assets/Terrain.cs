using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class resource : MonoBehaviour
{ 
    resource()
    {
    }

}
public class Terrain : MonoBehaviour
{
    public resource Resource;
    public bool foliage;
    // Start is called before the first frame update

    // Update is called once per frame
    void removeFoliage()
    {
        //remove foliage
        foliage = false;
    }
}

public class water : Terrain
{
    
}
public class flatlands : Terrain
{
    
}

public class mountains : Terrain
{
    private new Collider2D Collider2D;
}

