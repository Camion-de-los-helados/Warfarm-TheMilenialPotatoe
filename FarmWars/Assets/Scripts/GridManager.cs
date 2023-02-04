using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridManager : MonoBehaviour
{

    public static GridManager Instance { get; private set; };


    //CUIDAO CON TOCAR AQUI 
    private static float initXPos = -0.5008f;
    private static float initYPos = -0.5008f;
    private static float scale = 1f;
    //MUCHO CUIDAO


    [SerializeField] private int Width, Height;
    [SerializeField] private Tile TilePrefab;
    [SerializeField] private Transform Camera;

    public Dictionary<Vector2, Tile> TilesDictionary { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GenerateGrid();
    }


    void GenerateGrid()
    {
        TilesDictionary = new Dictionary<Vector2, Tile>();

        GameObject emptyParentTiles = Instantiate(new GameObject());
        emptyParentTiles.name = "Tiles";

        float actualPosX = initXPos;
        float actualPosY = initYPos;
        Tile spawnedPrefab = null;

        for (int x = 0; x < Width; x++)
        {
            actualPosX = initXPos;
            for (int y = 0; y < Height; y++)
            {
                spawnedPrefab = Instantiate(TilePrefab, new Vector3(actualPosX, actualPosY), Quaternion.identity);


                spawnedPrefab.name = "tile" + x + " " + y;
                spawnedPrefab.transform.localScale = new Vector3(scale, scale, 0);

                var IsOffset = ((int)x % 2 == 0 && (int)y % 2 != 0) || ((int)x % 2 != 0 && (int)y % 2 == 0);
                spawnedPrefab.Init(IsOffset);

                spawnedPrefab.transform.SetParent(emptyParentTiles.transform);
                actualPosX += spawnedPrefab.GetSizeofRenderer().x;
            }

            actualPosY += spawnedPrefab.GetSizeofRenderer().y;

        }

        Camera.transform.position = new Vector3((float)Width / 2 - 0.5f, (float)Height / 2 - 0.5f, -10);

    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (TilesDictionary.TryGetValue(pos, out Tile tile))
        {
            return tile;
        }
        else
        {
            Debug.LogWarning("Tile not found");
            return null;
        }

    }

}
