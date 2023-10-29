public class Mine : Building
{
    private int metal = 0;

    // Start is called before the first frame update
    void Start()
    {
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
    //    int energyFromBattery = Building.Battery.energy;
     //   MineMetal(ref energyFromBattery);

    }
}
