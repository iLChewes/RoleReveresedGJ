using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEditor;
using UnityEngine;

public class GridPlaceTemplate : MonoBehaviour
{
    public SpawnableObject spawnableObject;

    public GameObject Player;
    public GameObject chest;

    private Vector2 lastPos = Vector2.zero;

    private CheckIfTemplateCanSpawn spawnTemplate;

    // Start is called before the first frame update
    void Start()
    {
        spawnTemplate = Instantiate(spawnableObject.spawnTemplate);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GraphNode closestNode = AstarPath.active.GetNearest(worldPosition, NNConstraint.None).node;

        Int3 closestInt = closestNode.position;
        Vector2 closest = (Vector3)closestInt;

        if(lastPos != closest)
        {
            lastPos = closest;

            var newPosition = closest;
            spawnTemplate.transform.position = newPosition;
            
            spawnTemplate.UpdatePath(Player.transform.position, chest.transform.position);
        }

        if(spawnTemplate.CanSpawn && Input.GetMouseButtonDown(0))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if(spawnTemplate.CanSpawn)
            Instantiate(spawnableObject.actualObject, spawnTemplate.transform.position, spawnTemplate.transform.rotation);
    }
}
