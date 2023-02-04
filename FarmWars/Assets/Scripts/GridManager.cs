using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridManager : MonoBehaviour
{
    //CUIDAO CON TOCAR AQUI 
    private static float initXPos = -0.5008f;
    private static float initYPos = -0.5008f;
    private static float scale = 1f;
    //MUCHO CUIDAO


    [SerializeField] private int Width, Height;
    [SerializeField] private Tile TilePrefab;
    [SerializeField] private Transform Camera;

    private void Start()
    {
        GenerateGrid();
    }
    // Start is called before the first frame update
    void GenerateGrid()
    {
        //GameObject emptyParentTiles = Instantiate(new GameObject(), new Vector3(0, 0, 0));
        for (float x = initXPos; x < Width; x++)
        {
            for (float y = initYPos; y < Height; y++)
            {
                Tile spawnedPrefab = Instantiate(TilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedPrefab.name = "tile" + x + " " + y;
                spawnedPrefab.transform.localScale = new Vector3(scale, scale, 0);

                var IsOffset = ((int)x % 2 == 0 && (int)y % 2 != 0) || ((int)x % 2 != 0 && (int)y % 2 == 0);
                spawnedPrefab.Init(IsOffset);

                //spawnedPrefab.transform.SetParent(emptyParentTiles);
            }
        }
        Camera.transform.position = new Vector3((float)Width / 2 - 0.5f, (float)Height / 2 - 0.5f, -10);
    }
}
