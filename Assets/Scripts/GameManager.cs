using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public NoteScroll theNS;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public float currentHealth;

    public GameObject comboBar;
    public GameObject scoreBar;

    public GameObject resultsMenuUI;
    public GameObject healthBarUI;
    public GameObject comboBarUI;
    public GameObject scoreBarUI;
    public GameObject gameBoardUI;
    
    public GameObject HotStreakUIObject;
    public int[] HotStreakThresholds;

    public static GameManager instance;

    enum Screen
    {
        MainMenu,
        SongSelectionMenu,
        PlayScreen,
        GameResultsScreen
    };
    
    // Start is called before the first frame update
    void Start()
    {
        resultsMenuUI.SetActive(false);
        instance = this;
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theNS.hasStarted = true;

                theMusic.Play();
            }
        }
        HealthBar healthValue = healthBar.GetComponent<HealthBar>();
        currentHealth = healthValue.getHealth();
        // Ensure song is at the end rather than paused
        if (startPlaying && Time.timeScale != 0 && !theMusic.isPlaying)
        {
            healthBarUI.SetActive(false);
            comboBarUI.SetActive(false);
            scoreBarUI.SetActive(false);
            gameBoardUI.SetActive(false);

            resultsMenuUI.SetActive(true);
        }
        
        // HotStreak text popup
        HotStreak hotStreak = HotStreakUIObject.GetComponent<HotStreak>();
        Combo comboText = comboBar.GetComponent<Combo>();

        if (HotStreakThresholds.All(multiplierElement => comboText.hitCount != multiplierElement)) return;
        HotStreakUIObject.SetActive(true);
        hotStreak.ShowHotStreak();
        StartCoroutine(nameof(WaitForSec));
    }

    public void NoteHit()
    {
        Combo comboText = comboBar.GetComponent<Combo>();
        Score scoreText = scoreBar.GetComponent<Score>();
        HealthBar healthValue = healthBar.GetComponent<HealthBar>();
        ResultsMenu results = resultsMenuUI.GetComponent<ResultsMenu>();

        results.goodHits += 1;
        comboText.hitCount += 1;
        scoreText.totalHit += 1;
        healthValue.addHealth();
        scoreText.addScore();
    }

    private IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        HotStreakUIObject.SetActive(false);
    }

    public void NoteMiss()
    {
        Combo comboText = comboBar.GetComponent<Combo>();
        HealthBar healthValue = healthBar.GetComponent<HealthBar>();
        ResultsMenu results = resultsMenuUI.GetComponent<ResultsMenu>();

        results.missHits += 1;
        healthValue.loseHealth();
        comboText.hitCount = 0;

        if (healthValue.getHealth() == 0.0)
        {
            Time.timeScale = 0f;
            theMusic.Pause();

            healthBarUI.SetActive(false);
            comboBarUI.SetActive(false);
            scoreBarUI.SetActive(false);
            gameBoardUI.SetActive(false);

            resultsMenuUI.SetActive(true);
        }
    }
}
