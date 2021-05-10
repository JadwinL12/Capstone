using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public int scrollSpeed;
    public bool isSelected = false;

    public Text output;

    public int getSpeed()
    {
        return scrollSpeed;
    }

    public void onDropDownChange(int val)
    {
        if (val == 0)
        {
            // pass
        }
        if (val == 1)
        {
            Debug.Log("SLOW SELECTED");
            scrollSpeed = 1;
            isSelected = true;
        }
        if (val == 2)
        {
            Debug.Log("NORMAL SELECTED");
            scrollSpeed = 2;
            isSelected = true;
        }
        if (val == 3)
        {
            Debug.Log("FAST SELECTED");
            scrollSpeed = 4;
            isSelected = true;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("SongMenu");
    }
}
