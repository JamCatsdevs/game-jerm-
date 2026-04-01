using UnityEngine;
using UnityEngine.InputSystem;

public class CameraToggle : MonoBehaviour
{
    public GameObject cameraUI;
    public GameObject officeUI;

    private bool isOpen = false;
    public bool rightDoorClosed = false;
    public bool leftDoorClosed = false;

    [Header("Visuals")]
    public GameObject leftDooooooor;
    public GameObject rightDooooooor;

    [Header("Input")]
    public InputActionAsset inputActionAsset;
    private InputAction CloseTheLeftDoor;
    private InputAction CloseTheRightDoor;
    private InputAction toggleCameraAction;

    private void OnEnable()
    {
        var NPCActionMap = inputActionAsset.FindActionMap("Player");

        CloseTheLeftDoor = NPCActionMap.FindAction("Open Door L");
        CloseTheRightDoor = NPCActionMap.FindAction("Open Door R");
        toggleCameraAction = NPCActionMap.FindAction("Open Camera");

        NPCActionMap.Enable();

        CloseTheLeftDoor.Enable();
        CloseTheRightDoor.Enable();
        toggleCameraAction.Enable();

        CloseTheLeftDoor.performed += OnLeftDoorInteract;
        CloseTheRightDoor.performed += OnRightDoorInteract;
        toggleCameraAction.performed += OnToggleCamera;

    }

    private void OnDisable()
    {
        CloseTheLeftDoor.Disable();
        CloseTheRightDoor.Disable();
        toggleCameraAction.Disable();

        CloseTheRightDoor.canceled -= OnLeftDoorInteract;
        CloseTheLeftDoor.canceled -= OnRightDoorInteract;
        toggleCameraAction.performed -= OnToggleCamera;
    }

    private void Update()
    {
       
        
    }

    void OnToggleCamera(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            ToggleCamera();
            Debug.Log("Camera has open: ");
        }
    }
    void OnLeftDoorInteract(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            leftDoorClosed = !leftDoorClosed;
            leftDooooooor.SetActive(leftDoorClosed);
            Debug.Log("Left Door closed: " + leftDoorClosed);
        }
    }
    void OnRightDoorInteract(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            rightDoorClosed = !rightDoorClosed;
            rightDooooooor.SetActive(rightDoorClosed);
            Debug.Log("Right Door closed: " + rightDoorClosed);
        }
    }


    public void ToggleCamera()
    {
        isOpen = !isOpen;

        cameraUI.SetActive(isOpen);
        officeUI.SetActive(!isOpen);
    }
}