using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;

    private int currentCameraIndex = 0;


    private void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        cameras[currentCameraIndex].gameObject.SetActive(true);
    }

    public void SwitchCam(int camNum)
    {
        currentCameraIndex = camNum;
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        cameras[currentCameraIndex].gameObject.SetActive(true);
    }


}
