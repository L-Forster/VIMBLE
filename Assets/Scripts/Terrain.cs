using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class resource : MonoBehaviour
{ 
    public int amount;
    public string type;
    void addResource(int added){
        amount += added;
    }
    bool removeResource(int removed){
        
        if(amount - removed < 0){
            return false; //removal not success
        }
        else{
            amount-=removed;
            return true;  //removal success
        }
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

