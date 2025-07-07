using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetSelectionScroller : MonoBehaviour
{
    [SerializeField] private GameObject planetButtonPrefab;
    
    public void Initialize(StarState state)
    {
        foreach (var planetState in state.Planets)
        {
            GameObject g = Instantiate(planetButtonPrefab, transform);
            g.GetComponentInChildren<TextMeshProUGUI>().text = planetState.Type;
        }
    }

}
