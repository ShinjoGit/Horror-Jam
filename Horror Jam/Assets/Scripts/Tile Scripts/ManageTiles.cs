using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public float positionOffset = 500.0f;

    public GameObject BaseTile;
    public GameObject rock;

    // used to flag if player is in a trigger or not
    bool EastWestTrigger = false;
    bool NorthSouthTrigger = false;

    public Dictionary<string, Vector3> posOffsets = new Dictionary<string, Vector3>() 
    { 
        {"TL", new Vector3(    -500.0f,    0.0f,   +500.0f   )},
        {"TC", new Vector3(    0.0f,       0.0f,   +500.0f   )},
        {"TR", new Vector3(    +500.0f,    0.0f,   +500.0f   )},
        {"L",  new Vector3(    -500.0f,    0.0f,   0.0f      )},
        {"C",  new Vector3(    0.0f,       0.0f,   0.0f      )},
        {"R",  new Vector3(    +500.0f,    0.0f,   0.0f      )},
        {"BL", new Vector3(    -500.0f,    0.0f,   -500.0f   )},
        {"BC", new Vector3(    0.0f,       0.0f,   -500.0f   )},
        {"BR", new Vector3(    +500.0f,    0.0f,   -500.0f   )}
    }; 

    public Vector3[] positionOffsets = 
    {
        new Vector3(    -500.0f,    0.0f,   +500.0f   ),
        new Vector3(    0.0f,       0.0f,   +500.0f   ),
        new Vector3(    +500.0f,    0.0f,   +500.0f   ),
        new Vector3(    -500.0f,    0.0f,   0.0f      ),
        new Vector3(    0.0f,       0.0f,   0.0f      ),
        new Vector3(    -500.0f,    0.0f,   0.0f      ),
        new Vector3(    +500.0f,    0.0f,   -500.0f   ),
        new Vector3(    0.0f,       0.0f,   -500.0f   ),
        new Vector3(    +500.0f,    0.0f,   -500.0f   )
    };

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

    GameObject[] CenterPositions(GameObject[] list, Vector3 pos)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].transform.position = pos;
        }
        return list;
    }

    // hack the tiles to beheave
    void SetTilesInactive()
    {
        TR_Tile.SetActive(false);
        TC_Tile.SetActive(false);
        TL_Tile.SetActive(false);

        R_Tile.SetActive(false);
        C_Tile.SetActive(false);
        L_Tile.SetActive(false);

        BR_Tile.SetActive(false);
        BC_Tile.SetActive(false);
        BL_Tile.SetActive(false);
    }

    // hack the tiles to behave
    void SetTilesActive()
    {
        TR_Tile.SetActive(true);
        TC_Tile.SetActive(true);
        TL_Tile.SetActive(true);

        R_Tile.SetActive(true);
        C_Tile.SetActive(true);
        L_Tile.SetActive(true);

        BR_Tile.SetActive(true);
        BC_Tile.SetActive(true);
        BL_Tile.SetActive(true);
    }

    public void UpdateNorth(Vector3 pos)
    {
        // only update if we aren't already changing north/south
        if (!NorthSouthTrigger)
        {
            NorthSouthTrigger = true;
            SetTilesInactive();

            // maintain center and old tile
            BC_Tile.transform.position = C_Tile.transform.position;
            C_Tile.transform.position = TC_Tile.transform.position;
            
            Vector3 newCenter = new Vector3(pos.x, pos.y, pos.z + 500.0f);
            
            // apply offsets
            TR_Tile.transform.position = newCenter + posOffsets["TR"];
            TC_Tile.transform.position = newCenter + posOffsets["TC"];
            TL_Tile.transform.position = newCenter + posOffsets["TL"];
            
            R_Tile.transform.position = newCenter + posOffsets["R"];
            L_Tile.transform.position = newCenter + posOffsets["L"];
            
            BR_Tile.transform.position = newCenter + posOffsets["BR"];
            BL_Tile.transform.position = newCenter + posOffsets["BL"];

            SetTilesActive();
        }
    }
    public void UpdateSouth(Vector3 pos)
    {
        // only update if we aren't already changing north/south
        if (!NorthSouthTrigger)
        {
            NorthSouthTrigger = true;
            SetTilesInactive();

            // maintain center and old tile
            TC_Tile.transform.position = C_Tile.transform.position;
            C_Tile.transform.position = BC_Tile.transform.position;

            Vector3 newCenter = new Vector3(pos.x, pos.y, pos.z - 500.0f);

            // apply offsets
            TR_Tile.transform.position = newCenter + posOffsets["TR"];
            TL_Tile.transform.position = newCenter + posOffsets["TL"];

            R_Tile.transform.position = newCenter + posOffsets["R"];
            L_Tile.transform.position = newCenter + posOffsets["L"];

            BR_Tile.transform.position = newCenter + posOffsets["BR"];
            BC_Tile.transform.position = newCenter + posOffsets["BC"];
            BL_Tile.transform.position = newCenter + posOffsets["BL"];

            SetTilesActive();
        }
    }
    public void UpdateWest(Vector3 pos)
    {
        // only update if we aren't already changing east/west
        if (!EastWestTrigger)
        {
            EastWestTrigger = true;
            SetTilesInactive();

            // maintain center and old tile
            R_Tile.transform.position = C_Tile.transform.position;
            C_Tile.transform.position = L_Tile.transform.position;

            Vector3 newCenter = new Vector3(pos.x - 500.0f, pos.y, pos.z);

            // apply offsets
            TR_Tile.transform.position = newCenter + posOffsets["TR"];
            TC_Tile.transform.position = newCenter + posOffsets["TC"];
            TL_Tile.transform.position = newCenter + posOffsets["TL"];

            L_Tile.transform.position = newCenter + posOffsets["L"];

            BR_Tile.transform.position = newCenter + posOffsets["BR"];
            BC_Tile.transform.position = newCenter + posOffsets["BC"];
            BL_Tile.transform.position = newCenter + posOffsets["BL"];


            SetTilesActive();

            //// destroy out of sight tiles
            //Destroy(TR_Tile);
            //Destroy(R_Tile);
            //Destroy(BR_Tile);
            //
            //// update tiles to new positions
            //TR_Tile = TC_Tile;
            //R_Tile = C_Tile;
            //BR_Tile = BC_Tile;
            //TC_Tile = TL_Tile;
            //C_Tile = L_Tile;
            //BC_Tile = BL_Tile;
            //
            //// create new tiles
            //TL_Tile = RandomRocks(
            //    new Vector3(TC_Tile.transform.position.x - positionOffset, TC_Tile.transform.position.y, TC_Tile.transform.position.z),
            //    TC_Tile.transform.rotation);
            //L_Tile = RandomRocks(
            //    new Vector3(C_Tile.transform.position.x - positionOffset, C_Tile.transform.position.y, C_Tile.transform.position.z),
            //    C_Tile.transform.rotation);
            //BL_Tile = RandomRocks(
            //    new Vector3(BC_Tile.transform.position.x - positionOffset, BC_Tile.transform.position.y, BC_Tile.transform.position.z),
            //    BC_Tile.transform.rotation);
        }
    }
    public void UpdateEast(Vector3 pos)
    {
        // only update if we aren't already changing east/west
        if (!EastWestTrigger)
        {
            EastWestTrigger = true;
            SetTilesInactive();

            // maintain center and old tile
            L_Tile.transform.position = C_Tile.transform.position;
            C_Tile.transform.position = R_Tile.transform.position;

            Vector3 newCenter = new Vector3(pos.x + 500.0f, pos.y, pos.z);

            // apply offsets
            TR_Tile.transform.position = newCenter + posOffsets["TR"];
            TC_Tile.transform.position = newCenter + posOffsets["TC"];
            TL_Tile.transform.position = newCenter + posOffsets["TL"];

            R_Tile.transform.position = newCenter + posOffsets["R"];

            BR_Tile.transform.position = newCenter + posOffsets["BR"];
            BC_Tile.transform.position = newCenter + posOffsets["BC"];
            BL_Tile.transform.position = newCenter + posOffsets["BL"];


            SetTilesActive();

            //// destroy out of sight tiles
            //Destroy(TL_Tile);
            //Destroy(L_Tile);
            //Destroy(BL_Tile);
            //
            //// update tiles to new positions
            //TL_Tile = TC_Tile;
            //L_Tile = C_Tile;
            //BL_Tile = BC_Tile;
            //TC_Tile = TR_Tile;
            //C_Tile = R_Tile;
            //BC_Tile = BR_Tile;
            //
            //// create new tiles
            //TR_Tile = RandomRocks(
            //    new Vector3(TC_Tile.transform.position.x + positionOffset, TC_Tile.transform.position.y, TC_Tile.transform.position.z),
            //    TC_Tile.transform.rotation);
            //R_Tile = RandomRocks(
            //    new Vector3(C_Tile.transform.position.x + positionOffset, C_Tile.transform.position.y, C_Tile.transform.position.z),
            //    C_Tile.transform.rotation);
            //BR_Tile = RandomRocks(
            //    new Vector3(BC_Tile.transform.position.x + positionOffset, BC_Tile.transform.position.y, BC_Tile.transform.position.z),
            //    BC_Tile.transform.rotation);
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
