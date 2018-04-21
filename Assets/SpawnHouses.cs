using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnHouses : MonoBehaviour
{
    public GameObject HousePrefab;

    public float xOffset;
    public float yOffest;

    void Start()
    {
        GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        TileCollisionHandler tch = GetComponent<TileCollisionHandler>();

        Tilemap tilemap = GetComponent<Tilemap>();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {              
                    if (tile.name == tch.HouseSpotTileName)
                    {
                        Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                        //print("here is house tile");
                        GameObject house = Instantiate(HousePrefab, null);
                        house.name = "muj dum";
                        Vector3 housePos = gridLayout.CellToWorld(new Vector3Int(x - 13, y - 19, 0));
                        housePos = new Vector3(housePos.x + xOffset, housePos.y + yOffest, 0);
                        house.transform.position = housePos;
                    }
                }
            }
        }
    }
}