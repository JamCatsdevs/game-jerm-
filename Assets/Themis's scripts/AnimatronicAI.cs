using UnityEngine;

public class AnimatronicAI : MonoBehaviour
{
    [Header("Rooms")]
    public string[] rooms;              
    public string currentRoom;          // The room NPC in

    [Header("Settings")]
    public float moveInterval = 5f;     // Time between movement checks
    public float moveChance = 30f;      // % chance to move
    public float appearChance = 50f;    // % chance to appear on camera

    private float moveTimer;
    private bool isVisible = false;

    void Start()
    {
        currentRoom = rooms[Random.Range(0, rooms.Length)];
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        moveTimer += Time.deltaTime;

        if (moveTimer >= moveInterval)
        {
            moveTimer = 0f;

            float roll = Random.Range(0f, 100f);

            if (roll < moveChance)
            {
                MoveToNewRoom();
            }
        }
    }

    void MoveToNewRoom()
    {
        currentRoom = rooms[Random.Range(0, rooms.Length)];
        Debug.Log("NPC moved to: " + currentRoom);
    }
    public void CheckCamera(string cameraName)
    {
        if (currentRoom == cameraName)
        {
            float roll = Random.Range(0f, 100f);

            isVisible = (roll < appearChance);
        }
        else
        {
            isVisible = false;
        }

        gameObject.SetActive(isVisible);

        Debug.Log("Camera: " + cameraName + " | NPC Visible: " + isVisible);
    }
}