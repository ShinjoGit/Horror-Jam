using UnityEngine;
using System.Collections;

public class ManageTiles : MonoBehaviour
{
    public static GameObject manager;

    public GameObject TR_Tile;
    public GameObject TC_Tile;
    public GameObject TL_Tile;
    public GameObject R_Tile;
    public GameObject C_Tile;
    public GameObject L_Tile;
    public GameObject BR_Tile;
    public GameObject BC_Tile;
    public GameObject BL_Tile;

    // update this when changing scale of tiles
    public float positionOffset = 250.0f;

    public GameObject BaseTile;
    public GameObject rock;

    // used to flag if player is in a trigger or not
    bool EastWestTrigger = false;
    bool NorthSouthTrigger = false;

    public bool NSTrigger
    {
        get { return NorthSouthTrigger; }
        set { NorthSouthTrigger = value; }
    }

    public bool EWTrigger
    {
        get { return EastWestTrigger; }
        set { EastWestTrigger = value; }
    }


    void Awake()
    {
        //singleton control
        if (manager == null)
        {
            manager = this.gameObject;
            DontDestroyOnLoad(manager);
        }
        else if (manager != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateNorth()
    {
        // only update if we aren't already changing north/south
        if (!NorthSouthTrigger)
        {
            NorthSouthTrigger = true;

            // destroy out of sight tiles
            Destroy(BR_Tile);
            Destroy(BC_Tile);
            Destroy(BL_Tile);

            // update tiles to new positions
            BR_Tile = R_Tile;
            BC_Tile = C_Tile;
            BL_Tile = L_Tile;
            R_Tile = TR_Tile;
            C_Tile = TC_Tile;
            L_Tile = TL_Tile;

            // create new tiles
            TR_Tile = RandomRocks(
                new Vector3(R_Tile.transform.position.x, R_Tile.transform.position.y, R_Tile.transform.position.z + positionOffset),
                R_Tile.transform.rotation);
            TC_Tile = RandomRocks(
                new Vector3(C_Tile.transform.position.x, C_Tile.transform.position.y, C_Tile.transform.position.z + positionOffset),
                C_Tile.transform.rotation);
            TL_Tile = RandomRocks(
                new Vector3(L_Tile.transform.position.x, L_Tile.transform.position.y, L_Tile.transform.position.z + positionOffset),
                L_Tile.transform.rotation);
        }
    }
    public void UpdateSouth()
    {
        // only update if we aren't already changing north/south
        if (!NorthSouthTrigger)
        {
            NorthSouthTrigger = true;

            // destroy out of sight tiles
            Destroy(TR_Tile);
            Destroy(TC_Tile);
            Destroy(TL_Tile);

            // update tiles to new positions
            TR_Tile = R_Tile;
            TC_Tile = C_Tile;
            TL_Tile = L_Tile;
            R_Tile = BR_Tile;
            C_Tile = BC_Tile;
            L_Tile = BL_Tile;

            // create new tiles
            BR_Tile = RandomRocks(
                new Vector3(R_Tile.transform.position.x, R_Tile.transform.position.y, R_Tile.transform.position.z - positionOffset),
                R_Tile.transform.rotation);
            BC_Tile = RandomRocks(
                new Vector3(C_Tile.transform.position.x, C_Tile.transform.position.y, C_Tile.transform.position.z - positionOffset),
                C_Tile.transform.rotation);
            BL_Tile = RandomRocks(
                new Vector3(L_Tile.transform.position.x, L_Tile.transform.position.y, L_Tile.transform.position.z - positionOffset),
                L_Tile.transform.rotation);

        }
    }
    public void UpdateWest()
    {
        // only update if we aren't already changing east/west
        if (!EastWestTrigger)
        {
            EastWestTrigger = true;

            // destroy out of sight tiles
            Destroy(TR_Tile);
            Destroy(R_Tile);
            Destroy(BR_Tile);

            // update tiles to new positions
            TR_Tile = TC_Tile;
            R_Tile = C_Tile;
            BR_Tile = BC_Tile;
            TC_Tile = TL_Tile;
            C_Tile = L_Tile;
            BC_Tile = BL_Tile;

            // create new tiles
            TL_Tile = RandomRocks(
                new Vector3(TC_Tile.transform.position.x - positionOffset, TC_Tile.transform.position.y, TC_Tile.transform.position.z),
                TC_Tile.transform.rotation);
            L_Tile = RandomRocks(
                new Vector3(C_Tile.transform.position.x - positionOffset, C_Tile.transform.position.y, C_Tile.transform.position.z),
                C_Tile.transform.rotation);
            BL_Tile = RandomRocks(
                new Vector3(BC_Tile.transform.position.x - positionOffset, BC_Tile.transform.position.y, BC_Tile.transform.position.z),
                BC_Tile.transform.rotation);
        }
    }
    public void UpdateEast()
    {
        // only update if we aren't already changing east/west
        if (!EastWestTrigger)
        {
            EastWestTrigger = true;

            // destroy out of sight tiles
            Destroy(TL_Tile);
            Destroy(L_Tile);
            Destroy(BL_Tile);

            // update tiles to new positions
            TL_Tile = TC_Tile;
            L_Tile = C_Tile;
            BL_Tile = BC_Tile;
            TC_Tile = TR_Tile;
            C_Tile = R_Tile;
            BC_Tile = BR_Tile;

            // create new tiles
            TR_Tile = RandomRocks(
                new Vector3(TC_Tile.transform.position.x + positionOffset, TC_Tile.transform.position.y, TC_Tile.transform.position.z),
                TC_Tile.transform.rotation);
            R_Tile = RandomRocks(
                new Vector3(C_Tile.transform.position.x + positionOffset, C_Tile.transform.position.y, C_Tile.transform.position.z),
                C_Tile.transform.rotation);
            BR_Tile = RandomRocks(
                new Vector3(BC_Tile.transform.position.x + positionOffset, BC_Tile.transform.position.y, BC_Tile.transform.position.z),
                BC_Tile.transform.rotation);
        }
    }

    Vector3 RandomXZPosition(Vector3 pos)
    {
        return new Vector3(pos.x + Random.Range(0, 250), pos.y + 2.0f, pos.z + Random.Range(0, 250));
    }

    GameObject RandomRocks(Vector3 pos, Quaternion rot)
    {
        GameObject newTile = (GameObject)Instantiate(BaseTile, pos, rot);

        int numRocks = Random.Range(1, 16);
        
        for (int i = 0; i < numRocks; ++i)
        {
            Transform t = ((GameObject)Instantiate(rock, RandomXZPosition(pos), rot)).transform;
        
            t.parent = newTile.transform;
        
           // t.transform.position = RandomXZPosition(t.transform.position);
        }

        return newTile;
    }
}
