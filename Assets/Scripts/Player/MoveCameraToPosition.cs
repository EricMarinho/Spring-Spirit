using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToPosition : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform destinyTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float camMoveSpeed = 5f;
    [SerializeField] private GameObject winGameCutscene;

    private void Update()
    {
        playerTransform.position = Vector3.Lerp(playerTransform.position, destinyTransform.position, camMoveSpeed * Time.deltaTime);
        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, destinyTransform.rotation, camMoveSpeed * Time.deltaTime);
        cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, destinyTransform.rotation, camMoveSpeed * Time.deltaTime);

        if (Vector3.Distance(playerTransform.position, destinyTransform.position) < 0.01f)
        {
            playerTransform.position = destinyTransform.position;
            playerTransform.rotation = destinyTransform.rotation;
            winGameCutscene.SetActive(true);
            enabled = false;
        }
    }

}
