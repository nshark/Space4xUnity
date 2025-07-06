using System;
using TMPro;
using UnityEngine;

public class TurnCounterView : MonoBehaviour
{
    private GameState _state = null;

    private TextMeshProUGUI _textField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _textField = gameObject.GetComponent<TextMeshProUGUI>();
        _state = GameStateController.Instance.State;
        GameStateController.Instance.TurnIncremented += StateOnTurnIncremented;
        UpdateTurnCounterText();
    }

    private void StateOnTurnIncremented(object sender, EventArgs e)
    {
        UpdateTurnCounterText();
    }

    private void UpdateTurnCounterText()
    {
        _textField.text = _state.TurnCounter.ToString();
    }
}
