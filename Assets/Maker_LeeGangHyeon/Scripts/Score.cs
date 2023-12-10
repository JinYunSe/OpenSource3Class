using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public static int score = 0;

    void Start()
    {

    }

    void Update()
    {
        SetText();
        Debug.Log(score);
    }

    public void SetText()
    {
        text.text = "Score: " + score.ToString();
    }
}
