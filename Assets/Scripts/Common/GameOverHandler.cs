using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private GameObject gameLostCanvas;
    [SerializeField] private List<MonoBehaviour> scriptLists = new List<MonoBehaviour>();
    [SerializeField] private NavMeshAgent boyNavMesh;
    [SerializeField] private Rigidbody boyRb;
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text deathReasonText;

    //Singleton
    public static GameOverHandler instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void StartGameOver(string deathReason)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        UIHandler.instance.HideInteractionUI();

        foreach (MonoBehaviour monoBehaviour in scriptLists)
        {
            monoBehaviour.enabled = false;
        }

        animator.SetBool("isWalking", false);
        boyNavMesh.enabled = false;
        boyRb.freezeRotation = false;

        gameLostCanvas.SetActive(true);
        deathReasonText.SetText(deathReason);
    }

}
