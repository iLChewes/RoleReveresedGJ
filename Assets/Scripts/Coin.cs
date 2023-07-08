using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(DestroySelf), 3f);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
