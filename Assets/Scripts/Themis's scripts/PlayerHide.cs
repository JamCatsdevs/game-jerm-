using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    [Header("Camera Positions")]
    public Transform normalPosition;
    public Transform hidePosition;

    [Header("Settings")]
    public float moveSpeed = 5f;

    public bool isHiding = false;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        MoveCamera();
    }

    public void ToggleHide()
    {
        isHiding = !isHiding;
        Debug.Log("Hiding: " + isHiding);
    }

    void MoveCamera()
    {
        Transform target = isHiding ? hidePosition : normalPosition;

        mainCam.transform.position = Vector3.Lerp(
            mainCam.transform.position,
            target.position,
            Time.deltaTime * moveSpeed
        );

        mainCam.transform.rotation = Quaternion.Lerp(
            mainCam.transform.rotation,
            target.rotation,
            Time.deltaTime * moveSpeed
        );
    }
}