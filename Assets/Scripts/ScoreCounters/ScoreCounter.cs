using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Reflector target;

    private Text text;

    [SerializeField]
    private string color;

    private int score;

    private void Start()
    {
        text = GetComponent<Text>();
        DisplayScore();
        score = 0;
        target.Reflected += IncreaseCounter;
    }

    public void IncreaseCounter()
    {
        score++;
        DisplayScore();
    }
    public void DisplayScore()
    {
        text.text = $"{color}Score: " + score;
    }
}
