using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyMap;

    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyMap))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);

                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button")
        {
            canBePressed = false;

            GameManager.instance.NoteMiss();
        }
    }
}
