using System;
using System.Linq;
using Pathfinding;
using UnityEngine;

public class CheckIfTemplateCanSpawn : MonoBehaviour
{
    private TilePlaceTemplate[] templates;
    private void Awake()
    {
        templates = GetComponentsInChildren<TilePlaceTemplate>();
    }
    private bool pathExists = true;

    public void UpdatePath(Vector3 playerPos, Vector3 chestPos)
    {
        AstarPath.active.Scan();
        GraphNode node1 = AstarPath.active.GetNearest(playerPos, NNConstraint.Default).node;
        GraphNode node2 = AstarPath.active.GetNearest(chestPos, NNConstraint.Default).node;
        pathExists = PathUtilities.IsPathPossible(node1, node2);

        foreach(var template in templates)
        {
            template.pathExists = pathExists;
        }
    }
    public bool CanSpawn => pathExists && templates.All(t => t.CanPlace);
}
