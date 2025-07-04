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
        PlanetState.InitTypes();
        _state = new GameState();
        foreach (var starState in _state.Stars)
        {
            CreateStar(starState.Position);
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
}
