using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionUIScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToHide;

    public void HideObject()
    {
        objectToHide.SetActive(false);
    }
}
