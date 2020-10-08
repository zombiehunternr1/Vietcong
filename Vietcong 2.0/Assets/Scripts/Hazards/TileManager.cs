using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<Transform> TileList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        //creates an array TempTile and gets all the children components that are attached to this parent.
        Transform[] TempTile = GetComponentsInChildren<Transform>();

        //Goes over each indivitual tile in the array TempTile;
        foreach(Transform tile in TempTile)
        {
            //Adds the tile to the list TileList.
            TileList.Add(tile);
        }
        //Removes the first tile in the array because this is the parent tile. This tile must not be removed else the code will break.
        TileList.RemoveAt(0);
        //Starts the coroutine that makes the tiles drop overtime.
        StartCoroutine(DropTile());
    }

    public IEnumerator DropTile()
    {
        //Keeps looping until the amount of tiles in the TileList is smaller then 0.
        while (TileList.Count > 0)
        {
            //Gets a random tile from the TileList and puts it in the variable DTile.
            var DropThisTile = TileList[Random.Range(0, TileList.Count)];
            yield return new WaitForSeconds(1);
            //Starts the coroutine that drops the single selected tile.
            StartCoroutine(DropThisTile.GetComponent<Tile>().DroppingThisTile());
            //Removes the tile that is stored in the variable DTile from the list TileList.
            TileList.Remove(DropThisTile);
        }
    }
}
