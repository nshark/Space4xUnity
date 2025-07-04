
public class GameState
{
    public StarState[] Stars { get; set; }

    public int TurnCounter { get; set; }

    public GameState()
    {
        IGenerationPolicy generationPolicy = new RandomRetryGenerationPolicy();
        Stars = generationPolicy.GenerateStarfield();
    }
}