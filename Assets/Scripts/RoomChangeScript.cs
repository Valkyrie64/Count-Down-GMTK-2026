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
    [SerializeField] private AudioSource clickSource;
    [SerializeField] private AudioClip clickSound;

    void Awake()
    {
        dialogueManager = FindObjectOfType<InkDialogueManager>();
        cursorManager = FindObjectOfType<CursorScript>();
    }
    void Update()
    {
        currentItem = dialogueManager.dialogueItemName;
        timeCost = dialogueManager.dialogueItemCost;
        if (dialogueManager.timeRemaining <= 0)
        {
            EndGameTrigger();
        }
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
        clickSource.PlayOneShot(clickSound);
        dialogueManager.timeRemaining -= timeCost;
        mainCam.transform.position = changePosition;
    }

    private void EndGameTrigger()
    {
        mainCam.transform.position = new Vector3(0, 0, -12);
    }
}
