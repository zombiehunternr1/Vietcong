using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Color COrange = new Color32(254, 161, 0, 1);
    public bool IsHit = true;
    public GameObject Killzone;
    public Transform tile;

    public IEnumerator DroppingThisTile()
    {
        if (IsHit == false)
        {
            //Gets the material from the selected tile that is stored in the variable DTile.
            var DTileColor = GetComponent<Renderer>().material;
            //Changes the color to orange.
            DTileColor.color = COrange;
            //Waits 1 seconds before executing the rest of the code.
            yield return new WaitForSeconds(1);
            //Changes the color to red.
            DTileColor.color = Color.red;
            //Waits 1 seconds before executing the rest of the code.
            yield return new WaitForSeconds(1);
            //Destroys the tile that is stored in the variable DTile.
            Destroy(this.gameObject);
        }
        if(IsHit == true)
        {
            //Gets the material from the selected tile that is stored in the variable DTile.
            var DTileColor = GetComponent<Renderer>().material;
            //Changes the color to orange.
            DTileColor.color = COrange;
            //Waits 1 seconds before executing the rest of the code.
            yield return new WaitForSeconds(1);
            //Changes the color to red.
            DTileColor.color = Color.red;
            //Waits 1 seconds before executing the rest of the code.
            yield return new WaitForSeconds(1);
            //Changes the color to black.
            DTileColor.color = Color.black;
            //Creates the killzone area on the tile and stores it in the variable TempKillZone.
            var TempKillZone = Instantiate(Killzone, tile.transform.position, tile.rotation);
            TempKillZone.transform.localScale = tile.transform.localScale;
            //Waits 1/10 of a second before executing the rest of the code.
            yield return new WaitForSeconds(0.1f);
            //Destroys the temporarely killzone.
            Destroy(TempKillZone);
            //Sets the bool IsHit to false.
            IsHit = false;
        }   
    }

    private void OnCollisionEnter(Collision other)
    {
        //Check if the player collides with a tile that has been hit once.
        //Sets the movementspeed to 1 when walking on the hit tile.
        //Sets the movementspped to 5 when not walking on the hit tile.
        if (PlayerTotal.PlayerList.Contains(other.gameObject) && IsHit == false)
        {
            other.gameObject.GetComponent<Movement>()._moveSpeed = 1;
        }
        else
        {
            other.gameObject.GetComponent<Movement>()._moveSpeed = 5;
        }
    }
}
