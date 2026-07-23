using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public ItemData itemData;

    public void InterectTrigger()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, itemData);
    }
}
