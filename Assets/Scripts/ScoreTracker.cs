using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] int scorePerHit = 123456;
    int score;
    Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    void ScoreHit()
    {
        score += scorePerHit;
        scoreText.text = "Score: " + score.ToString();
    }
}
