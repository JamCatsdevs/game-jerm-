using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    [Header("Camera Position")]
    public Transform normalPosition;
    public Transform hidePosition;

    [Header("Settings")]
    public float movespped = 5f;

    public bool isHiding = false;
    private Camera mainCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     mainCam = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    public void ToggleHide()
    {
        isHiding = !isHiding;
        Debug.Log("Hiding" + isHiding);
    }

    void MoveCamera()
    {
        Vector3 targetPos = isHiding ? hidePosition.position : normalPosition.position;

        mainCam.transform.position = Vector3.Lerp(mainCam .transform.position, targetPos, Time.deltaTime * movespped);
    }
}
