using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNoteScroll : MonoBehaviour
{
    public HealthBar healthBar;

    public float beatTempo;

    public float secPerBeat;

    public float songPosition;

    public float songPositionInBeats;

    public float firstBeatOffset;

    public float dspSongTime;

    public bool hasStarted;

    public bool gameEnd;

    public int maxHealth = 100;
    public int currentHealth;

    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        gameEnd = false;
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        beatTempo = beatTempo / 60f;
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / beatTempo;
        dspSongTime = (float)AudioSettings.dspTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnd)
        {
            if (!hasStarted)
            {
                if (Input.anyKeyDown)
                {
                    hasStarted = true;
                    musicSource.PlayDelayed(3.0f);
                }
            }
            else
            {
                transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    LoseHealth(20);
                }
            }

            songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

            songPositionInBeats = songPosition / secPerBeat;
        }
    }

    void LoseHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    public void stopScroll()
    {
        hasStarted = false;
        gameEnd = true;
        musicSource.Stop();
    }
}
