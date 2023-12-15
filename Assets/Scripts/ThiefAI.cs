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
    [SerializeField] private float maxSpeed;

    [SerializeField] private float powerKnockback = 40f;
    [SerializeField] private float timeWhen = 1f;

    private Seeker seeker;
    private AudioSource audioSource;
    private AIPath aiPath;
    private Rigidbody2D rigi2D;

    public event Action OnRunStarted;
    public event Action OnRunFinished;

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        aiPath = GetComponent<AIPath>();
        audioSource = GetComponent<AudioSource>();
        rigi2D = GetComponent<Rigidbody2D>();

        aiPath.maxSpeed = maxSpeed;
    }

    public void Rückstoß(Vector2 dir)
    {
        aiPath.canMove = false;
        rigi2D.AddForce(dir * powerKnockback, ForceMode2D.Impulse);
        Invoke(nameof(RunAgain), timeWhen);
    }

    public void RunAgain()
    {
        aiPath.canMove = true;
        rigi2D.velocity = Vector2.zero;
        seeker.StartPath(transform.position, goal.position);
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
        rigi2D.velocity = Vector2.zero;
        OnRunFinished?.Invoke();
        dust.Stop();
        aiPath.canMove = false;
        StopCoroutine(nameof(FoodSteps_Courtine));
    }

    public void AddMovementSpeed(float amount)
    {
        aiPath.maxSpeed += amount;
        if(aiPath.maxSpeed > maxSpeed)
        {
            aiPath.maxSpeed = maxSpeed;
        }
        
    }

    public void RemoveMovementSpeed(float amount)
    {
        aiPath.maxSpeed -= amount;
        if(aiPath.maxSpeed < 3 )
        {
            aiPath.maxSpeed = 3;
        }
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
