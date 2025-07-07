using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetSelectionMenuController : MonoBehaviour
{
    private StarState _selectedStarState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameStateController.Instance.StarSelected += OnStarSelected;
    }

    private void OnStarSelected(object sender, GameObjectEventArgs e)
    {
        _selectedStarState = e.g.GetComponent<StarView>().StarState;
        var planetSelectionScroll = transform.GetChild(0).GameObject();
        planetSelectionScroll.SetActive(true);
        planetSelectionScroll.GetComponent<PlanetSelectionScroller>().Initialize(_selectedStarState);
    }
}
