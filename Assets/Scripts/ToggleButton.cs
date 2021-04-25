using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    private AudioSource audioSource;

    public bool toggle = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.Stop();
    }
    
    // TODO change button and create new script for effect/sound

    // Update is called once per frame
    void Update()
    {
        
    }
}
