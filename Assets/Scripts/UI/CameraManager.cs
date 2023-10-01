using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public void SwitchCamera(Transform newPos)
    {
        Debug.Log("Switching camera");
        transform.position = new Vector3(newPos.transform.position.x,newPos.transform.position.y,transform.position.z);   // move screen to new position
    }


}
