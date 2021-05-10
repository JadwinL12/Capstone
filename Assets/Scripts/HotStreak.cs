using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HotStreak : MonoBehaviour
{
    [FormerlySerializedAs("HotStreakUIObject")] public GameObject hotStreakUIObject;
    public GameObject comboBar;
    private Text _scoreText;
    // Start is called before the first frame update
    private void Start()
    {
        hotStreakUIObject.SetActive(false);
    }

    public void ShowHotStreak()
    {
        _scoreText = GetComponent<Text>();
        var comboText = comboBar.GetComponent<Combo>();
        _scoreText.text = "HOT STREAK:" + comboText.hitCount + "hits!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
