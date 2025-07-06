using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (e.g == null)
        {
            _selectedStarState = null;
            transform.GetChild(0).GameObject().SetActive(false);
        }

        else
        {
            _selectedStarState = e.g.GetComponent<StarView>().StarState;
            transform.GetChild(0).GameObject().SetActive(true);
        }
    }
}
