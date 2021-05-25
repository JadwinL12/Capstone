using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Track3_Difficulty : MonoBehaviour
{
    public void selectEasy()
    {
        SceneManager.LoadScene("Track3_Easy");
    }

    public void selectNormal()
    {
        SceneManager.LoadScene("Track3_Medium");
    }

    public void selectHard()
    {
        SceneManager.LoadScene("Track3_Hard");
    }
}
