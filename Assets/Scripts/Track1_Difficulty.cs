using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Track1_Difficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public void selectEasy()
    {
        SceneManager.LoadScene("Track1_Easy");
    }

    public void selectNormal()
    {
        SceneManager.LoadScene("Track1_Medium");
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
