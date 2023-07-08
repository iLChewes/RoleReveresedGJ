using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpriteRenderer))]
public class TilePlaceTemplate : MonoBehaviour
{
    [SerializeField] private Color canPlaceColor;
    [SerializeField] private Color canNotPlaceColor;
    [SerializeField] private GameObject xIcon;

    public bool CanPlace = true;
    public bool CanGroupPlace = true;
    
    private SpriteRenderer spriteRenderer;
    private Material material;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var originalMat = spriteRenderer.material;
        material = Instantiate(originalMat);
        spriteRenderer.material = material;
    }

    void Update()
    {
        material.color = CanGroupPlace ? canPlaceColor : canNotPlaceColor;
        xIcon.SetActive(!CanPlace);
    }
}
