using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Preloader : MonoBehaviour
{
    [FormerlySerializedAs("PreloaderUI")] public GameObject preloaderUI;
    private float _loadTime;
    private const float MinimumLogoTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        var initialText = preloaderUI.GetComponent<Text>();

        _loadTime = Time.time < MinimumLogoTime ? MinimumLogoTime : Time.time;

        Debug.Log(_loadTime);
        initialText.canvasRenderer.SetAlpha(1);
        initialText.CrossFadeAlpha((float) 0.01, _loadTime, false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
