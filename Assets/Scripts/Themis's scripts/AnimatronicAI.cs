using System.Collections;
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
    public string roomGoingTo = "LeftDoor";
    public CameraToggle door;
    bool isAttacking = false;

    public PlayerHide playerHide;

    void Start()
    {
        currentRoom = rooms[Random.Range(0, rooms.Length)];
    }

    void Update()
    {
        HandleMovement();

        CheckForJumpscare();
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
    IEnumerator AttackDelay()
    {
        isAttacking = true;
        Debug.Log(name + "is waiting at the door");

        yield return new WaitForSeconds(2f);

        if(door != null && !door.rightDoorClosed)
        {
            Debug.Log(name + "Jumpscare");
        }
        else if (playerHide != null && playerHide.isHiding)
        {
            Debug.Log(name + "Can't find player(Hiding)");
            MoveBack();
        }
        else
        {
            MoveBack();
            Debug.Log(name + "blocked");
        }
        if (door != null && !door.leftDoorClosed)
        {
            Debug.Log(name + "Jumpscare");
        }
        else
        {
            MoveBack();
            Debug.Log(name + "blocked");
        }

            isAttacking = false;
    }
    void MoveBack()
    {
        currentRoom = rooms[Random.Range(0, rooms.Length - 1)];
    }
    void CheckForJumpscare()
    {
        if (currentRoom == roomGoingTo)
        {
            if (door != null && door.rightDoorClosed)
            {
                Debug.Log(name + "is blocked by the door");

                MoveBack();
            }
            else
            {
                StartCoroutine(AttackDelay());
            }
        }
        if (currentRoom == roomGoingTo)
        {
            if (door != null && door.leftDoorClosed)
            {
                Debug.Log(name + "is blocked by the door");

                MoveBack();
            }
            else
            {
                StartCoroutine(AttackDelay());
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