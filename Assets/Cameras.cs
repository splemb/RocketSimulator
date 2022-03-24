using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cameras : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    [SerializeField] int current = 1;
    [SerializeField] TMPro.TextMeshProUGUI cameraText;

    private void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == current) cameras[i].SetActive(true);
            else cameras[i].SetActive(false);
        }

        cameraText.text = (current + 1).ToString();
    }

    public void NextCamera()
    {

        current++;

        if (current >= cameras.Length) current = 0;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == current) cameras[i].SetActive(true);
            else cameras[i].SetActive(false);
        }

        cameraText.text = (current + 1).ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
