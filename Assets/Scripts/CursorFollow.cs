using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorFollow : MonoBehaviour
{
    float zAxis = 2f;
    public Camera mainCam;

    void Update()
    {
       var worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
       transform.position = new Vector3(worldPos.x, worldPos.y, zAxis);
    }
}
