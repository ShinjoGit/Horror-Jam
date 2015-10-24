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

    public GameObject BaseTile;

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
            TR_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(R_Tile.transform.position.x, R_Tile.transform.position.y, R_Tile.transform.position.z + 250.0f),
                R_Tile.transform.rotation);
            TC_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(C_Tile.transform.position.x, C_Tile.transform.position.y, C_Tile.transform.position.z + 250.0f),
                C_Tile.transform.rotation);
            TL_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(L_Tile.transform.position.x, L_Tile.transform.position.y, L_Tile.transform.position.z + 250.0f),
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
            BR_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(R_Tile.transform.position.x, R_Tile.transform.position.y, R_Tile.transform.position.z - 250.0f),
                R_Tile.transform.rotation);
            BC_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(C_Tile.transform.position.x, C_Tile.transform.position.y, C_Tile.transform.position.z - 250.0f),
                C_Tile.transform.rotation);
            BL_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(L_Tile.transform.position.x, L_Tile.transform.position.y, L_Tile.transform.position.z - 250.0f),
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
            TL_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(TC_Tile.transform.position.x - 250.0f, TC_Tile.transform.position.y, TC_Tile.transform.position.z),
                TC_Tile.transform.rotation);
            L_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(C_Tile.transform.position.x - 250.0f, C_Tile.transform.position.y, C_Tile.transform.position.z),
                C_Tile.transform.rotation);
            BL_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(BC_Tile.transform.position.x - 250.0f, BC_Tile.transform.position.y, BC_Tile.transform.position.z),
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
            TR_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(TC_Tile.transform.position.x + 250.0f, TC_Tile.transform.position.y, TC_Tile.transform.position.z),
                TC_Tile.transform.rotation);
            R_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(C_Tile.transform.position.x + 250.0f, C_Tile.transform.position.y, C_Tile.transform.position.z),
                C_Tile.transform.rotation);
            BR_Tile = (GameObject)Instantiate(
                BaseTile,
                new Vector3(BC_Tile.transform.position.x + 250.0f, BC_Tile.transform.position.y, BC_Tile.transform.position.z),
                BC_Tile.transform.rotation);
        }

    }
}
