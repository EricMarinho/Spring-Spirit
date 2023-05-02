using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedObject : MonoBehaviour
{
    public Transform possessedTransform;
    public Transform cameraPos;

    [Header("Optional")]
    public bool isKinematic = true;
    public Rigidbody rb;
}
