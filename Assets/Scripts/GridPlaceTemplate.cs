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
    [SerializeField] private GameObject spawnTemplate;

    private List<GameObject> spawnTemplateList = new List<GameObject>();
    

    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Width * Height; i++)
        {
            GameObject template = Instantiate(spawnTemplate);
            spawnTemplateList.Add(template);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float closestX = Mathf.Round(worldPosition.x);
        float closestY = Mathf.Round(worldPosition.y);

        for(int w = 0; w < Width; w++)
        {
            float xValue = closestX + (float)(w);
            for(int h = 0; h < Height; h++)
            {
                float yValue = closestY + (float)(h);
                int index = w + (h * Width);
                var template = spawnTemplateList.ElementAt(index);
                template.transform.position = new Vector2(xValue+0.5f, yValue+0.5f);
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            foreach(GameObject tempate in spawnTemplateList)
            {
                Instantiate(objectToSpawn, tempate.transform.position, tempate.transform.rotation);
            }
        }
    }
}
