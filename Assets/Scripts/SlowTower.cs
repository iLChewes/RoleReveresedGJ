using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            thiefAi.RemoveMovementSpeed(2f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            thiefAi.AddMovementSpeed(2f);
        }
    }
}
