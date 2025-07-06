using System;
using UnityEngine;

public class GameStateController
{
    private static GameStateController instance = null;

    public event EventHandler<GameObjectEventArgs> StarSelected;

    public GameState State { get; private set; }

    public void OnStarSelected(GameObject g)
    {
        GameObjectEventArgs args = new GameObjectEventArgs();
        args.g = g;
        StarSelected?.Invoke(this, args);
    }
    public event EventHandler TurnIncremented;

    private void OnTurnIncremented(EventArgs e)
    {
        TurnIncremented?.Invoke(this, e);
    }

    public void IncrementTurn()
    {
        State.TurnCounter++;
        OnTurnIncremented(null);
    }
    private GameStateController()
    {
        State = new GameState();
    }
    
    public static GameStateController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameStateController();
            }

            return instance;
        }
    }
}

public class GameObjectEventArgs : EventArgs
{
    public GameObject g;
}