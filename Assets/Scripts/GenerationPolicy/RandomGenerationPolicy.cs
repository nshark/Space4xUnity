
using UnityEngine;

public class RandomGenerationPolicy : IGenerationPolicy
{
    //Consts
    private const int NumberOfStars = 100;
    private const int StarfieldWidth = 5000;
    private const int StarfieldHeight = 5000;
    
    public StarState[] GenerateStarfield()
    {
        StarState[] stars = new StarState[NumberOfStars];
        for (int i = 0; i < NumberOfStars; i++)
        {
            stars[i] = new StarState(new Vector2(Random.Range(-1 * StarfieldWidth / 2, StarfieldWidth / 2),
                Random.Range(-1 * StarfieldHeight / 2, StarfieldHeight / 2)));
        }

        return stars;
    }
}