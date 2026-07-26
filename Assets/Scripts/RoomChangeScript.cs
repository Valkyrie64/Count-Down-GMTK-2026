using UnityEngine;

public class RoomChangeScript : MonoBehaviour
{
    public Camera mainCam;
    public Vector3 changePosition;
    public TextAsset inkJSON;
    private InkDialogueManager dialogueManager;
    private CursorScript cursorManager;
    private string currentItem;
    private int timeCost;

    void Awake()
    {
        dialogueManager = FindObjectOfType<InkDialogueManager>();
        cursorManager = FindObjectOfType<CursorScript>();
    }
    void Update()
    {
        currentItem = dialogueManager.dialogueItemName;
        timeCost = dialogueManager.dialogueItemCost;
    }
    public void CheckCost()
    {
        cursorManager.RevertCursor();
        cursorManager.RevertText();
        if (currentItem == "")
        {
            ChangeRoom();
        }
        else
        {
            dialogueManager.clickedRoomArrow = this.gameObject;
            dialogueManager.EnterDialogue(inkJSON, null);
        }
    }

    public void ChangeRoom()
    {
        dialogueManager.timeRemaining -= timeCost;
        mainCam.transform.position = changePosition;
    }
}
