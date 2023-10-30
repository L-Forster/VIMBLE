public class Mine : Building
{
    private int metal = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHp;
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
    }
}
