
using System;
using UnityEngine;

public class GameState
{
    private static GameState instance = null;
    public StarState[] Stars { get; set; }
    public event EventHandler<GameObjectEventArgs> StarSelected;

    public void OnStarSelected(GameObject g)
    {
        GameObjectEventArgs args = new GameObjectEventArgs();
        args.g = g;
        StarSelected?.Invoke(this, args);
    }
    public int TurnCounter { get; set; }
    public event EventHandler TurnIncremented;

    private void OnTurnIncremented(EventArgs e)
    {
        TurnIncremented?.Invoke(this, e);
    }

    public void IncrementTurn()
    {
        TurnCounter++;
        OnTurnIncremented(null);
    }
    private GameState()
    {
        PlanetState.InitTypes();
        IGenerationPolicy generationPolicy = new RandomRetryGenerationPolicy();
        Stars = generationPolicy.GenerateStarfield();
    }
    
    
    public static GameState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameState();
            }

            return instance;
        }
    }
}

public class GameObjectEventArgs : EventArgs
{
    public GameObject g;
}