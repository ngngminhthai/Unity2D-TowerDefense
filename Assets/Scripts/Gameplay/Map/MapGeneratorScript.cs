using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGeneratorScript : MonoBehaviour
{
    public int mapWidth = 8;
    public int mapHeight = 8;

    public Tilemap tilemap;
    public Tile[] tiles;


    const int MAX_STONES = 12;
    const int MAX_WATER = 15;
    const int MAX_TREES = 20;
    int countStone=0, countWater=0, countTree=0;
    int allotment = 0, totalRender = 0, leftSide = 0;
    // tiles[2] stones, tiles[3] water, tiles[5] tree

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = -mapWidth/2; x < mapWidth/2; x++)
        {
            for (int y = -mapHeight/2; y < mapHeight/2; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePos, GetRandomTile());
                if (x < 0) leftSide += 1;
                totalRender += 1;
            }
        }
    }

    Tile GetRandomTile()
    {
        Debug.Log(countStone+" "+ leftSide + " "+countWater);
        int rand = Random.Range(0, tiles.Length);
        if (countWater >= MAX_WATER || countTree >= MAX_TREES || countStone >= MAX_STONES)
        {
            Debug.Log("Larger");
            while (true)
            {
                rand = Random.Range(0, tiles.Length);
                if (rand != 2 && rand != 3 && rand != 5) return tiles[rand];
            }
        }
        else
        {
            switch (rand)
            {
                case 2:
                    countStone++;
                    break;
                case 3:
                    countWater++;
                    break;
                case 5:
                    countTree++;
                    break;
            }
            if (allotment > 20&&leftSide<50)
            {
                Debug.Log("hehe");
                while (true)
                {
                    rand = Random.Range(0, tiles.Length);
                    if (rand != 2 && rand != 3 && rand != 5) return tiles[rand];
                }
            }
        }
        if (rand == 2 || rand == 3 || rand == 5) allotment += 1;
        return tiles[rand];
    }
}
