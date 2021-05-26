using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffMenu : MonoBehaviour
{
    public void Easy()
    {
        SceneManager.LoadScene("Game2Easy");
    }

    public void Medium()
    {
        SceneManager.LoadScene("Game2Med");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Game2Hard");
    }

    public void Back()
    {
        SceneManager.LoadScene("SongMenu");
    }
}