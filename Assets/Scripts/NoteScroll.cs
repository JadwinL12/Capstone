using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroll : MonoBehaviour
{
    public HealthBar healthBar;

    public float beatTempo;
    public bool hasStarted;

    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        } else
        {
            transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoseHealth(20);
            }
        }
    }

    void LoseHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
