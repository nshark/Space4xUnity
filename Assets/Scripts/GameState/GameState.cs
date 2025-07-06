public class GameState
{
    public StarState[] Stars { get; set; }
    public int TurnCounter { get; set; }
    
    public GameState()
    {
        PlanetState.InitTypes();
        IGenerationPolicy generationPolicy = new RandomRetryGenerationPolicy();
        Stars = generationPolicy.GenerateStarfield();
    }
    
}