using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    private const int ScorePerHit = 100;
    private int _score;
    private Text _scoreText;
    public int currentMultiplier = 1;
    public int[] multiplierThresholds;
    
    // Start is called before the first frame update
    private void Start()
    {
        _scoreText = GetComponent<Text>();
        _scoreText.text = "Score: " + _score.ToString();
    }

    public void ScoreHit(int comboNumber)
    {
        _score += (comboNumber * ScorePerHit);
        _scoreText = GetComponent<Text>();
        _scoreText.text = "Score: " + _score.ToString();
    }
}
