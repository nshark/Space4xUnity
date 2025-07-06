using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

public class StarView : MonoBehaviour
{
    [SerializeField] 
    private Sprite[] starSprites;

    [SerializeField] 
    private float[] starScales; 
    private StarState _starState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponentsInChildren<Image>()[0].sprite = starSprites[_starState.StarType];
        transform.localScale = new Vector3(starScales[_starState.StarType], starScales[_starState.StarType],
            0);
    }

    public void Initialize(StarState starState)
    {
        _starState = starState;
    } 
}
