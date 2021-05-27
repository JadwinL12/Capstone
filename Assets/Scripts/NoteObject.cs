using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyMap;

    public GameObject hitEffect;

    public GameObject goodEffect;

    public GameObject perfectEffect;

    public GameObject missEffect;

    private Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        canBePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(keyMap))
        //{
        //    if (canBePressed)
        //    {
        //        gameObject.SetActive(false);
        //        Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);

        //        GameManager.instance.NoteHit();
        //    }
        //}
        if (transform.position.z < 0.30 && transform.position.z > -0.30)
        {
            canBePressed = true;
        }

        if (transform.position.z < -0.5)
        {
            gameObject.SetActive(false);
            GameManager.instance.NoteMiss();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Button")
    //    {
    //        canBePressed = true;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (canBePressed)
        {
            gameObject.SetActive(false);
            Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            if (transform.position.z > 0.10 || transform.position.z < -0.10)
            {
                GameManager.instance.NoteGoodHit();
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                Debug.Log("Good Hit");
            }
            else
            {
                GameManager.instance.NotePerfectHit();
                Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                Debug.Log("Perfect Hit");
            }
        } else if (gameObject.tag == "HoldNote")
        {
            gameObject.SetActive(false);
            Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            if (transform.position.z > 0.10 || transform.position.z < -0.10)
            {
                GameManager.instance.NoteGoodHit();
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                Debug.Log("Good Hit");
            }
            else
            {
                GameManager.instance.NotePerfectHit();
                Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                Debug.Log("Perfect Hit");
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Button")
    //    {
    //        canBePressed = false;

    //        GameManager.instance.NoteMiss();
    //        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
    //    }
    //}

    //private void OnMouseDown()
    //{
    //    if (canBePressed)
    //    {
    //        gameObject.SetActive(false);
    //        Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
    //        if (transform.position.z > 0.15 || transform.position.z < -0.15)
    //        {
    //            GameManager.instance.NoteGoodHit();
    //            Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
    //            Debug.Log("Good Hit");
    //        }
    //        else
    //        {
    //            GameManager.instance.NotePerfectHit();
    //            Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
    //            Debug.Log("Perfect Hit");
    //        }
    //    }
    //}
}
