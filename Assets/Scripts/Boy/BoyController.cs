using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoyController : MonoBehaviour
{
    [SerializeField] private List<Transform> destinationTransforms;
    private Transform destination;
    private NavMeshAgent agent;
    private string deathReason = "You failed protecting the boy";

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeBoyDestination();
    }

    private void Update()
    {
        agent.SetDestination(destination.position);

    }

    public void ChangeBoyDestination()
    {
        if (destinationTransforms.Count <= 0)
            return;

        destination = destinationTransforms[0];
        destinationTransforms.RemoveAt(0);
    }

    public void SetBoyDestinationPath(Queue<Transform> newTransforms)
    {
        foreach(Transform transform in newTransforms)
        {
            destinationTransforms.Add(transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Destination"))
        {
            ChangeBoyDestination();
        }
        
        else if(other.CompareTag("Damage"))
        {
            deathReason = other.GetComponent<KillBoyHandler>().deathString;
            GameOverHandler.instance.StartGameOver(deathReason);
        }

        else if (other.CompareTag("Win"))
        {
            WinGameHandler.instance.StartWinGame();
        }

    }

}
