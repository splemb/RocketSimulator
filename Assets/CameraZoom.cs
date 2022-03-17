using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    CinemachineBrain brain;

    private void Start()
    {
        brain = GetComponent<CinemachineBrain>();

    }
}
