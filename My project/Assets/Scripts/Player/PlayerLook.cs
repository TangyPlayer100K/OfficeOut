using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 300f;

    public Transform playerBody;

    private float xRotation = 0f;

    bool canLook = true;
    void Start()
    {
        LockLook();
    }

    // Update is called once per frame
    void Update()
    {
        if (canLook == true)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        } 
    }
    public void LockLook()
    {
        canLook = false;
    }
    public void FreeLook()
    {
        canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
