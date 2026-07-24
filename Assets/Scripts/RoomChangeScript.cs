using UnityEngine;

public class RoomChangeScript : MonoBehaviour
{
    public Camera mainCam;
    public Vector2 changePosition;
    public string roomChangeName;
    private DialogueManager dialogueManager;
    private CursorScript cursorManager;
    private GameObject currentItem;
    private int timeCost;

    void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        cursorManager = FindObjectOfType<CursorScript>();
    }
    void Update()
    {
        currentItem = dialogueManager.clickedItem;
        timeCost = dialogueManager.itemCost;
    }
    public void CheckCost()
    {
        cursorManager.RevertCursor();
        cursorManager.RevertText();
        if (currentItem == null)
        {
            ChangeRoom();
        }
        else
        {
            dialogueManager.clickedRoomArrow = this.gameObject;
            dialogueManager.TimeCostDialogue();
        }
    }

    public void ChangeRoom()
    {
        dialogueManager.timeRemaining -= timeCost;
        mainCam.transform.position = changePosition;
    }
}
