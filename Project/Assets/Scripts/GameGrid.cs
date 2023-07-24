using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public static int rows = 10;
    public static int columns = 20;

    public Vector2 BottomLeftCorner = new Vector2(0f,0f);


    [SerializeField] public Transform[,] grid = new Transform[rows, columns];

    //create an instance of the game grid (wich is supposed to be the only one : 

    public static GameGrid instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of GameGrid in the scene");
            return;
        }

        instance = this;

    }
    public bool ValidGridPosition(Vector2 position)
    {
        return ((int)position.x >= (int)BottomLeftCorner.x && (int)position.x  < (int)(rows) 
                && (int)position.y >= (int)BottomLeftCorner.y && (int)position.y < (int)(columns));
    }

    public void DeleteRow(int y)
    {
        for(int x = 0; x< rows; x++)
        {
            GameObject.Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    //happen in case of DeleteRow (take as hypothesis that the rows under y is empty)
    public void LowerOneRow(int y)
    {
        for(int x =0; x <rows; x++) 
        {
            if (grid[x, y] != null)
            {
                //lower on the grid (data)
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                //lower on the world (position): 
                grid[x, y - 1].position += Vector3.down;
            }
        }
    }

    public void LowerAllRowsAbove(int y)
    {
        for(int _y = y; _y < columns; _y++)
        {
            LowerOneRow(_y);
        }
    }

    public bool IsFullRow(int y)
    {
        for(int x = 0; x < rows; x++)
        {
            if (grid[x, y] == null)
                return false;
        }

        return true;
    }

    public void LowerAllRows()
    {
        for(int y = 0; y < columns; y++)
        {
            if (IsFullRow(y))
            {
                DeleteRow(y);
                LowerAllRowsAbove(y + 1);
                y--;
            }
        }
    }

    public int GetRows()
    {
        return rows;
    }

    public int GetColumns()
    {
        return columns;
    }
}
