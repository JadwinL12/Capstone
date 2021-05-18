using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongMenu : MonoBehaviour
{
    public void Track1 ()
    {
        SceneManager.LoadScene("Game1");
    }

    public void Track2()
    {
        SceneManager.LoadScene("Game2");
    }

    public void Track3()
    {
        SceneManager.LoadScene("Game3");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
