using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform CameraHolder;
    public static float mouseSensitivity = 1;
    float verticalLookRotation;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused && !Timer.gameOver)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Locked;
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
            verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            CameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
