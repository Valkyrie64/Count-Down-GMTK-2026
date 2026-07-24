using UnityEngine;
using UnityEngine.UI;

public class ItemCursorSet : MonoBehaviour
{
    [SerializeField] private CursorScript cursorManager;
    [SerializeField] private Button button;
    void Awake()
    {
        cursorManager = FindObjectOfType<CursorScript>().GetComponent<CursorScript>();
    }

    public void CursorSet()
    {
        if (button.interactable)
        {
            cursorManager.CursorSpeech();
        }
    }

    public void RevertItem()
    {
        if (button.interactable)
        {
            cursorManager.RevertCursor();
        }
    }
}
