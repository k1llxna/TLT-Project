using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public bool findDistance = false;

    public int rows = 10;
    public int columns = 10;
    public int scale = 2;

    [Header("Hex")]
    public GameObject gridPrefab;
    public Vector3 origin = new Vector3(0, 0, 0);

    public GameObject[,] gridArray;

    //public int startX = 0;
    //public int startY = 0;
    //public int endX = 2;
    //public int endY = 2;

    public List<GameObject> path = new List<GameObject>();

    //private void Awake()
    //{
    //    gridArray = new GameObject[columns, rows];
    //    if (gridPrefab) GenerateGrid();
    //}
    public List<GameObject> Pathfind(int startX, int startY, int endX, int endY)
    {
        // get all possible tiles
        foreach (GameObject obj in gridArray)
        {
            if (obj)
                obj.GetComponent<Hex>().visited = -1;
        }
        // setting current loc to 0
        gridArray[startX, startY].GetComponent<Hex>().visited = 0;

        // set distance from start pos
        int x = startX;
        int y = startY;
        int[] testArray = new int[rows * columns];

        // go through max steps as possible
        for (int stepTest = 1; stepTest < rows * columns; stepTest++)
        {
            foreach (GameObject obj in gridArray)
            {
                if (obj && obj.GetComponent<Hex>().visited == stepTest - 1)
                    TestFourDirections(obj.GetComponent<Hex>().x, obj.GetComponent<Hex>().y, stepTest);
            }
        }

        // set path (target) in relation to pos
        int step;
        // int x = endX;
        //int y = endY;

        List<GameObject> tempList = new List<GameObject>();
        path.Clear();

        // if exists and can be visited
        if (gridArray[endX, endY] && gridArray[endX, endY].GetComponent<Hex>().visited > 0)
        {
            path.Add(gridArray[endX, endY]);
            step = gridArray[endX, endY].GetComponent<Hex>().visited - 1;
        }
        else
        {
            // cant reach location
            Debug.Log("cant reach");
            return null;
        }

        for (int i = step; step > -1; step--)
        {
            if (TestDirection(x, y, step, 1))// up 
                tempList.Add(gridArray[x, y + 1]);
            if (TestDirection(x, y, step, 2)) // right
                tempList.Add(gridArray[x + 1, y]);
            if (TestDirection(x, y, step, 3)) // down
                tempList.Add(gridArray[x, y - 1]);
            if (TestDirection(x, y, step, 4)) // left
                tempList.Add(gridArray[x - 1, y]);

            GameObject tempObj = FindClosest(gridArray[endX, endY].transform, tempList);
            path.Add(tempObj);
            x = tempObj.GetComponent<Hex>().x;
            y = tempObj.GetComponent<Hex>().y;
            tempList.Clear();
        }
        return path;
    }

    #region util
    public void GenerateGrid()
    {
        gridArray = new GameObject[columns, rows];

        foreach (Transform obj in GameObject.Find("_Board1Blocks").transform)
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                
                   // obj.SetParent(this.gameObject.transform);

                    // setting values
                    obj.gameObject.GetComponent<Hex>().x = i;
                    obj.gameObject.GetComponent<Hex>().y = j;

                    gridArray[i, j] = obj.gameObject;
                }
            }
        }
    }

    GameObject FindClosest(Transform targetLocation, List<GameObject> list)
    {
        float currentDistance = scale * rows * columns;
        int indexNum = 0;

        for (int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNum = i;

            }
        }
        return list[indexNum];
    }

    void TestFourDirections(int x, int y, int step)
    {
        if (TestDirection(x, y, -1, 1)) // up
            SetVisited(x, y + 1, step);
        if (TestDirection(x, y, -1, 2)) // right
            SetVisited(x + 1, y, step);
        if (TestDirection(x, y, -1, 3)) // down
            SetVisited(x, y - 1, step);
        if (TestDirection(x, y, -1, 4)) // left
            SetVisited(x - 1, y, step);
    }

    bool TestDirection(int x, int y, int step, int direction) // 1 = up 2 = right 3 = down 4 = left
    {
        switch (direction)
        {
            case 1: // check above
                if (y + 1 < rows && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<Hex>().visited == step) return true;
                break;

            case 2: // check right
                if (x + 1 < columns && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<Hex>().visited == step) return true;
                break;

            case 3: // check down
                if (y - 1 > -1 && gridArray[x, y - 1] && gridArray[x, y - 1].GetComponent<Hex>().visited == step) return true;
                break;

            case 4: // check left
                if (x - 1 > -1 && gridArray[x - 1, y] && gridArray[x - 1, y].GetComponent<Hex>().visited == step) return true;
                break;
        }
        return false;
    }

    void SetVisited(int x, int y, int step)
    {
        if (gridArray[x, y])
            gridArray[x, y].GetComponent<Hex>().visited = step;
    }
    #endregion
}
