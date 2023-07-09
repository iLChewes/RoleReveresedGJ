using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class StoneTower : MonoBehaviour
{
    [SerializeField] private ParticleSystem shockWaveVfx;

    private bool isActive = true;
    private ThiefAI thiefAi;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive) return;
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            this.thiefAi = thiefAi;
            isActive = false;
            shockWaveVfx.Play();
            this.thiefAi.OnRunFinished += ResetActive;
            Vector2 dir =  thiefAi.transform.position - transform.position;
            thiefAi.Rückstoß(dir);
        }
    }


    private void ResetActive()
    {
        isActive = true;
        this.thiefAi.OnRunFinished -= ResetActive;
    }


}
