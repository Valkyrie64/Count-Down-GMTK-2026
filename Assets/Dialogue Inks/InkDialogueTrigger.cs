using UnityEngine;
using UnityEngine.UI;
public class InkDialogueTrigger : MonoBehaviour
{
    [SerializeField] private InkDialogueManager inkDialogueManager;
    [SerializeField] private TextAsset inkJSON;
    private GameObject itemGO;

    void Awake()
    {
        inkDialogueManager = FindObjectOfType<InkDialogueManager>();
        itemGO = this.gameObject;
    }

    public void ItemInteract()
    {
        if (!inkDialogueManager.dialogueIsPlaying)
        {
            inkDialogueManager.EnterDialogue(inkJSON, itemGO);
        }
    }
}
