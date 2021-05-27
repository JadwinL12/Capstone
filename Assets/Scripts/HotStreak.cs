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
    [FormerlySerializedAs("myPrefab")] public GameObject flamePrefab;

    private const float Lifetime = (float) 3.0;
    // Start is called before the first frame update
    private void Start()
    {
        hotStreakUIObject.SetActive(false);
    }

    public void ShowHotStreak()
    {
        _scoreText = GetComponent<Text>();
        var comboText = comboBar.GetComponent<Combo>();
        var leftCloneFlame = Instantiate(flamePrefab, new Vector3(-1, 2, 0), Quaternion.identity);
        var rightCloneFlame = Instantiate(flamePrefab, new Vector3(1, 2, 0), Quaternion.identity);
        _scoreText.text = "HOT STREAK:" + comboText.hitCount + "hits!";
        Destroy(leftCloneFlame, Lifetime);
        Destroy(rightCloneFlame, Lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
