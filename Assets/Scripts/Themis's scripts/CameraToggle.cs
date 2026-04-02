using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class CameraToggle : MonoBehaviour
{
    public GameObject cameraUI;
    public GameObject officeUI;

    private bool isOpen = false;
    public bool rightDoorClosed = false;
    public bool leftDoorClosed = false;


    public PlayerHide playerHide;

    [Header("Visuals")]
    public GameObject leftDooooooor;
    public GameObject rightDooooooor;

    [Header("Camera Switching")]
    public string[] cameraNames;
    public GameObject[] cameraHighlights;

    private int currentIndex = 0;

    public CameraManager cameraManager;

    [Header("Input")]
    public InputActionAsset inputActionAsset;
    private InputAction CloseTheLeftDoor;
    private InputAction CloseTheRightDoor;
    private InputAction toggleCameraAction;
    private InputAction HIDEEEEE;
    private InputAction LemmeSeee;
    private void OnEnable()
    {
        var NPCActionMap = inputActionAsset.FindActionMap("Player");

        CloseTheLeftDoor = NPCActionMap.FindAction("Open Door L");
        CloseTheRightDoor = NPCActionMap.FindAction("Open Door R");
        toggleCameraAction = NPCActionMap.FindAction("Open Camera");
        HIDEEEEE = NPCActionMap.FindAction("Peek? NO HIDE");
        LemmeSeee = NPCActionMap.FindAction("Hmm Let me look at those");

        NPCActionMap.Enable();

        CloseTheLeftDoor.Enable();
        CloseTheRightDoor.Enable();
        toggleCameraAction.Enable();
        HIDEEEEE.Enable();
        LemmeSeee.Enable();


        CloseTheLeftDoor.performed += OnLeftDoorInteract;
        CloseTheRightDoor.performed += OnRightDoorInteract;
        toggleCameraAction.performed += OnToggleCamera;
        HIDEEEEE.performed += OnHideUnderDesk;
        LemmeSeee.performed += OnToggleView;
    }

    private void OnDisable()
    {
        CloseTheLeftDoor.Disable();
        CloseTheRightDoor.Disable();
        toggleCameraAction.Disable();
        HIDEEEEE.Disable();
        LemmeSeee.Disable();


        CloseTheRightDoor.canceled -= OnLeftDoorInteract;
        CloseTheLeftDoor.canceled -= OnRightDoorInteract;
        toggleCameraAction.canceled -= OnToggleCamera;
        HIDEEEEE.canceled -= OnHideUnderDesk;
        LemmeSeee.canceled -= OnToggleView;


    }

    private void Update()
    {
       
        
    }
    void OnToggleView(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
    void OnHideUnderDesk(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            playerHide.ToggleHide();
            Debug.Log("Player has hidden: ");
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