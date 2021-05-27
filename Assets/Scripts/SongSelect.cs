using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelect : MonoBehaviour
{
    public void selectTrack1()
    {
        SceneManager.LoadScene("Track1_Difficulty");
    }

    public void selectTrack2()
    {
        SceneManager.LoadScene("Track2_Difficulty");
    }

    public void selectTrack3()
    {
        SceneManager.LoadScene("Track3_Difficulty");
    }
}
