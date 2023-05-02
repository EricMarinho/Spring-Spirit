using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{

    [SerializeField] private Transform cameraPos;
    [SerializeField] private Transform interactablesTransform;
    public bool isPossessing { get; private set; } = false;

    public PossessedObject currentPossessedObject;

    public static InteractBehaviour instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private PlayerController playerControllerInstance;

    private void Start()
    {
        playerControllerInstance = PlayerController.instance;
    }

    private void Update()
    {
        if (isPossessing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StopPossessing();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interaction"))
        {
            UIHandler.instance.ShowInteractionUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interaction"))
        {
            if (!isPossessing)
            {
                UIHandler.instance.HideInteractionUI();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interaction"))
        {
            if (!isPossessing)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PossessObject(other.gameObject);
                }
            }
        }
    }

    private void PossessObject(GameObject possessedGameObject)
    {
        currentPossessedObject = possessedGameObject.GetComponent<PossessedObject>();
        if (!currentPossessedObject.isKinematic)
        {
            currentPossessedObject.rb.isKinematic = true;
        }
        else
        {
            playerControllerInstance.rigidbodyRb.transform.position = currentPossessedObject.cameraPos.position;
            playerControllerInstance.rigidbodyRb.transform.rotation = currentPossessedObject.cameraPos.rotation;
        }
        currentPossessedObject.possessedTransform.transform.parent = gameObject.transform;
        UIHandler.instance.ShowInteractionUI();
        UIHandler.instance.ShowStopInteractionText();
        StartCoroutine(PossesDelay());
    }

    private IEnumerator PossesDelay()
    {
        yield return new WaitForSeconds(0.25f);
        isPossessing = true;
    }

    public void StopPossessing()
    {
        isPossessing = false;
        UIHandler.instance.ShowInteractionText();
        UIHandler.instance.HideInteractionUI();
        currentPossessedObject.possessedTransform.transform.SetParent(interactablesTransform);
        if (!currentPossessedObject.isKinematic)
        {
            currentPossessedObject.rb.isKinematic = false;
        }

    }
}
