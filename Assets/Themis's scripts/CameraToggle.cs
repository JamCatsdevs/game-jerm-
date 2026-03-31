using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public GameObject cameraUI;
    public GameObject officeUI;

    private bool isOpen = false;

    public void ToggleCamera()
    {
        isOpen = !isOpen;

        cameraUI.SetActive(isOpen);
        officeUI.SetActive(!isOpen);
    }
}