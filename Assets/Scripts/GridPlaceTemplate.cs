using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEditor;
using UnityEngine;

public class GridPlaceTemplate : MonoBehaviour
{

    [SerializeField] private int Width = 2;
    [SerializeField] private int Height = 2;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private TilePlaceTemplate spawnTemplate;

    public LayerMask layerMask;

    public GameObject Player;
    public GameObject chest;

    private List<TilePlaceTemplate> spawnTemplateList = new List<TilePlaceTemplate>();
    private Vector2 lastPos = Vector2.zero;
    private bool pathExists = true;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Width * Height; i++)
        {
            TilePlaceTemplate template = Instantiate(spawnTemplate);
            spawnTemplateList.Add(template);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 closest = new Vector2(Mathf.Round(worldPosition.x), Mathf.Round(worldPosition.y));

        if(lastPos != closest)
        {
            lastPos = closest;

            for(int w = 0; w < Width; w++)
            {
                float xValue = lastPos.x + w;
                for(int h = 0; h < Height; h++)
                {
                    float yValue = lastPos.y + h;
                    int index = w + (h * Width);
                    var template = spawnTemplateList.ElementAt(index);
                    var newPosition = new Vector2(xValue+0.5f, yValue+0.5f);
                    template.transform.position = newPosition;
                }
            }
            
            AstarPath.active.Scan();
            
            GraphNode node1 = AstarPath.active.GetNearest(Player.transform.position, NNConstraint.Default).node;
            
            GraphNode node2 = AstarPath.active.GetNearest(chest.transform.position, NNConstraint.Default).node;
            
            pathExists = PathUtilities.IsPathPossible(node1, node2);
            
        }

        bool canGroupPlace = true;

        foreach(var template in spawnTemplateList)
        {
            if(!pathExists)
            {
                template.CanPlace = false;
                continue;                
            }
            RaycastHit2D hit = Physics2D.Raycast(template.transform.position, Vector2.zero, 10.0f, layerMask);
            if(hit)
            {
                canGroupPlace = false;
                template.CanPlace = false;
            }
            else
            {
                template.CanPlace = true;
            }
        }

        if(canGroupPlace && Input.GetMouseButtonDown(0) && pathExists)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        foreach(TilePlaceTemplate template in spawnTemplateList)
        {
            Instantiate(objectToSpawn, template.transform.position, template.transform.rotation);
        }
    }
}
