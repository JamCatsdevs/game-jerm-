using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PlayerHide playerHide;
    public CameraToggle cameraToggle; 
    public bool isOpen = false;

    public void OnHide(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!cameraToggle.isOpen)   
            {
                playerHide.ToggleHide();
            }
        }
    }
}