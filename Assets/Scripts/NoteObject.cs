using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyMap;

    public GameObject hitEffect;

    private ScoreTracker _scoreTracker;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(keyMap))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                _scoreTracker = FindObjectOfType<ScoreTracker>();
                _scoreTracker.ScoreHit(_scoreTracker.currentMultiplier);
                if (_scoreTracker.currentMultiplier < 2)
                {
                    _scoreTracker.currentMultiplier += 1;
                }
                else
                {
                    foreach (var t in _scoreTracker.multiplierThresholds)
                    {
                        if (_scoreTracker.currentMultiplier >= t) continue;
                        _scoreTracker.currentMultiplier = t;
                        break;
                    }
                }
                //Debug.Log(_scoreTracker.currentMultiplier);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Button"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            canBePressed = false;
            _scoreTracker = FindObjectOfType<ScoreTracker>();
            _scoreTracker.currentMultiplier = 1;
        }
    }
}
