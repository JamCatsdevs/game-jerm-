using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraSelector : MonoBehaviour
{
    [Header("Cameras")]
    public string[] cameraNames;           
    public Image[] cameraHighlights;       

    private int currentIndex = 0;

    public CameraManager cameraManager;

    void Start()
    {
        UpdateCamera();
    }


    public void NextCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentIndex++;

            if (currentIndex >= cameraNames.Length)
                currentIndex = 0;

            UpdateCamera();
        }
    }


    public void PreviousCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentIndex--;

            if (currentIndex < 0)
                currentIndex = cameraNames.Length - 1;

            UpdateCamera();
        }
    }

    void UpdateCamera()
    {

        cameraManager.OpenCamera(cameraNames[currentIndex]);


        for (int i = 0; i < cameraHighlights.Length; i++)
        {
            cameraHighlights[i].enabled = (i == currentIndex);
        }

        Debug.Log("Current Camera: " + cameraNames[currentIndex]);
    }
}