using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ControlGrid : MonoBehaviour
{
    public int width;
    public int height;
    public float cellSice;
    public Vector3 originPosition;

    [SerializeField]
    private float lineThickness;

    public Grid<GridValues> grid;

    [SerializeField]
    private GameObject lineRenderer;

    public enum GridValues
    {
        none,
        placeholder
    }

    private void Awake()
    {
        CreateGrid();
        DrawGridLines();
    }
    private void CreateGrid()
    {
        grid = new Grid<GridValues>(width, height, cellSice, originPosition);
    }

    private void DrawGridLines()
    {
        LineRenderer[] verticalLineRenderer = new LineRenderer[height + 1];
        LineRenderer[] horizontalLineRenderer = new LineRenderer[width + 1];
        for (int x = 0; x < horizontalLineRenderer.Length; x++)
        {
            horizontalLineRenderer[x] = Instantiate(lineRenderer.GetComponent<LineRenderer>());
            horizontalLineRenderer[x].positionCount = 2;
            horizontalLineRenderer[x].widthMultiplier = lineThickness;
            horizontalLineRenderer[x].SetPosition(0, new Vector3(x * cellSice, height * cellSice + lineThickness / 2) + originPosition);
            horizontalLineRenderer[x].SetPosition(1, new Vector3(x, 0 - lineThickness / 2) + originPosition);
        }
        for (int y = 0; y < verticalLineRenderer.Length; y++)
        {
            verticalLineRenderer[y] = Instantiate(lineRenderer.GetComponent<LineRenderer>());
            verticalLineRenderer[y].positionCount = 2;
            verticalLineRenderer[y].widthMultiplier = lineThickness;
            verticalLineRenderer[y].SetPosition(0, new Vector3(width * cellSice + lineThickness / 2, y * cellSice) + originPosition);
            verticalLineRenderer[y].SetPosition(1, new Vector3(0 - lineThickness / 2, y) + originPosition);
        }
    }
}
