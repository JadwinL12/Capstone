using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Track2_Difficulty : MonoBehaviour
{
    public void selectEasy()
    {
        SceneManager.LoadScene("Track2_Easy");
    }

    public void selectNormal()
    {
        SceneManager.LoadScene("Track2_Normal");
    }

    public void selectHard()
    {
        SceneManager.LoadScene("Track2_Hard");
    }
}
