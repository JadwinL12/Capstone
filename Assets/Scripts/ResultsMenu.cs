using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsMenu : MonoBehaviour
{
    public static bool passSong;

    public GameObject passUI;
    public GameObject failUI;

    public Text scoreText;
    public Text comboText;
    public Text perfText;
    public Text goodText;
    public Text missText;

    public HealthBar healthBar;
    public Score score;
    public Combo combo;

    public float highestCombo;
    public float perfHits;
    public float goodHits;
    public float missHits;

    void Start()
    {
        if (healthBar.getHealth() == 0.0)
        {
            passSong = false;
        }
        if (healthBar.getHealth() > 0.0)
        {
            passSong = true;
        }

        highestCombo = 1;
    }

    void Update()
    {
        if (passSong)
        {
            LoadPass();
        }
        else
        {
            LoadFail();
        }

        scoreText.text = score.totalScore.ToString();
        comboText.text = combo.highestCombo.ToString();
        perfText.text = perfHits.ToString();
        goodText.text = goodHits.ToString();
        missText.text = missHits.ToString();
    }

    public void LoadPass()
    {
        passUI.SetActive(true);
    }

    public void LoadFail()
    {
        failUI.SetActive(true);
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene("Menu");
    }
}
