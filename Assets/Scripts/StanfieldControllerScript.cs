using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StanfieldControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;

    private GameState _state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _state = GameState.Instance;
        foreach (var starState in _state.Stars)
        {
            CreateStar(starState);
        }
    }

    private void CreateStar(StarState starState)
    {
        GameObject g = Instantiate(starPrefab, transform);
        g.GetComponent<StarView>().Initialize(starState);
        g.transform.position = starState.Position;
        g.layer = gameObject.layer;
        g.transform.GetChild(0).gameObject.layer = gameObject.layer;
        g.GetComponent<Button>().onClick.AddListener(() => HandleStarClick(g));
    }

    public void HandleStarClick(GameObject star)
    {
        
    }
    
    
}
