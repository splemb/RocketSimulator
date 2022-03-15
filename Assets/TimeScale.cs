using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [SerializeField] float timeScale;

    private void Update()
    {
        if (Time.timeScale != timeScale)
            Time.timeScale = timeScale;
    }
}
