using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

public class StarView : MonoBehaviour
{
    [SerializeField] 
    private Sprite[] starSprites;

    [SerializeField] 
    private float[] starScales; 
    public StarState StarState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponentsInChildren<Image>()[0].sprite = starSprites[StarState.StarType];
        transform.localScale = new Vector3(starScales[StarState.StarType], starScales[StarState.StarType],
            0);
    }
}
