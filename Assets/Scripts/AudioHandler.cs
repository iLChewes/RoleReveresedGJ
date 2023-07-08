using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip buttonAction;
    [SerializeField] private AudioClip buildAction;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPlayBuildAction();
        }
    }

    public void OnPlayButtonAction()
    {
        audioSource.PlayOneShot(buttonAction);
    }

    public void OnPlayBuildAction()
    {
        audioSource.PlayOneShot(buildAction);
    }
}
