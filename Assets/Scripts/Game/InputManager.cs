using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerController playerController;

    private void Update()
    {
        // Handling movement
        float moveX = Input.GetAxis("Horizontal");
        playerController.Move(moveX);

        // Handling gravity switch with 'S'
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerController.SwitchGravity();
        }

        // Handling dimension switch with 'X'
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerController.SwitchDimension();
        }
    }
}
