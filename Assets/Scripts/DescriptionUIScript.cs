using UnityEngine;

public class DescriptionUIScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToHide;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
    }

    public void HideObject()
    {
        objectToHide.SetActive(false);
    }
}
