using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public bool canBeHeld;

    public KeyCode keyMap;

    public GameObject hitEffect;

    private Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyMap))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);

                GameManager.instance.NoteHit();
            }
        }

        if (Input.GetKey(keyMap))
        {
            if (canBeHeld)
            {
                gameObject.SetActive(false);
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);

                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            canBePressed = true;
        }
        if (gameObject.tag == "HoldNote")
        {
            canBeHeld = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button")
        {
            canBePressed = false;

            GameManager.instance.NoteMiss();
        }
        if (gameObject.tag == "HoldNote")
        {
            canBeHeld = false;

            GameManager.instance.NoteMiss();
        }
    }
}
