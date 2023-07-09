using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlyToUI : MonoBehaviour
{
    private GameObject flyTo;

    public void StartFlying()
    {
        var rigi = GetComponent<Rigidbody2D>();
        rigi.simulated = false;
        rigi.gravityScale = 0f;

        StartCoroutine(nameof(Flying_Courtine));
    }

    private IEnumerator Flying_Courtine()
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(flyTo.transform.position);

        while(Vector3.Distance(transform.position, worldPosition) > 0.001f)
        {
            var step = 10 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, worldPosition, step);
            yield return null;
        }

        GoldManager.Instance.AddGold(1);
        Destroy(gameObject);
    }

    public void SetFlyTo(GameObject flyTo)
    {
        this.flyTo = flyTo;
    }
}
