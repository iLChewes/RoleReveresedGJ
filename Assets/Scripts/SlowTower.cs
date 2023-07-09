using UnityEngine;

public class SlowTower : MonoBehaviour
{
    [SerializeField] private float SlowDownAmount = 4.0f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            thiefAi.RemoveMovementSpeed(SlowDownAmount);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefAI>(out ThiefAI thiefAi))
        {
            thiefAi.AddMovementSpeed(SlowDownAmount);
        }
    }
}
