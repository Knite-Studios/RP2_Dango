using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        // Start/Stop recording & playback with "X" key
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!playerController.IsRecording)
            {
                playerController.StartRecording();
            }
            else
            {
                playerController.StopRecordingAndPlay();
            }
        }
    }
}
