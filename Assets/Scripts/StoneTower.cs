using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class StoneTower : MonoBehaviour
{
    [SerializeField] private ParticleSystem shockWaveVfx;

    private bool isActive = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive) return;
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            isActive = false;
            shockWaveVfx.Play();
            Vector2 dir =  thiefAi.transform.position - transform.position;
            thiefAi.R�cksto�(dir);
        }
    }



}
