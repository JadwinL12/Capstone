using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public NoteScroll theNS;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    public static GameManager instance;

    enum Screen
    {
        MainMenu,
        SongSelectionMenu,
        PlayScreen,
        GameResultsScreen
    };

    Screen currentScreen = Screen.MainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theNS.hasStarted = true;

                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");
    }

    public void NoteMiss()
    {
        currentHealth -= 10;
        healthBar.setHealth(currentHealth);
    }
}
