using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class resource : MonoBehaviour
{ 
    public resource()
    {
    }

}

public class waterResource : resource
{
}
public class Terrain : MonoBehaviour
{
    public resource Resource;
    public bool foliage;
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

