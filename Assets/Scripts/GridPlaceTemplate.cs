using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GridPlaceTemplate : MonoBehaviour
{

    [SerializeField] private int Width = 2;
    [SerializeField] private int Height = 2;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private TilePlaceTemplate spawnTemplate;

    private List<TilePlaceTemplate> spawnTemplateList = new List<TilePlaceTemplate>();


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

        float closestX = Mathf.Round(worldPosition.x);
        float closestY = Mathf.Round(worldPosition.y);

        bool canGroupPlace = true;

        for(int w = 0; w < Width; w++)
        {
            float xValue = closestX + w;
            for(int h = 0; h < Height; h++)
            {
                float yValue = closestY + h;
                int index = w + (h * Width);
                var template = spawnTemplateList.ElementAt(index);
                var newPosition = new Vector2(xValue+0.5f, yValue+0.5f);
                template.transform.position = newPosition;
                
                RaycastHit2D hit = Physics2D.Raycast(newPosition, Vector2.zero);
               
                if(hit)
                {
                    canGroupPlace = false;
                    template.CanPlace = false;
                }
                else
                {
                    template.CanPlace = true;
                }

                template.CanGroupPlace = canGroupPlace;
            }
        }

        foreach(TilePlaceTemplate template in spawnTemplateList)
        {
            template.CanGroupPlace = canGroupPlace;
        }

        if(canGroupPlace && Input.GetMouseButtonDown(0))
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
