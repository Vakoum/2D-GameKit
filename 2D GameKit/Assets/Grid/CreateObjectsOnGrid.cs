using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectsOnGrid : MonoBehaviour
{
    private ControlGrid controlGrid;

    private List<GameObject> gameobjectsInGrid;

    private void Awake()
    {
        controlGrid = GetComponent<ControlGrid>();
    }


    public void CreateObjectInGrid(GameObject instantiate, int x, int y)
    {
        gameobjectsInGrid.Add(Instantiate(instantiate, controlGrid.grid.GetMidCellPosition(x, y), Quaternion.identity));
    }
    public void CreateObjectInGrid(GameObject instantiate, Vector3 position)
    {
        gameobjectsInGrid.Add(Instantiate(instantiate, controlGrid.grid.GetMidCellPosition(position), Quaternion.identity));
    }


    // if u need it implement a funktion to get index
    public GameObject GetGameObject(int index)
    {
        return gameobjectsInGrid[index];
    }
}
