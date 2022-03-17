using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeScale : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI buttonText;

    float timeScale;

    void Start()
    {
        buttonText.text = "I I";
    }

    public void ChangeTimeScale()
    {
        Time.timeScale = slider.value;
        timeScale = Time.timeScale;
        buttonText.text = "I I";
    }

    public void Pause()
    {
        Time.timeScale = 0;
        buttonText.text = "▶";
    }

    public void Unpause()
    {
        if (timeScale > 1)
            Time.timeScale = timeScale;
        else
            Time.timeScale = 1;
        buttonText.text = "I I";
    }

    public void PausePressed()
    {
        if (Time.timeScale > 0) Pause();
        else Unpause();
    }
}
