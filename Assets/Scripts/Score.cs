using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    public GameObject comboBar;

    public int hitScore = 5;

    public int totalScore;

    public int totalHit;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        totalHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + totalScore.ToString();
    }

    public void addScore()
    {
        Combo comboText = comboBar.GetComponent<Combo>();
        totalScore += (hitScore * comboText.comboCount);
    }
}
