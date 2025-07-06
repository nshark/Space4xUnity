using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StarfieldControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;

    private GameState _state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _state = GameStateController.Instance.State;
        foreach (var starState in _state.Stars)
        {
            CreateStar(starState);
        }
    }

    private void CreateStar(StarState starState)
    {
        GameObject g = Instantiate(starPrefab, transform);
        g.GetComponent<StarView>().StarState = starState;
        g.transform.position = starState.Position;
        g.layer = gameObject.layer;
        g.transform.GetChild(0).gameObject.layer = gameObject.layer;
        g.GetComponent<Button>().onClick.AddListener(() => HandleStarClick(g));
        g.GetComponent<EventTrigger>().triggers[0].callback.AddListener(HandleStarDeselect);
    }

    public void HandleStarClick(GameObject star)
    {
        GameStateController.Instance.OnStarSelected(star);
    }

    public void HandleStarDeselect(BaseEventData eventData)
    {
        GameStateController.Instance.OnStarSelected(null);
    }
    
}
