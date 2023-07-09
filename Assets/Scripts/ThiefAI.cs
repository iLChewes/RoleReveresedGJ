using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ThiefAI : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private AudioClip[] foodStepSounds;

    private Seeker seeker;
    private AudioSource audioSource;
    private AIPath aiPath;

    public event Action OnRunStarted;
    public event Action OnRunFinished;

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        aiPath = GetComponent<AIPath>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnStartRun()
    {
        Debug.Log("Theif Start run");
        OnRunStarted?.Invoke();
        dust.Play();
        aiPath.canMove = true;
        seeker.StartPath(transform.position, goal.position);
        StartCoroutine(nameof(FoodSteps_Courtine));
    }

    public void OnReachedGoal()
    {
        OnRunFinished?.Invoke();
        dust.Stop();
        aiPath.canMove = false;
        StopCoroutine(nameof(FoodSteps_Courtine));
    }


    private IEnumerator FoodSteps_Courtine()
    {
        while (true)
        {
            audioSource.PlayOneShot(GetRandomAudioClip(foodStepSounds));
            yield return new WaitForSeconds(0.22f);
        }
    }

    private AudioClip GetRandomAudioClip(AudioClip[] audioClips)
    {
        return audioClips[UnityEngine.Random.Range(0,audioClips.Length)];
    }
}
