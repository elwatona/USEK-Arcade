using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBonus : MonoBehaviour
{
    public Texture2D map;
    public GameObject floor;
    public GameObject wall;
    public GameObject ship;

    public int width;
    public int height;

    GameObject[,] grid;
    public int[,] gridInt;

    private void Awake()
    {
        width = map.width;
        height = map.height;
        grid = new GameObject[width, height];
        gridInt = new int[width, height];

        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixelColor = map.GetPixel(x, y);

                if (pixelColor == Color.white)
                {
                    grid[x, y] = Instantiate(floor, new Vector3(x, 0, y), Quaternion.identity);
                    
                }
                else if (pixelColor == Color.black)
                {
                    grid[x, y] = Instantiate(wall, new Vector3(x, 0, y), Quaternion.identity);
                   
                }
                else if (pixelColor == Color.red)
                {
                    grid[x, y] = Instantiate(ship, new Vector3(x, 0, y), Quaternion.identity);
                }
                else
                {
                    //variable para que no sea caminable
                }
            }
        }
    }
}
