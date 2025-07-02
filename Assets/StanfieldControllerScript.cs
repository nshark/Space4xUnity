using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StanfieldControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2[] starPositions = GenerateStarfield();
        foreach (var pos in starPositions)
        {
            CreateStar(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateStar(Vector2 pos)
    {
        GameObject g = Instantiate(starPrefab, transform);
        g.transform.position = pos;
        g.GetComponent<Button>().onClick.AddListener(() => HandleStarClick(g));
    }

    public void HandleStarClick(GameObject star)
    {
        
    }
    //TODO move somewhere else, just trying to get this working
    private const int NumberOfStars = 100;
    private const int StarfieldWidth = 500;
    private const int StarfieldHeight = 500;
    
    private const int MaxRetries = 1000;
    private const int MinimumDistanceBetweenStars = 25;
    private const int MaximumDistanceBetweenStars = 100;
    
    public Vector2[] GenerateStarfield()
    {
        Vector2[] stars = new Vector2[NumberOfStars];
        for (int i = 0; i < NumberOfStars; i++)
        {
            bool placedStar = false;
            for (int j = 0; j < MaxRetries; j++)
            {
                stars[i] = new Vector2(Random.Range(-1 * StarfieldWidth / 2, StarfieldWidth / 2),
                    Random.Range(-1 * StarfieldHeight / 2, StarfieldHeight / 2));

                if (i == 0)
                {
                    // the first star is always placed successfully on the first try
                    placedStar = true;
                    break;
                }
                
                bool foundMinDistanceNeighbor = false;
                bool foundMaxDistanceNeighbor = false;
                for (int k = 0; k < i; k++)
                {
                    Vector2 distance = stars[i] - stars[k];
                    float distanceSquared = distance.sqrMagnitude;
                    if (distanceSquared < MinimumDistanceBetweenStars*MinimumDistanceBetweenStars)
                    {
                        foundMinDistanceNeighbor = true;
                        break;
                    }

                    if (distanceSquared < MaximumDistanceBetweenStars*MaximumDistanceBetweenStars)
                    {
                        foundMaxDistanceNeighbor = true;
                    }
                }

                if (!foundMinDistanceNeighbor && foundMaxDistanceNeighbor)
                {
                    placedStar = true;
                    break;
                }
            }

            if (!placedStar)
            {
                // might be better to throw an exception?
                Console.Error.WriteLine("Exceeded maximum number of retries for random star generation");
                break;
            }
        }

        return stars;
    }
}
