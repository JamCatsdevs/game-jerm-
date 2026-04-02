using UnityEngine;
using UnityEngine.InputSystem;

public class CameraToggle : MonoBehaviour
{
    public GameObject cameraUI;
    public GameObject officeUI;

    public bool isOpen = false;
    public bool rightDoorClosed = false;
    public bool leftDoorClosed = false;

    PlayerHide playerHide;

    [Header("Visuals")]
    public GameObject leftDooooooor;
    public GameObject rightDooooooor;

    [Header("Input")]
    public InputActionAsset inputActionAsset;
    private InputAction CloseTheLeftDoor;
    private InputAction CloseTheRightDoor;
    private InputAction toggleCameraAction;
    private InputAction hideUnderZaTable;

    private void OnEnable()
    {
        var NPCActionMap = inputActionAsset.FindActionMap("Player");

        CloseTheLeftDoor = NPCActionMap.FindAction("Open Door L");
        CloseTheRightDoor = NPCActionMap.FindAction("Open Door R");
        toggleCameraAction = NPCActionMap.FindAction("Open Camera");
        hideUnderZaTable = NPCActionMap.FindAction("Hide Hide Hide");

        NPCActionMap.Enable();

        CloseTheLeftDoor.Enable();
        CloseTheRightDoor.Enable();
        toggleCameraAction.Enable();
        hideUnderZaTable.Enable();

        CloseTheLeftDoor.performed += OnLeftDoorInteract;
        CloseTheRightDoor.performed += OnRightDoorInteract;
        toggleCameraAction.performed += OnToggleCamera;
        hideUnderZaTable.performed += OnToggleHide;

    }

    private void OnDisable()
    {
        CloseTheLeftDoor.Disable();
        CloseTheRightDoor.Disable();
        toggleCameraAction.Disable();
        hideUnderZaTable.Disable();

        CloseTheRightDoor.canceled -= OnLeftDoorInteract;
        CloseTheLeftDoor.canceled -= OnRightDoorInteract;
        toggleCameraAction.performed -= OnToggleCamera;
        hideUnderZaTable.performed -= OnToggleHide;
    }

    private void Update()
    {
       
        
    }

    void OnToggleHide(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            playerHide.ToggleHide();
            Debug.Log("Player has hidden");
        }
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