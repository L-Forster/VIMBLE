using UnityEngine;

using UnityEngine.UI;

public class Mine : Building
{
    private int metal = 0;
    public TextMesh health_text;

    // Start is called before the first frame update
    void Start()
    {
        health_text = GetComponentInChildren<TextMesh>(); // Assuming the Text component is a child of the unit's GameObject		isMoving = false;

        buildingType = "Mine";
        maxHp = 20;
        buildTime = 10;
        health = maxHp;
        isPowered = false;
        powerRequired = 10;
    }

    void MineMetal(ref int energy)
    {
        if (energy >= 1)
        {
            metal += 1;
            energy -= 1;
        }
    }

    void UseMetal(int usedMetal)
    {
        metal -= usedMetal;
    }

    // Update is called once per frame
    void Update()
    {
        health_text.text = health.ToString() ;

        if(health <= 0){
            gameObject.SetActive(false);
            Destroy(this);
        }
    //    int energyFromBattery = Building.Battery.energy;
     //   MineMetal(ref energyFromBattery);

    }
}
