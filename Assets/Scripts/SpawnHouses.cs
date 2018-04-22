using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnHouses : MonoBehaviour
{
    public GameObject HousePrefab;
    public HouseSystem HouseSystem;

    public float xOffset;  //0.5
    public float yOffest;  //0.2

    TileCollisionHandler tch;

    bool isHouseTile(string name)
    {
        if (HouseTileLevel(name) < 0)
            return false;
        else
            return true;

        //7,8,9 in sprite sheet
        /*return ((name == (tch.HouseSpotTileName + "7")) ||
            (name == (tch.HouseSpotTileName + "8")) ||
            (name == (tch.HouseSpotTileName + "9")));*/
    }

    int HouseTileLevel(string name)
    {
        if ((name == (tch.HouseSpotTileName + "7")))
            return 1;

        if ((name == (tch.HouseSpotTileName + "8")))
            return 2;

        if ((name == (tch.HouseSpotTileName + "9")))
            return 3;

        return -1;
    }

    void Start()
    {
        GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        tch = GetComponent<TileCollisionHandler>();

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
                    if (isHouseTile(tile.name))
                    {
                        GameObject house = Instantiate(HousePrefab, null);
                        house.transform.parent = transform;

                        Vector3 housePos = gridLayout.CellToWorld(new Vector3Int(x - 15, y - 7, 0));
                        housePos = new Vector3(housePos.x + xOffset, housePos.y + yOffest, 0);
                        house.transform.position = housePos;

                        House houseComp = house.GetComponent<House>();
                        houseComp.hs = HouseSystem;

                        //L1 - L3 specific
                        int houseLevel = HouseTileLevel(tile.name);
                        houseComp.SetHouse(houseLevel);
                    }
                }
            }
        }
    }
}