using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class PlanetSelectionScroller : MonoBehaviour
{
    [SerializeField] private GameObject planetButtonPrefab;
    [SerializeField] private GameObject scrollContent;
    
    public void Initialize(StarState state)
    {
        scrollContent.GetComponent<RectTransform>().sizeDelta =
            new Vector2(scrollContent.GetComponent<RectTransform>().sizeDelta.x, 120 * state.Planets.Length);
        Assert.IsTrue(state.Planets.Length <= scrollContent.transform.childCount, "Too many Planets. Add more prefabs");
        for (int i = 0; i < state.Planets.Length; i++)
        {
            GameObject g = scrollContent.transform.GetChild(i).gameObject;
            g.GetComponentInChildren<TextMeshProUGUI>().text = state.Planets[i].Type;
            g.SetActive(true);
        }

        for (int i = state.Planets.Length; i < scrollContent.transform.childCount; i++)
        {
            scrollContent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
