using UnityEngine;

public class EndTurnButtonController : MonoBehaviour
{
    GameState _state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _state = GameState.Instance;
    }

    public void HandleClick()
    {
        _state.IncrementTurn();
    }
}
