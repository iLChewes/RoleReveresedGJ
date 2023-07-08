using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpriteRenderer))]
public class TilePlaceTemplate : MonoBehaviour
{
    [SerializeField] private Color canPlaceColor;
    [SerializeField] private Color canNotPlaceColor;
    [SerializeField] private GameObject xIcon;
    public LayerMask layerMask;

    public bool CanPlace = true;
    
    private SpriteRenderer spriteRenderer;
    private Material material;

    public bool pathExists = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var originalMat = spriteRenderer.material;
        material = Instantiate(originalMat);
        spriteRenderer.material = material;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 10.0f, layerMask);
        CanPlace = !hit && pathExists;
        
        material.color = CanPlace ? canPlaceColor : canNotPlaceColor;
        xIcon.SetActive(!CanPlace);
    }
}
