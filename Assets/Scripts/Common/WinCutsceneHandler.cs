using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCutsceneHandler : MonoBehaviour
{
    [SerializeField] private Animation cutsceneAnimation;
    [SerializeField] private Animation beeAnimation;
    [SerializeField] private List<Transform> cutsceneObjectsCutscene;
    [SerializeField] private Transform flowerTransform;
    [SerializeField] private Transform boyTransform;

    private void Start()
    {
        foreach (Transform cutsceneObject in cutsceneObjectsCutscene)
        {
            cutsceneObject.transform.SetParent(transform);
        }
        boyTransform.SetParent(transform);
        flowerTransform.SetParent(boyTransform);
        beeAnimation.Stop();
        StartWinCutscene();
    }

    public void StartWinCutscene()
    {
        cutsceneAnimation.Play();
    }

}
