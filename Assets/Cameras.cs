using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cameras : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    [SerializeField] int current = 1;

    public void NextCamera()
    {
        current++;

        if (current >= cameras.Length) current = 0;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == current) cameras[i].SetActive(true);
            else cameras[i].SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
