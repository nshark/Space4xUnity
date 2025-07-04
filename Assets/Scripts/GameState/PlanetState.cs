
using UnityEngine;

public class PlanetState
{
    
    private static WeightedRandom Types = new WeightedRandom();

    public static void InitTypes()
    {
        Types.AddItem("Barren", 5);
        Types.AddItem("Toxic", 5);
        Types.AddItem("Continental", 2.5);
        Types.AddItem("Gaia", 0.1);
    }
    public string Type { get; set; }
    public int Size { get; set; }
    public PlanetState()
    {
        Size = Random.Range(5, 15);
        Type = Types.GetRandomItem();
    }

    public PlanetState(string type, int size)
    {
        Type = type;
        Size = size;
    }
}