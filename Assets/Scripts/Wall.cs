using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private ParticleSystem buildVfx;

    private void Awake()
    {
        buildVfx.Play();
    }
}
