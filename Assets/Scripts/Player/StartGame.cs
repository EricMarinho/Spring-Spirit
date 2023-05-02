using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private bool isStartGameOver = false;
    [SerializeField] private List<MonoBehaviour> scriptLists = new List<MonoBehaviour>();
    [SerializeField] private bool skipCutscene;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Animator animator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            skipCutscene = true;
        }

        if(isStartGameOver)
        {
            InitializePlayer();
        }
        if(skipCutscene)
        {
            SkipCutscene();
        }
    }

    private void SkipCutscene()
    {
        gameObject.GetComponent<Animation>().enabled = false;
        player.transform.parent = null;
        player.transform.rotation = new Quaternion(0f, -180f, 0f, 0f);
        player.transform.position = spawnPos.position;
        foreach (MonoBehaviour monoBehaviour in scriptLists)
        {
            monoBehaviour.enabled = true;
        }
        isStartGameOver = false;
        animator.SetBool("isWalking", true);
        Destroy(gameObject);
    }

    private void InitializePlayer()
    {
        foreach (MonoBehaviour monoBehaviour in scriptLists)
        {
            monoBehaviour.enabled = true;
        }
        isStartGameOver = false;
        player.transform.parent = null;
        animator.SetBool("isWalking", true);
        Destroy(gameObject);
    }
}
