using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    public GUIText scoreText;
    public int score = 0;

    void Start()
    {

    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}