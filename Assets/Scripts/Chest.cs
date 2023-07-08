using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            thiefAi.OnReachedGoal();
        }
    }

}
