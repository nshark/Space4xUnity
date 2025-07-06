using UnityEngine;

public class EndTurnButtonController : MonoBehaviour
{
    public void HandleClick()
    {
        GameStateController.Instance.IncrementTurn();
    }
}
