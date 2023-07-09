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

    public void OnPlayButtonAction()
    {
        audioSource.PlayOneShot(buttonAction);
    }

    public void OnPlayBuildAction()
    {
        audioSource.PlayOneShot(buildAction);
    }
}
