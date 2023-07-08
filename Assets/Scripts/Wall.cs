using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private AudioClip buildSound;
    [SerializeField] private ParticleSystem buildVfx;

    private AudioSource source;

    private void Awake()
    {
        source= GetComponent<AudioSource>();
        source.PlayOneShot(buildSound);
        buildVfx.Play();
    }
}
