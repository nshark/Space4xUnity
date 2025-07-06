using UnityEngine;

public class StarState
{
    public Vector2 Position { get; set; }

    //determines which star sprite to use - from 0-3
    public int StarType { get; set; }

    public PlanetState[] Planets { get; set; }
   
    // if -1 is passed as the star type, it is randomized - this is the default value
    public StarState(Vector2 position, int starType=-1, PlanetState[] planets = null)
    {
        if (starType == -1)
        {
            StarType = Random.Range(0, 4);
        }

        if (planets == null)
        {
            int numOfPlanets = Random.Range(0, 5);
            if (numOfPlanets != 0)
            {
                Planets = new PlanetState[numOfPlanets];
                for (int i = 0; i < Planets.Length; i++)
                {
                    Planets[i] = new PlanetState();
                }
            }
        }

        Position = position;
    }
}
