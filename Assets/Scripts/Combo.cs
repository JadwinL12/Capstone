using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    public int hitCount;

    public int comboCount;

    public int highestCombo;

    public Text comboText;

    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
        comboCount = 0;
        comboText.text = "COMBO: 1x";
        highestCombo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        comboCount = (hitCount / 4) + 1;
        if (comboCount > 4)
        {
            comboCount = 4;
        }
        if (comboCount == 0)
        {
            comboCount = 1;
        }

        if (comboCount > highestCombo)
        {
            highestCombo = comboCount;
        }

        switch (comboCount)
        {
            case 1:
                comboText.text = "COMBO: " + "<color=white>" + comboCount.ToString() + "x" + "</color>";
                break;
            case 2:
                comboText.text = "COMBO: " + "<color=yellow>" + comboCount.ToString() + "x" + "</color>";
                break;
            case 3:
                comboText.text = "COMBO: " + "<color=green>" + comboCount.ToString() + "x" + "</color>";
                break;
            case 4:
                comboText.text = "COMBO: " + "<color=blue>" + comboCount.ToString() + "x" + "</color>";
                break;
            default:
                comboText.text = "COMBO: " + "<color=white>" + comboCount.ToString() + "x" + "</color>";
                break;
        }
    }
}
