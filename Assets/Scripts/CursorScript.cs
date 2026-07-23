using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Texture2D[] cursorTexture;
    private Vector2 cursorHotspot;
    void Start()
    {
        cursorHotspot = new Vector2(0, 0);
        Cursor.SetCursor(cursorTexture[0], cursorHotspot, CursorMode.Auto);
    }

    public void CursorQMark()
    {
        cursorHotspot = new Vector2(cursorTexture[0].width / 2, cursorTexture[0].height / 2);
        Cursor.SetCursor(cursorTexture[1], cursorHotspot, CursorMode.Auto);
    }

    public void CursorSpeech()
    {
        cursorHotspot = new Vector2(cursorTexture[0].width / 2, cursorTexture[0].height / 2);
        Cursor.SetCursor(cursorTexture[2], cursorHotspot, CursorMode.Auto);
    }

    public void RevertCursor()
    {
        cursorHotspot = new Vector2(0, 0);
        Cursor.SetCursor(cursorTexture[0], cursorHotspot, CursorMode.Auto);
    }
}
