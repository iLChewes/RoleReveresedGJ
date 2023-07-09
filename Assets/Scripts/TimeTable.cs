using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTable : MonoBehaviour
{
    [SerializeField] private GameObject timeCartPrefab;

    public List<TimeCart> timeCartList = new List<TimeCart>();

    public static TimeTable Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void CreateTimeCart(int round, float time)
    {
        var timeCartGO = Instantiate(timeCartPrefab);
        timeCartGO.transform.parent = transform;

        var timeCart = timeCartGO.GetComponent<TimeCart>();
        timeCart.SetRoundTime(time, round);
        timeCartList.Add(timeCart);
    }
}
