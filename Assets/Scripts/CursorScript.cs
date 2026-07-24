using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Sprite[] cursorTexture;
    float zAxis = 2f;
    public Camera mainCam;
    public SpriteRenderer cursorRenderer;
    public TMP_Text cursorText;
    void Start()
    {
        cursorRenderer.sprite = cursorTexture[0];
        Cursor.visible = false;
    }
    
    void Update()
    {
        var worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector3(worldPos.x, worldPos.y, zAxis);
    }

    public void CursorQMark()
    {
        cursorRenderer.sprite = cursorTexture[1];
    }

    public void CursorSpeech()
    {
        cursorRenderer.sprite = cursorTexture[2];
    }

    public void CursorPointer()
    {
        cursorRenderer.sprite = cursorTexture[3];
    }

    public void RevertCursor()
    {
        cursorRenderer.sprite = cursorTexture[0];
    }

    public void ShowRoof()
    {
        cursorText.text = "Roof";
    }

    public void ShowLRoom()
    {
        cursorText.text = "Living Room";
    }

    public void ShowKitchen()
    {
        cursorText.text = "Kitchen";
    }

    public void ShowBedroom()
    {
        cursorText.text = "Bedroom";
    }

    public void RevertText()
    {
        cursorText.text = "";
    }
}
