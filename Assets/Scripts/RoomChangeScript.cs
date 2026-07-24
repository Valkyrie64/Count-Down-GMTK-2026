using UnityEngine;

public class RoomChangeScript : MonoBehaviour
{
    public Camera mainCam;
    public Vector2 changePosition;
    public string roomChangeName;
    
    public void ChangeRoom()
    {
        mainCam.transform.position = changePosition;
    }
}
