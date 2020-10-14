using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<Transform> TileList = new List<Transform>();
    public float MinRanVal;
    public float MaxRanVal;

    // Start is called before the first frame update
    void Start()
    {
        //Checks if the script is enabled before executing ferther.
        if (this.enabled)
        {
            //creates an array TempTile and gets all the children components that are attached to this parent.
            Transform[] TempTile = GetComponentsInChildren<Transform>();

            //Goes over each indivitual tile in the array TempTile;
            foreach (Transform tile in TempTile)
            {
                //Adds the tile to the list TileList.
                TileList.Add(tile);
            }
            //Removes the first tile in the array because this is the parent tile. This tile must not be removed else the code will break.
            TileList.RemoveAt(0);
            //Starts the coroutine that makes the tiles drop overtime.
            StartCoroutine(DropTile());
        }       
    }

    public IEnumerator DropTile()
    {
        if (this.enabled)
        {
            //Keeps looping until the amount of tiles in the TileList is smaller then 0.
            while (TileList.Count > 0)
            {
                //Gets a random tile from the TileList and puts it in the variable DTile.
                var DropThisTile = TileList[Random.Range(0, TileList.Count)];
                //Waits with executing the rest of the function until the random range time has passed.
                yield return new WaitForSeconds(Random.Range(MinRanVal, MaxRanVal));
                //Starts the coroutine that drops the single selected tile.
                StartCoroutine(DropThisTile.GetComponent<Tile>().DroppingThisTile());
                //Checks if the boolean IsHit equal to false.
                if (DropThisTile.GetComponent<Tile>().IsHit == false)
                {
                    //Removes the tile that is stored in the variable DTile from the list TileList.
                    TileList.Remove(DropThisTile);
                }
            }
        }
    }
}
