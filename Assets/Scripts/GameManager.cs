using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum Screen
    {
        MainMenu,
        SongSelectionMenu,
        PlayScreen,
        GameResultsScreen
    };

    Screen currentScreen = Screen.MainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
