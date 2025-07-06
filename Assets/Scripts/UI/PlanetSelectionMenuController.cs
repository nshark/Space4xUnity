using UnityEngine;

public class PlanetSelectionMenuController : MonoBehaviour
{
    private StarState _selectedStarState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameState.Instance.StarSelected += OnStarSelected;
    }

    private void OnStarSelected(object sender, GameObjectEventArgs e)
    {
        _selectedStarState = e.g.GetComponent<StarView>().StarState;
        Debug.Log("starType:" +_selectedStarState.StarType);
    }
}
