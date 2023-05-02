using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWithBoundController : MonoBehaviour
{

    private Quaternion camRotation;

    private void Start()
    {
        camRotation = transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        camRotation.x += mouseY * Time.deltaTime * 120 * (-1);
        camRotation.x = Mathf.Clamp(camRotation.x, -90, 90);
        transform.localRotation = Quaternion.Euler(camRotation.x, 0, 0);
    }
}
