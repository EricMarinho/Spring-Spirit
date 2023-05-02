using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WinGameHandler : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> scriptsToDeactivate;
    [SerializeField] private Transform beeTransform;
    [SerializeField] private NavMeshAgent boyNavMesh;
    [SerializeField] private Animator boyAnimator;
    [SerializeField] private Animation flowerAnimation;
    [SerializeField] private MoveCameraToPosition moveCameraToPosition;
    [SerializeField] private BoxCollider beeCollider;
    [SerializeField] private BoxCollider playerCollider;

    public static WinGameHandler instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    public void StartWinGame()
    {
        foreach(MonoBehaviour monoBehaviour in scriptsToDeactivate)
        {
            monoBehaviour.enabled = false;
        }
        beeTransform.position = new Vector3(0f, -100f, 0f);
        boyAnimator.SetBool("isWalking", false);
        flowerAnimation.enabled = false;
        boyNavMesh.enabled = false;
        moveCameraToPosition.enabled = true;
        beeCollider.enabled = false;
        playerCollider.enabled = false;
        InteractBehaviour.instance.StopPossessing();
    }

}
