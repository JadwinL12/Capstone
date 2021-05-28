using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Track1_Difficulty : MonoBehaviour
{
    public void selectEasy()
    {
        SceneManager.LoadScene("Track1_Easy");
    }

    public void selectNormal()
    {
        SceneManager.LoadScene("Track1_Normal");
    }

    public void selectHard()
    {
        SceneManager.LoadScene("Track1_Hard");
    }

    public void goBack()
    {
        SceneManager.LoadScene("SongSelect");
    }
}
