using Pathfinding;
using UnityEngine;

public class GridPlaceTemplate : MonoBehaviour
{
    private SpawnableObject spawnableObject;

    public GameObject Player;
    public GameObject chest;

    private Vector2 lastPos = Vector2.zero;

    private CheckIfTemplateCanSpawn spawnTemplate;

    private ObstacleHolder obstacleHolder;

    private void OnEnable()
    {
        BuildManager.Instance.OnObstacleChanged += SetNewSpawnObject;
    }

    private void OnDisable()
    {
        BuildManager.Instance.OnObstacleChanged -= SetNewSpawnObject;
    }

    public void SetNewSpawnObject(ObstacleHolder newObstacle)
    {
        obstacleHolder = newObstacle;
        if(spawnTemplate)
        {
            DespawnTempalte();
        }
        
        if(obstacleHolder == null)
        {
            spawnTemplate = null;
            spawnableObject = null;
        }
        else
        {
            SpawnTemplate();
            spawnableObject = obstacleHolder.spawnableObject;
        }    
    }

    void SpawnTemplate()
    {
        if(!spawnTemplate)
            spawnTemplate = Instantiate(obstacleHolder.spawnableObject.spawnTemplate);
    }

    void DespawnTempalte()
    {
        if(spawnTemplate)
            Destroy(spawnTemplate.gameObject);
        spawnTemplate = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(obstacleHolder == null) { return; }
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GraphNode closestNode = AstarPath.active.GetNearest(worldPosition, NNConstraint.None).node;

        Int3 closestInt = closestNode.position;
        
        
        Vector2 closest = (Vector3)closestInt;

        bool toFarFromGrid = (worldPosition - closest).magnitude > 2.0f;
        if(toFarFromGrid)
        {
            DespawnTempalte();
        }
        else
        {
            SpawnTemplate();
        }

        if(lastPos != closest && spawnTemplate)
        {
            lastPos = closest;
            var newPosition = closest;
            spawnTemplate.transform.position = newPosition;
            spawnTemplate.UpdatePath(Player.transform.position, chest.transform.position);
        }

        if(!toFarFromGrid && spawnTemplate.CanSpawn && Input.GetMouseButtonDown(0) && obstacleHolder.CanSpawn())
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if(spawnTemplate.CanSpawn)
        {
            Instantiate(spawnableObject.actualObject, spawnTemplate.transform.position, spawnTemplate.transform.rotation);
            obstacleHolder.spawnAmount -= 1;
            obstacleHolder.SetNewSpawnAmountText();
        }
    }
}
